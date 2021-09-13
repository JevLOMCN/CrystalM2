using System;
using System.Collections.Generic;
using System.Drawing;
using Server.MirEnvir;
using S = ServerPackets;

namespace Server.MirObjects
{
    public abstract class MapObject
    {
        protected static Envir Envir
        {
            get { return SMain.Envir; }
        }

        public readonly uint ObjectID = SMain.Envir.ObjectID;

        public abstract ObjectType Race { get; }

        public abstract string Name { get; set; }
        
        //Position
        private Map _currentMap;
        public Map CurrentMap
        {
            set
            {
                _currentMap = value;
                CurrentMapIndex = _currentMap != null ? _currentMap.Info.Index : 0;
            }
            get { return _currentMap; }
        }

        public abstract int CurrentMapIndex { get; set; }
        public abstract Point CurrentLocation { get; set; }
        public abstract MirDirection Direction { get; set; }
        
        public abstract byte Level { get; set; }

        public abstract uint Health { get; }
        public abstract uint MaxHealth { get; }
        public byte PercentHealth
        {
            get { return (byte) (Health/(float) MaxHealth*100); }

        }
        
        public byte MinAC, MaxAC, MinMAC, MaxMAC;
        public byte MinDC, MaxDC, MinMC, MaxMC, MinSC, MaxSC;

        public byte Accuracy, Agility, Light;
        public sbyte ASpeed, Luck;
        public int AttackSpeed;

        public byte CurrentHandWeight,
                   MaxHandWeight,
                   CurrentWearWeight,
                   MaxWearWeight;

        public ushort CurrentBagWeight,
                      MaxBagWeight;


        public long CellTime, BrownTime, PKPointTime, LastHitTime, EXPOwnerTime;
        public Color NameColour = Color.White;
        public bool Dead, Undead, Harvested;
        public int PKPoints;

        public ushort PotHealthAmount, PotManaAmount, HealAmount, VampAmount;
        //public bool HealthChanged;

        public bool CoolEye;
        private bool _hidden;
        public bool Hidden
        {
            get { return _hidden; }
            set
            {
                if (_hidden == value) return;
                _hidden = value;
                CurrentMap.Broadcast(new S.ObjectHidden {ObjectID = ObjectID, Hidden = value}, CurrentLocation);
            }

        }

        public MapObject Master, LastHitter, EXPOwner, Target, Owner;
        public long ExpireTime, OwnerTime, OperateTime;
        public int OperateDelay = 100;

        public List<MonsterObject> Pets = new List<MonsterObject>();
        public List<Buff> Buffs = new List<Buff>();

        public List<PlayerObject> GroupMembers;

        public virtual AttackMode AMode { get; set; }

        public virtual PetMode PMode { get; set; }
        public bool InSafeZone;

        public float PoisonRate;
        public List<Poison> PoisonList = new List<Poison>();
        public PoisonType CurrentPoison = PoisonType.None;
        public List<DelayedAction> ActionList = new List<DelayedAction>();


        public LinkedListNode<MapObject> Node;
        public long RevTime;

        public virtual bool Blocking
        {
            get { return true; }
        }

        public Point Front
        {
            get { return Functions.PointMove(CurrentLocation, Direction, 1); }

        }
        public Point Back
        {
            get { return Functions.PointMove(CurrentLocation, Direction, -1); }

        }
        
        
        public virtual void Process()
        {
            if (Master != null && Master.Node == null) Master = null;
            if (LastHitter != null && LastHitter.Node == null) LastHitter = null;
            if (EXPOwner != null && EXPOwner.Node == null) EXPOwner = null;
            if (Target != null && (Target.Node == null || Target.Dead)) Target = null;
            if (Owner != null && Owner.Node == null) Owner = null;

            if (Envir.Time > PKPointTime && PKPoints > 0)
            {
                PKPointTime = Envir.Time + Settings.PKDelay * Settings.Second;
                PKPoints--;
            }
            
            if (LastHitter != null && Envir.Time > LastHitTime)
                LastHitter = null;


            if (EXPOwner != null && Envir.Time > EXPOwnerTime)
            {
                EXPOwner = null;
            }

            for (int i = 0; i < ActionList.Count; i++)
            {
                if (Envir.Time < ActionList[i].Time) continue;
                Process(ActionList[i]);
                ActionList.RemoveAt(i);
            }
        }

        public abstract void SetOperateTime();

        public int GetAttackPower(int min, int max)
        {
            if (min < 0) min = 0;
            if (min > max) max = min;

            if (Luck > 0)
            {
                if (Luck > Envir.Random.Next(10))
                    return max;
            }
            else if (Luck < 0)
            {
                if (Luck < -Envir.Random.Next(10))
                    return min;
            }

            return Envir.Random.Next(min, max + 1);
        }
        
        public virtual void Remove(PlayerObject player)
        {
            player.Enqueue(new S.ObjectRemove {ObjectID = ObjectID});
        }
        public virtual void Add(PlayerObject player)
        {
            player.Enqueue(GetInfo());

        }
        public virtual void Remove(MonsterObject monster)
        {

        }
        public virtual void Add(MonsterObject monster)
        {

        }

        public abstract void Process(DelayedAction action);


        public bool CanFly(Point target)
        {
            Point location = CurrentLocation;
            while (location != target)
            {
                MirDirection dir = Functions.DirectionFromPoint(location, target);

                location = Functions.PointMove(location, dir, 1);

                if (location.X < 0 || location.Y < 0 || location.X >= CurrentMap.Width || location.Y >= CurrentMap.Height) return false;

                if (!CurrentMap.GetCell(location).Valid) return false;

            }

            return true;
        }

        public virtual void Spawned()
        {
            Node = Envir.Objects.AddLast(this);
            OperateTime = Envir.Time + Envir.Random.Next(OperateDelay);

            InSafeZone = CurrentMap.GetSafeZone(CurrentLocation) != null;
            Broadcast(GetInfo());
            BroadcastHealthChange();
        }
        public virtual void Despawn()
        {
            Broadcast(new S.ObjectRemove {ObjectID = ObjectID});
            Envir.Objects.Remove(Node);

            ActionList.Clear();

            for (int i = Pets.Count - 1; i >= 0; i--)
                Pets[i].Die();

            Node = null;
        }

        public MapObject FindObject(uint targetID, int dist)
        {
            for (int d = 0; d <= dist; d++)
            {
                for (int y = CurrentLocation.Y - d; y <= CurrentLocation.Y + d; y++)
                {
                    if (y < 0) continue;
                    if (y >= CurrentMap.Height) break;

                    for (int x = CurrentLocation.X - d; x <= CurrentLocation.X + d; x += Math.Abs(y - CurrentLocation.Y) == d ? 1 : d * 2)
                    {
                        if (x < 0) continue;
                        if (x >= CurrentMap.Width) break;

                        Cell cell = CurrentMap.GetCell(x, y);
                        if (!cell.Valid || cell.Objects == null) continue;

                        for (int i = 0; i < cell.Objects.Count; i++)
                        {
                            MapObject ob = cell.Objects[i];
                            if (ob.ObjectID != targetID) continue;
                            return ob;
                        }
                    }
                }
            }
            return null;
        }


        public virtual void Broadcast(Packet p)
        {
            if (p == null || CurrentMap == null) return;

            for (int i = CurrentMap.Players.Count - 1; i >= 0; i--)
            {
                PlayerObject player = CurrentMap.Players[i];
                if (player == this) continue;

                if (Functions.InRange(CurrentLocation, player.CurrentLocation, Globals.DataRange))
                    player.Enqueue(p);
            }
        }

        public abstract bool IsAttackTarget(PlayerObject attacker);
        public abstract bool IsAttackTarget(MonsterObject attacker);
        public abstract int Attacked(PlayerObject attacker, int damage, DefenceType type = DefenceType.ACAgility, bool damageWeapon = true);
        public abstract int Attacked(MonsterObject attacker, int damage, DefenceType type = DefenceType.ACAgility);
        public abstract bool IsFriendlyTarget(PlayerObject ally);

        public abstract void ReceiveChat(string text, ChatType type);

        public abstract Packet GetInfo();

        public virtual void WinExp(uint experience)
        {


        }

        public virtual bool CanGainGold(uint gold)
        {
            return false;
        }
        public virtual void WinGold(uint gold)
        {

        }

        public virtual bool Harvest(PlayerObject player) { return false; }

        public abstract void ApplyPoison(Poison p);
        public virtual void AddBuff(Buff b)
        {

            switch (b.Type)
            {
                case BuffType.Hiding:
                    Hidden = true;

                    for (int y = CurrentLocation.Y - Globals.DataRange; y <= CurrentLocation.Y + Globals.DataRange; y++)
                    {
                        if (y < 0) continue;
                        if (y >= CurrentMap.Height) break;

                        for (int x = CurrentLocation.X - Globals.DataRange; x <= CurrentLocation.X + Globals.DataRange; x++)
                        {
                            if (x < 0) continue;
                            if (x >= CurrentMap.Width) break;
                            if (x < 0 || x >= CurrentMap.Width) continue;

                            Cell cell = CurrentMap.GetCell(x, y);

                            if (!cell.Valid || cell.Objects == null) continue;

                            for (int i = 0; i < cell.Objects.Count; i++)
                            {
                                MapObject ob = cell.Objects[i];
                                if (ob.Race != ObjectType.Monster) continue;

                                if (ob.Target == this && (!ob.CoolEye || ob.Level < Level)) ob.Target = null;
                            }
                        }
                    }
                    break;
            }


            for (int i = 0; i < Buffs.Count; i++)
            {
                if (Buffs[i].Type != b.Type) continue;

                Buffs[i] = b;
                return;
            }

            Buffs.Add(b);
        }


        public virtual bool Teleport(Map temp, Point location, bool effects = true)
        {
            if (temp == null || !temp.ValidPoint(location)) return false;

            CurrentMap.RemoveObject(this);
            if (effects) Broadcast(new S.ObjectTeleportOut {ObjectID = ObjectID});
            else Broadcast(new S.ObjectRemove {ObjectID = ObjectID});

            CurrentMap = temp;
            CurrentLocation = location;

            CurrentMap.AddObject(this);

            Broadcast(GetInfo());

            if (effects) Broadcast(new S.ObjectTeleportIn { ObjectID = ObjectID });
            
            BroadcastHealthChange();
            
            return true;
        }
        public bool TeleportRandom(int attempts, int distance)
        {
            for (int i = 0; i < attempts; i++)
            {
                Point location;

                if (distance <= 0)
                    location = new Point(Envir.Random.Next(CurrentMap.Width), Envir.Random.Next(CurrentMap.Height)); //Can adjust Random Range...
                else
                    location = new Point(CurrentLocation.X + Envir.Random.Next(-distance, distance + 1),
                                         CurrentLocation.Y + Envir.Random.Next(-distance, distance + 1));

                if (Teleport(CurrentMap, location)) return true;
            }

            return false;
        }

        public void BroadcastHealthChange()
        {
            if (Race != ObjectType.Player && Race != ObjectType.Monster) return;


            byte time = Math.Min(byte.MaxValue, (byte)Math.Max(5, (RevTime - Envir.Time) / 1000));
            Packet p = new S.ObjectHealth { ObjectID = ObjectID, Percent = PercentHealth, Expire = time };
            if (Envir.Time < RevTime)
            {
                CurrentMap.Broadcast(p, CurrentLocation);
                return;
            }

            if (Race == ObjectType.Player)
            {
                if (GroupMembers != null) //Send pet HP to group
                {
                    for (int i = 0; i < GroupMembers.Count; i++)
                    {
                        PlayerObject member = GroupMembers[i];

                        if (this == member) continue;
                        if (member.CurrentMap != CurrentMap || !Functions.InRange(member.CurrentLocation, CurrentLocation, Globals.DataRange)) continue;
                        member.Enqueue(p);
                    }
                }

                return;
            }

            if (Master != null && Master.Race == ObjectType.Player)
            {
                PlayerObject player = (PlayerObject)Master;

                player.Enqueue(p);

                if (player.GroupMembers != null) //Send pet HP to group
                {
                    for (int i = 0; i < player.GroupMembers.Count; i++)
                    {
                        PlayerObject member = player.GroupMembers[i];

                        if (player == member) continue;
                        if (member.CurrentMap != CurrentMap || !Functions.InRange(member.CurrentLocation, CurrentLocation, Globals.DataRange)) continue;
                        member.Enqueue(p);
                    }
                }
            }


            if (EXPOwner != null && EXPOwner.Race == ObjectType.Player)
            {
                PlayerObject player = (PlayerObject)EXPOwner;

                if (player.IsMember(Master)) return;
                
                player.Enqueue(p);

                if (player.GroupMembers != null)
                {
                    for (int i = 0; i < player.GroupMembers.Count; i++)
                    {
                        PlayerObject member = player.GroupMembers[i];

                        if (player == member) continue;
                        if (member.CurrentMap != CurrentMap || !Functions.InRange(member.CurrentLocation, CurrentLocation, Globals.DataRange)) continue;
                        member.Enqueue(p);
                    }
                }
            }

        }

        public abstract void Die();
        public abstract int Pushed(MirDirection dir, int distance);

        public bool IsMember(MapObject member)
        {
            if (member == this) return true;
            if (GroupMembers == null || member == null) return false;

            for (int i = 0; i < GroupMembers.Count; i++)
                if (GroupMembers[i] == member) return true;

            return false;
        }

        public abstract void SendHealth(PlayerObject player);
    }

    public class Poison
    {
        public MapObject Owner;
        public PoisonType PType;
        public int Value;
        public long Duration, Time, TickTime, TickSpeed;
    }

    public class Buff
    {
        public BuffType Type;
        public MapObject Caster;
        public long ExpireTime;
        public int Value;
    }
}
