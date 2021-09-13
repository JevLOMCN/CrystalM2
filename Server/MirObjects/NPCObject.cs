using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Server.MirDatabase;
using Server.MirEnvir;
using S = ServerPackets;

namespace Server.MirObjects
{
    public sealed class NPCObject : MapObject
    {
        public override ObjectType Race
        {
            get { return ObjectType.Merchant; }
        }

        public const string
            MainKey = "[Main]",
            BuyKey = "[Buy]",
            SellKey = "[Sell]",
            RepairKey = "[Repair]",
            SRepairKey = "[SRepair]",
            TradeKey = "[Trade]",
            BuyBackKey = "[BuyBack]",
            StorageKey = "[Storage]",
            TypeKey = "[Types]",
            ConsignKey = "[Consign]",
            MarketKey = "[Market]",
            ConsignmentsKey = "[Consignments]";

        public static Regex Regex = new Regex(@"<.*?/(.*?)>");


        public NPCInfo Info;
        private const long TurnDelay = 10000;
        public long TurnTime;

        public List<ItemInfo> Goods = new List<ItemInfo>();
        public List<int> GoodsIndex = new List<int>();
        public List<ItemType> Types = new List<ItemType>();
        public List<NPCPage> NPCSections = new List<NPCPage>();

        public override string Name
        {
            get { return Info.Name; }
            set { throw new NotSupportedException(); }
        }

        public override int CurrentMapIndex { get; set; }

        public override Point CurrentLocation
        {
            get { return Info.Location; }
            set { throw new NotSupportedException(); }
        }

        public override MirDirection Direction { get; set; }

        public override byte Level
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override uint Health
        {
            get { throw new NotSupportedException(); }
        }

        public override uint MaxHealth
        {
            get { throw new NotSupportedException(); }
        }


        public NPCObject(NPCInfo info)
        {
            Info = info;
            NameColour = Color.Lime;

            Direction = (MirDirection) Envir.Random.Next(3);
            TurnTime = Envir.Time + Envir.Random.Next(10000);
            
            if (!Directory.Exists(Settings.NPCPath)) return;


            string fileName = Path.Combine(Settings.NPCPath, info.FileName + ".txt");
            if (File.Exists(fileName))
                ParseScript(File.ReadAllLines(fileName));
            else
                SMain.Enqueue(string.Format("File Not Found: {0}, NPC: {1}", info.FileName, info.Name));
        }

        private void ParseScript(IList<string> lines)
        {
            List<string> buttons = ParseSection(lines, MainKey);

            for (int i = 0; i < buttons.Count; i++)
            {
                string section = buttons[i];

                bool match = false;
                for (int a = 0; a < NPCSections.Count; a++)
                {
                    if (NPCSections[a].Key != section) continue;
                    match = true;
                    break;

                }

                if (match) continue;

                buttons.AddRange(ParseSection(lines, section));
            }

            ParseGoods(lines);
            ParseTypes(lines);

            for (int i = 0; i < Goods.Count; i++)
                GoodsIndex.Add(Goods[i].Index);
        }


        private List<string> ParseSection(IList<string> lines, string sectionName)
        {
            List<string>
                checks = new List<string>(),
                acts = new List<string>(),
                say = new List<string>(),
                buttons = new List<string>(),
                elseSay = new List<string>(),
                elseActs = new List<string>(),
                elseButtons = new List<string>();

            List<string> currentSay = say, currentButtons = buttons;

            for (int i = 0; i < lines.Count; i++)
            {
                if (!lines[i].StartsWith(sectionName)) continue;

                for (int x = i + 1; x < lines.Count; x++)
                {
                    if (string.IsNullOrEmpty(lines[x])) continue;

                    if (lines[x].StartsWith("#"))
                    {
                        switch (lines[x].Remove(0, 1).ToUpper())
                        {
                            case "IF":
                                currentSay = checks;
                                currentButtons = null;
                                continue;
                            case "SAY":
                                currentSay = say;
                                currentButtons = buttons;
                                continue;
                            case "ACT":
                                currentSay = acts;
                                currentButtons = null;
                                continue;
                            case "ELSESAY":
                                currentSay = elseSay;
                                currentButtons = elseButtons;
                                continue;
                            case "ELSEACT":
                                currentSay = elseActs;
                                currentButtons = null;
                                continue;
                            default:
                                throw new NotImplementedException();
                        }
                    }

                    if (lines[x].StartsWith("[") && lines[x].EndsWith("]")) break;

                    if (currentButtons != null)
                    {
                        Match match = Regex.Match(lines[x]);
                        while (match.Success)
                        {
                            currentButtons.Add(string.Format("[{0}]", match.Groups[1].Captures[0].Value));
                            match = match.NextMatch();
                        }
                    }


                    currentSay.Add(lines[x].TrimEnd());
                }

                break;
            }


            NPCPage page = new NPCPage(sectionName, say, buttons, elseSay, elseButtons);

            for (int i = 0; i < checks.Count; i++)
                page.ParseCheck(checks[i]);

            for (int i = 0; i < acts.Count; i++)
                page.ParseAct(page.ActList, acts[i]);

            for (int i = 0; i < elseActs.Count; i++)
                page.ParseAct(page.ElseActList, elseActs[i]);

            NPCSections.Add(page);

            currentButtons = new List<string>();
            currentButtons.AddRange(buttons);
            currentButtons.AddRange(elseButtons);

            return currentButtons;
        }

        private void ParseTypes(IList<string> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (!lines[i].StartsWith(TypeKey)) continue;

                while (++i < lines.Count)
                {
                    if (String.IsNullOrEmpty(lines[i])) continue;

                    int index;
                    if (!int.TryParse(lines[i], out index)) return;
                    Types.Add((ItemType) index);
                }
            }
        }

        private void ParseGoods(IList<string> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (!lines[i].StartsWith(TradeKey)) continue;

                while (++i < lines.Count)
                {
                    if (String.IsNullOrEmpty(lines[i])) continue;

                    ItemInfo info = SMain.Envir.GetItemInfo(lines[i]);
                    if (info == null || Goods.Contains(info))
                    {
                        SMain.Enqueue(string.Format("Could not find Item: {0}, File: {1}", lines[i], Info.FileName));
                        continue;
                    }

                    Goods.Add(info);
                }
            }
        }


        public override void Process(DelayedAction action)
        {
            throw new NotSupportedException();
        }


        public override bool IsAttackTarget(PlayerObject attacker)
        {
            throw new NotSupportedException();
        }
        public override bool IsFriendlyTarget(PlayerObject ally)
        {
            throw new NotSupportedException();
        }
        public override bool IsAttackTarget(MonsterObject attacker)
        {
            throw new NotSupportedException();
        }

        public override int Attacked(PlayerObject attacker, int damage, DefenceType type = DefenceType.ACAgility, bool damageWeapon = true)
        {
            throw new NotSupportedException();
        }

        public override int Attacked(MonsterObject attacker, int damage, DefenceType type = DefenceType.ACAgility)
        {
            throw new NotSupportedException();
        }

        public override void SendHealth(PlayerObject player)
        {
            throw new NotSupportedException();
        }

        public override void Die()
        {
            throw new NotSupportedException();
        }

        public override int Pushed(MirDirection dir, int distance)
        {
            throw new NotSupportedException();
        }

        public override void ReceiveChat(string text, ChatType type)
        {
            throw new NotSupportedException();
        }


        public override void Process()
        {
            base.Process();

            if (Envir.Time < TurnTime) return;

            TurnTime = Envir.Time + TurnDelay;
            Turn((MirDirection) Envir.Random.Next(3));
        }

        public override void SetOperateTime()
        {
            long time = Envir.Time + 2000;

            if (TurnTime < time && TurnTime > Envir.Time)
                time = TurnTime;

            if (OwnerTime < time && OwnerTime > Envir.Time)
                time = OwnerTime;

            if (ExpireTime < time && ExpireTime > Envir.Time)
                time = ExpireTime;

            if (PKPointTime < time && PKPointTime > Envir.Time)
                time = PKPointTime;

            if (LastHitTime < time && LastHitTime > Envir.Time)
                time = LastHitTime;

            if (EXPOwnerTime < time && EXPOwnerTime > Envir.Time)
                time = EXPOwnerTime;

            if (BrownTime < time && BrownTime > Envir.Time)
                time = BrownTime;

            for (int i = 0; i < ActionList.Count; i++)
            {
                if (ActionList[i].Time >= time && ActionList[i].Time > Envir.Time) continue;
                time = ActionList[i].Time;
            }

            for (int i = 0; i < PoisonList.Count; i++)
            {
                if (PoisonList[i].TickTime >= time && PoisonList[i].TickTime > Envir.Time) continue;
                time = PoisonList[i].TickTime;
            }

            for (int i = 0; i < Buffs.Count; i++)
            {
                if (Buffs[i].ExpireTime >= time && Buffs[i].ExpireTime > Envir.Time) continue;
                time = Buffs[i].ExpireTime;
            }


            if (OperateTime <= Envir.Time || time < OperateTime)
                OperateTime = time;
        }

        public void Turn(MirDirection dir)
        {
            Direction = dir;

            Broadcast(new S.ObjectTurn {ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation});
        }

        public override Packet GetInfo()
        {
            return new S.ObjectNPC
                {
                    ObjectID = ObjectID,
                    Name = Name,
                    NameColour = NameColour,
                    Image = Info.Image,
                    Location = CurrentLocation,
                    Direction = Direction,
                };
        }

        public override void ApplyPoison(Poison p)
        {
            throw new NotSupportedException();
        }

        public override void AddBuff(Buff b)
        {
            throw new NotSupportedException();
        }

        public void Call(PlayerObject player, string key)
        {
            if (key != MainKey)
            {
                if (player.NPCID != ObjectID) return;

                if (player.NPCSuccess)
                {
                    if (!player.NPCPage.Buttons.Contains(key)) return;
                }
                else
                {
                    if (!player.NPCPage.ElseButtons.Contains(key)) return;
                }
            }

            for (int i = 0; i < NPCSections.Count; i++)
            {
                NPCPage page = NPCSections[i];
                if (page.Key != key) continue;

                ProcessPage(player, page);
            }


        }

        public void Buy(PlayerObject player, int index, uint count)
        {
            ItemInfo info = null;

            for (int i = 0; i < Goods.Count; i++)
            {
                if (Goods[i].Index != index) continue;
                info = Goods[i];
                break;
            }

            if (count == 0 || info == null || count > info.StackSize) return;

            uint cost = info.Price*count;
            cost = (uint) (cost*Info.PriceRate);

            if (cost > player.Account.Gold) return;

            UserItem item = Envir.CreateFreshItem(info);
            item.Count = count;

            if (!player.CanGainItem(item)) return;

            player.Account.Gold -= cost;
            player.Enqueue(new S.LoseGold {Gold = cost});
            player.GainItem(item);
        }
        public void Sell(UserItem item)
        {
            /* Handle Item Sale */


        }

        private void ProcessPage(PlayerObject player, NPCPage page)
        {
            player.NPCID = ObjectID;
            player.NPCPage = page;
            player.NPCSuccess = page.Check(player);


            switch (page.Key)
            {
                case BuyKey:
                    for (int i = 0; i < Goods.Count; i++)
                        player.CheckItemInfo(Goods[i]);

                    player.Enqueue(new S.NPCGoods {List = GoodsIndex, Rate = Info.PriceRate});
                    break;
                case SellKey:
                    player.Enqueue(new S.NPCSell());
                    break;
                case RepairKey:
                    player.Enqueue(new S.NPCRepair { Rate = Info.PriceRate });
                    break;
                case SRepairKey:
                    player.Enqueue(new S.NPCSRepair { Rate = Info.PriceRate });
                    break;
                case StorageKey:
                    player.SendStorage();
                    player.Enqueue(new S.NPCStorage());
                    break;
                case BuyBackKey:
                    break;
                case ConsignKey:
                    player.Enqueue(new S.NPCConsign());
                    break;
                case MarketKey:
                    player.UserMatch = false;
                    player.GetMarket(string.Empty, ItemType.Nothing);
                    break;
                case ConsignmentsKey:
                    player.UserMatch = true;
                    player.GetMarket(string.Empty, ItemType.Nothing);
                    break;
            }

        }
    }

    public class NPCPage
    {
        public readonly string Key;
        public List<NPCChecks> CheckList = new List<NPCChecks>();
        public List<NPCActions> ActList = new List<NPCActions>(), ElseActList = new List<NPCActions>();
        public readonly List<string> Say, ElseSay, Buttons, ElseButtons;

        public NPCPage(string key, List<string> say, List<string> buttons, List<string> elseSay, List<string> elseButtons)
        {
            Key = key;

            Say = say;
            Buttons = buttons;

            ElseSay = elseSay;
            ElseButtons = elseButtons;

        }

        public void ParseCheck(string line)
        {
            string[] parts = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0) return;

            int temp;
            uint temp2;
            switch (parts[0].ToUpper())
            {
                case "MINLEVEL":
                    if (parts.Length < 2) return;
                    if (!int.TryParse(parts[1], out temp)) return;
                    CheckList.Add(new NPCChecks(CheckType.MinLevel, temp));
                    break;
                case "MAXLEVEL":
                    if (parts.Length < 2) return;
                    if (!int.TryParse(parts[1], out temp)) return;
                    CheckList.Add(new NPCChecks(CheckType.MaxLevel, temp));
                    break;
                case "CHECKGOLD":
                    if (parts.Length < 2) return;

                    if (!uint.TryParse(parts[1], out temp2)) return;
                    CheckList.Add(new NPCChecks(CheckType.CheckGold, temp2));
                    break;
                case "CHECKITEM":
                    if (parts.Length < 2) return;
                    ItemInfo info = SMain.Envir.GetItemInfo(parts[1]);

                    if (info == null)
                    {
                        SMain.Enqueue(string.Format("Failed to get ItemInfo: {0}, Page: {1}", parts[1], Key));
                        break;
                    }

                    if (parts.Length < 3 || !uint.TryParse(parts[1], out temp2)) temp2 = 1;
                    CheckList.Add(new NPCChecks(CheckType.CheckGold, info, temp2));
                    break;
            }

        }


        public void ParseAct(List<NPCActions> acts, string line)
        {
            string[] parts = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0) return;

            ItemInfo info;
            uint temp;
            switch (parts[0].ToUpper())
            {
                case "MOVE":
                    int map, x, y;
                    if (parts.Length < 4) return;
                    if (!int.TryParse(parts[1], out map)) return;
                    if (!int.TryParse(parts[2], out x)) return;
                    if (!int.TryParse(parts[3], out y)) return;
                    acts.Add(new NPCActions(ActionType.Teleport, map, new Point(x, y)));
                    return;
                case "GIVEGOLD":
                    if (parts.Length < 2) return;
                    if (!uint.TryParse(parts[1], out temp)) return;
                    acts.Add(new NPCActions(ActionType.GiveGold, temp));
                    return;
                case "TAKEGOLD":
                    if (parts.Length < 2) return;
                    if (!uint.TryParse(parts[1], out temp)) return;
                    acts.Add(new NPCActions(ActionType.TakeGold, temp));
                    return;
                case "GIVEITEM":
                    if (parts.Length < 2) return;
                    info = SMain.Envir.GetItemInfo(parts[1]);

                    if (info == null)
                    {
                        SMain.Enqueue(string.Format("Failed to get ItemInfo: {0}, Page: {1}", parts[1], Key));
                        break;
                    }

                    if (parts.Length < 3 || !uint.TryParse(parts[2], out temp)) temp = 1;
                    acts.Add(new NPCActions(ActionType.GiveItem, info, temp));
                    return;
                case "TAKEITEM":
                    if (parts.Length < 3) return;
                    info = SMain.Envir.GetItemInfo(parts[1]);

                    if (info == null)
                    {
                        SMain.Enqueue(string.Format("Failed to get ItemInfo: {0}, Page: {1}", parts[1], Key));
                        break;
                    }

                    if (parts.Length < 3 || !uint.TryParse(parts[2], out temp)) temp = 1;
                    acts.Add(new NPCActions(ActionType.TakeItem, info, temp));
                    return;

            }

        }


        public bool Check(PlayerObject player)
        {
            for (int i = 0; i < CheckList.Count; i++)
            {
                NPCChecks check = CheckList[i];
                switch (check.Type)
                {
                    case CheckType.MaxLevel:
                        if (player.Level > (byte) check.Params[0])
                        {
                            Failed(player);
                            return false;
                        }
                        break;
                    case CheckType.MinLevel:
                        if (player.Level < (byte) check.Params[0])
                        {
                            Failed(player);
                            return false;
                        }
                        break;
                    case CheckType.CheckGold:
                        if (player.Account.Gold < (uint) check.Params[0])
                        {
                            Failed(player);
                            return false;
                        }
                        break;
                    case CheckType.CheckItem:

                        ItemInfo info = SMain.Envir.GetItemInfo((string) check.Params[0]);

                        if (info == null)
                        {
                            SMain.Enqueue(string.Format("Failed to get ItemInfo: {0}, Page: {1}", check.Params[0], Key));
                            Failed(player);
                            return false;
                        }

                        uint count = (uint) check.Params[1];

                        for (int o = 0; o < player.Info.Inventory.Length; o++)
                        {
                            UserItem item = player.Info.Inventory[o];
                            if (item.Info != info) continue;

                            if (count > item.Count)
                            {
                                count -= item.Count;
                                continue;
                            }

                            break;
                        }
                        if (count > 0)
                        {

                            Failed(player);
                            return false;
                        }

                        break;
                }
            }

            Success(player);
            return true;

        }

        private void Success(PlayerObject player)
        {
            Act(ActList, player);
            player.Enqueue(new S.NPCResponse {Page = Say});
        }

        private void Failed(PlayerObject player)
        {
            Act(ElseActList, player);
            player.Enqueue(new S.NPCResponse {Page = ElseSay});
        }

        private void Act(List<NPCActions> acts, PlayerObject player)
        {
            for (int i = 0; i < acts.Count; i++)
            {
                NPCActions act = acts[i];
                uint gold;
                uint count;
                switch (act.Type)
                {
                    case ActionType.Teleport:
                        Map temp = SMain.Envir.GetMap((int) act.Params[0]);
                        if (temp == null) return;
                        player.Teleport(temp, (Point) act.Params[1]);
                        break;
                    case ActionType.GiveGold:
                        gold = (uint)act.Params[0];

                        if (gold + player.Account.Gold >= uint.MaxValue)
                            gold = uint.MaxValue - player.Account.Gold;

                            player.GainGold(gold);
                        break;
                    case ActionType.TakeGold:
                        gold = (uint) act.Params[0];

                        if (gold >= player.Account.Gold) gold = player.Account.Gold;

                        player.Account.Gold -= gold;
                        player.Enqueue(new S.LoseGold { Gold = gold });
                        break;
                    case ActionType.GiveItem:
                        count = (uint)act.Params[1];

                        while (count > 0)
                        {
                            UserItem item = SMain.Envir.CreateFreshItem((ItemInfo)act.Params[0]);

                            if (item == null)
                            {
                                SMain.Enqueue(string.Format("Failed to create UserItem: {0}, Page: {1}", act.Params[0], Key));
                                return;
                            }
                            
                            if (item.Info.StackSize > count)
                            {
                                item.Count = count;
                                count = 0;
                            }
                            else
                            {
                                count -= item.Info.StackSize;
                                item.Count = item.Info.StackSize;
                            }

                            if (player.CanGainItem(item, false))
                                player.GainItem(item);
                        } 

                        break;
                    case ActionType.TakeItem:
                        ItemInfo info = (ItemInfo) act.Params[0];


                        count = (uint) act.Params[1];

                        for (int o = 0; o < player.Info.Inventory.Length; o++)
                        {
                            UserItem item = player.Info.Inventory[o];
                            if (item.Info != info) continue;
                            
                            if (count > item.Count)
                            {
                                player.Enqueue(new S.DeleteItem {UniqueID = item.UniqueID, Count = item.Count});
                                player.Info.Inventory[o] = null;

                                count -= item.Count;
                                continue;
                            }

                            player.Enqueue(new S.DeleteItem { UniqueID = item.UniqueID, Count = count });
                            if (count == item.Count)
                                player.Info.Inventory[o] = null;
                            else
                                item.Count -= count;
                            break;
                        }
                        player.RefreshStats();

                        break;
                }
            }
        }
    }

    public class NPCChecks
    {
        public CheckType Type;
        public List<object> Params = new List<object>();

        public NPCChecks(CheckType check, params object[] p)
        {
            Type = check;

            for (int i = 0; i < p.Length; i++)
                Params.Add(p[i]);
        }
    }

    public class NPCActions
    {
        public ActionType Type;
        public List<object> Params = new List<object>();

        public NPCActions(ActionType action, params object[] p)
        {
            Type = action;

            Params.AddRange(p);
        }
    }

    public enum ActionType
    {
        Teleport,
        GiveGold,
        TakeGold,
        GiveItem,
        TakeItem
    }

    public enum CheckType
    {
        MinLevel,
        MaxLevel,
        CheckItem,
        CheckGold,
    }
}