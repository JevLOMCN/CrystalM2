using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Client.MirGraphics;
using Client.MirScenes;
using Client.MirSounds;
using S = ServerPackets;

namespace Client.MirObjects
{
    class MonsterObject : MapObject
    {
        public override ObjectType Race
        {
            get { return ObjectType.Monster; }
        }
        public override bool Blocking
        {
            get { return !Dead; }
        }

        public Monster BaseImage;
        public byte Effect;
        public bool Skeleton;
        
        public FrameSet Frames;
        public Frame Frame;
        public int FrameIndex, FrameInterval;

        public uint TargetID;
        public Point TargetPoint;

        public bool Stoned;
        public int BaseSound;

        public MonsterObject(uint objectID) : base(objectID)
        {
        }
        public void Load(S.ObjectMonster info)
        {
            Name = info.Name;
            NameColour = info.NameColour;
            BaseImage = info.Image;

            CurrentLocation = info.Location;
            MapLocation = info.Location;
            GameScene.Scene.MapControl.AddObject(this);



            Effect = info.Effect;
            AI = info.AI;
            Light = info.Light;

            Direction = info.Direction;
            Dead = info.Dead;
            Poison = info.Poison;
            Skeleton = info.Skeleton;
            Hidden = info.Hidden;

            if ((ushort)BaseImage < Libraries.Monsters.Length)
                BodyLibrary = Libraries.Monsters[(ushort)BaseImage];
            
            if (Skeleton)
                ActionFeed.Add(new QueuedAction { Action = MirAction.Skeleton, Direction = Direction, Location = CurrentLocation });
            else if (Dead)
                ActionFeed.Add(new QueuedAction { Action = MirAction.Dead, Direction = Direction, Location = CurrentLocation });

            BaseSound = (ushort)BaseImage * 10;

            switch (BaseImage)
            {
                case Monster.Guard: 
                case Monster.Guard1: 
                case Monster.Guard2: 
                    Frames = FrameSet.Monsters[0];
                    break;
                case Monster.Hen: 
                case Monster.Deer: 
                    Frames = FrameSet.Monsters[1];
                    break;
                case Monster.Scarecrow:
                case Monster.HookingCat:
                case Monster.RakingCat:
                case Monster.Yob:
                case Monster.Oma:
                case Monster.SpittingSpider:
                case Monster.OmaFighter:
                case Monster.OmaWarrior:
                case Monster.CaveBat:
                case Monster.Skeleton:
                case Monster.BoneFighter:
                case Monster.AxeSkeleton:
                case Monster.BoneWarrior:
                case Monster.BoneElite:
                case Monster.Dung:
                case Monster.Dark:
                case Monster.WoomaSoldier:
                case Monster.WoomaFighter:
                case Monster.WoomaWarrior:
                case Monster.FlamingWooma:
                case Monster.WoomaGuardian:
                case Monster.WoomaTaurus:
                case Monster.WhimperingBee:
                case Monster.GiantWorm:
                case Monster.Centipede:
                case Monster.BlackMaggot:
                case Monster.Tongs:
                case Monster.EvilTongs:
                case Monster.ButBat:
                case Monster.WedgeMoth:
                case Monster.RedBoar:
                case Monster.BlackBoar:
                case Monster.SnakeScorpion:
                case Monster.WhiteBoar:
                case Monster.EvilSnake:
                case Monster.SpiderBat:
                case Monster.VenomSpider:
                case Monster.GangSpider:
                case Monster.GreatSpider:
                case Monster.LureSpider:
                case Monster.BigApe:
                case Monster.EvilApe:
                case Monster.GrayEvilApe:
                case Monster.RedEvilApe:
                case Monster.BigRat:
                case Monster.ZumaArcher:
                case Monster.Ghoul:
                case Monster.KingHog:
                case Monster.Shinsu1:
                    Frames = FrameSet.Monsters[2];
                    break;
                case Monster.CannibalPlant:
                    Frames = FrameSet.Monsters[3];
                    break;
                case Monster.ForestYeti:
                case Monster.CaveMaggot:
                    Frames = FrameSet.Monsters[4];
                    break;
                case Monster.Scorpion:
                    Frames = FrameSet.Monsters[5];
                    break;
                case Monster.ChestnutTree: 
                case Monster.EbonyTree: 
                case Monster.LargeMushroom:
                case Monster.CherryTree:
                    Frames = FrameSet.Monsters[6];
                    break;
                case Monster.EvilCentipede:
                    Frames = FrameSet.Monsters[7];
                    break;
                case Monster.BugBatMaggot:
                    Frames = FrameSet.Monsters[8];
                    break;
               /* case Monster.BombSpider:
                    Frames = FrameSet.Monsters[9];
                    break;
                case Monster.RootSpider:
                    Frames = FrameSet.Monsters[8];
                    break;*/
                case Monster.CrystalSpider:
                    Frames = FrameSet.Monsters[9];
                    break;
                case Monster.RedMoonEvil:
                    Frames = FrameSet.Monsters[10];
                    break;
                case Monster.ZumaStatue:
                case Monster.ZumaGuardian:
                    Stoned = info.Extra;
                    Frames = FrameSet.Monsters[11];
                    break;
                case Monster.ZumaTaurus:
                    Stoned = info.Extra;
                    Frames = FrameSet.Monsters[12];
                    break;
                case Monster.RedThunderZuma:
                    Stoned = info.Extra;
                    Frames = FrameSet.Monsters[13];
                    break;
                case Monster.KingScorpion:
                case Monster.DarkDevil:
                    Frames = FrameSet.Monsters[14];
                    break;
                case Monster.BoneFamiliar:
                    Frames = FrameSet.Monsters[15];
                    if (!info.Extra) ActionFeed.Add(new QueuedAction { Action = MirAction.Appear, Direction = Direction, Location = CurrentLocation });
                    break;
                case Monster.Shinsu:
                    Frames = FrameSet.Monsters[16];
                    if (!info.Extra) ActionFeed.Add(new QueuedAction { Action = MirAction.Appear, Direction = Direction, Location = CurrentLocation });
                    break;
                default:
                    Frames = FrameSet.Monsters[0];
                    break;
            }


            SetAction();

            if (CurrentAction == MirAction.Standing)
            {
                PlayAppearSound();
                FrameIndex = CMain.Random.Next(Frame.Count);
            }

            NextMotion -= NextMotion % 100;
        }



        public override void Process()
        {
            bool update = CMain.Time >= NextMotion || GameScene.CanMove;
            SkipFrames = ActionFeed.Count > 1;

            ProcessFrames();

            if (Frame == null)
                DrawFrame = 0;
            else
                DrawFrame = Frame.Start + (Frame.OffSet * (byte)Direction) + FrameIndex;


            #region Moving OffSet

            switch (CurrentAction)
            {
                case MirAction.Walking:
                case MirAction.Running:
                case MirAction.Pushed:
                case MirAction.DashL:
                case MirAction.DashR:
                    if (Frame == null)
                    {
                        OffSetMove = Point.Empty;
                        Movement = CurrentLocation;
                        break;
                    }
                    int i = CurrentAction == MirAction.Running ? 2 : 1;

                    Movement = Functions.PointMove(CurrentLocation, Direction, CurrentAction == MirAction.Pushed ? 0 : -i);

                    int count = Frame.Count;
                    int index = FrameIndex;

                    if (CurrentAction == MirAction.DashR || CurrentAction == MirAction.DashL)
                    {
                        count = 3;
                        index %= 3;
                    }

                    switch (Direction)
                    {
                        case MirDirection.Up:
                            OffSetMove = new Point(0, (int)((MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.UpRight:
                            OffSetMove = new Point((int)((-MapControl.CellWidth * i / (float)(count)) * (index + 1)), (int)((MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.Right:
                            OffSetMove = new Point((int)((-MapControl.CellWidth * i / (float)(count)) * (index + 1)), 0);
                            break;
                        case MirDirection.DownRight:
                            OffSetMove = new Point((int)((-MapControl.CellWidth * i / (float)(count)) * (index + 1)), (int)((-MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.Down:
                            OffSetMove = new Point(0, (int)((-MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.DownLeft:
                            OffSetMove = new Point((int)((MapControl.CellWidth * i / (float)(count)) * (index + 1)), (int)((-MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                        case MirDirection.Left:
                            OffSetMove = new Point((int)((MapControl.CellWidth * i / (float)(count)) * (index + 1)), 0);
                            break;
                        case MirDirection.UpLeft:
                            OffSetMove = new Point((int)((MapControl.CellWidth * i / (float)(count)) * (index + 1)), (int)((MapControl.CellHeight * i / (float)(count)) * (index + 1)));
                            break;
                    }

                    OffSetMove = new Point(OffSetMove.X % 2 + OffSetMove.X, OffSetMove.Y % 2 + OffSetMove.Y);
                    break;
                default:
                    OffSetMove = Point.Empty;
                    Movement = CurrentLocation;
                    break;
            }

            #endregion


            DrawY = Movement.Y > CurrentLocation.Y ? Movement.Y : CurrentLocation.Y;

            DrawLocation = new Point((Movement.X - User.Movement.X + MapControl.OffSetX) * MapControl.CellWidth, (Movement.Y - User.Movement.Y + MapControl.OffSetY) * MapControl.CellHeight);
            DrawLocation.Offset(-OffSetMove.X, -OffSetMove.Y);
            DrawLocation.Offset(User.OffSetMove);

            if (BodyLibrary != null && update)
            {
                FinalDrawLocation = DrawLocation.Add(BodyLibrary.GetOffSet(DrawFrame));
                DisplayRectangle = new Rectangle(DrawLocation, BodyLibrary.GetTrueSize(DrawFrame));
            }

            for (int i = 0; i < Effects.Count; i++)
                Effects[i].Process();

            Color colour = DrawColour;

            switch (Poison)
            {
                case PoisonType.None:
                    DrawColour = Color.White;
                    break;
                case PoisonType.Green:
                    DrawColour = Color.Green;
                    break;
                case PoisonType.Red:
                    DrawColour = Color.Red;
                    break;
                case PoisonType.Slow:
                    DrawColour = Color.Purple;
                    break;
                case PoisonType.Stun:
                    DrawColour = Color.Yellow;
                    break;
                case PoisonType.Frozen:
                    DrawColour = Color.Blue;
                    break;
                case PoisonType.Paralysis:
                    DrawColour = Color.Gray;
                    break;
            }


            if (colour != DrawColour) GameScene.Scene.MapControl.TextureValid = false;
        }

        public bool SetAction()
        {
            if (NextAction != null && !GameScene.CanMove)
            {
                switch (NextAction.Action)
                {
                    case MirAction.Walking:
                    case MirAction.Pushed:
                        return false;
                }
            }

            if (ActionFeed.Count == 0)
            {
                CurrentAction = Stoned ? MirAction.Stoned : MirAction.Standing;

                Frames.Frames.TryGetValue(CurrentAction, out Frame);

                if (MapLocation != CurrentLocation)
                {
                    GameScene.Scene.MapControl.RemoveObject(this);
                    MapLocation = CurrentLocation;
                    GameScene.Scene.MapControl.AddObject(this);
                }

                FrameIndex = 0;

                if (Frame == null) return false;

                FrameInterval = Frame.Interval;
            }
            else
            {
                QueuedAction action = ActionFeed[0];
                ActionFeed.RemoveAt(0);

                CurrentAction = action.Action;
                CurrentLocation = action.Location;
                Direction = action.Direction;

                Point temp;
                switch (CurrentAction)
                {
                    case MirAction.Walking:
                    case MirAction.Pushed:
                        int i = CurrentAction == MirAction.Running ? 2 : 1;
                        temp = Functions.PointMove(CurrentLocation, Direction, CurrentAction == MirAction.Pushed ? 0 : -i);
                        break;
                    default:
                        temp = CurrentLocation;
                        break;
                }

                temp = new Point(action.Location.X, temp.Y > CurrentLocation.Y ? temp.Y : CurrentLocation.Y);

                if (MapLocation != temp)
                {
                    GameScene.Scene.MapControl.RemoveObject(this);
                    MapLocation = temp;
                    GameScene.Scene.MapControl.AddObject(this);
                }


                switch (CurrentAction)
                {
                    case MirAction.Pushed:
                        Frames.Frames.TryGetValue(MirAction.Walking, out Frame);
                        break;
                    case MirAction.AttackRange:
                        if (!Frames.Frames.TryGetValue(CurrentAction, out Frame))
                            Frames.Frames.TryGetValue(MirAction.Attack1, out Frame);
                        break;
                    case MirAction.Special:
                        if (!Frames.Frames.TryGetValue(CurrentAction, out Frame))
                            Frames.Frames.TryGetValue(MirAction.Attack1, out Frame);
                        break;
                    case MirAction.Skeleton:
                        if (!Frames.Frames.TryGetValue(CurrentAction, out Frame))
                            Frames.Frames.TryGetValue(MirAction.Dead, out Frame);
                        break;
                    case MirAction.Hide:
                        switch (BaseImage)
                        {
                            case Monster.Shinsu1:
                                BodyLibrary = Libraries.Monsters[(ushort) Monster.Shinsu];
                                BaseImage = Monster.Shinsu;
                                BaseSound = (ushort) BaseImage*10;
                                Frames = FrameSet.Monsters[16];
                                Frames.Frames.TryGetValue(CurrentAction, out Frame);
                                break;
                            default:
                                Frames.Frames.TryGetValue(CurrentAction, out Frame);
                                break;
                        }
                        break;
                        case MirAction.Dead:
                        switch (BaseImage)
                        {
                            case Monster.Shinsu:
                            case Monster.Shinsu1:
                                Remove();
                                return false;
                            default:
                                Frames.Frames.TryGetValue(CurrentAction, out Frame);
                                break;                
                        }
                        break;
                    default:
                        Frames.Frames.TryGetValue(CurrentAction, out Frame);
                        break;

                }

                FrameIndex =  0;

                if (Frame == null) return false;


                FrameInterval = Frame.Interval;
                

                switch (CurrentAction)
                {
                    case MirAction.Appear:
                        PlaySummonSound();
                        break;
                    case MirAction.Show:
                        PlayPopupSound();
                        break;
                    case MirAction.Pushed:
                        FrameIndex = Frame.Count - 1;
                        GameScene.Scene.Redraw();
                        break;
                    case MirAction.Walking:
                        GameScene.Scene.Redraw();
                        break;
                    case MirAction.Attack1:
                        PlayAttackSound();
                        switch (BaseImage)
                        {
                            case Monster.FlamingWooma:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort) Monster.FlamingWooma], 224 + (int) Direction*7, 7, Frame.Count*Frame.Interval, this));
                                break;
                            case Monster.ZumaTaurus: 
                                if (CurrentAction == MirAction.Attack1)
                                    Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.ZumaTaurus], 244 + (int)Direction * 8, 8, 8 * FrameInterval, this));
                                break;
                        }
                        break;
                    case MirAction.AttackRange:
                        PlayRangeSound();
                        switch (BaseImage)
                        {
                            case Monster.CrystalSpider:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.CrystalSpider], 272 + (int)Direction * 10, 10, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.KingScorpion:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.KingScorpion], 272 + (int)Direction * 8, 8, Frame.Count * Frame.Interval, this));
                                break;
                            case Monster.DarkDevil:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkDevil], 272 + (int)Direction * 8, 8, Frame.Count * Frame.Interval, this));
                                break;
                        }
                        TargetID = (uint)action.Params[0];
                        break;

                    case MirAction.Struck:
                        uint attackerID = (uint)action.Params[0];
                        StruckWeapon = -2;
                        for (int i = 0; i < MapControl.Objects.Count; i++)
                        {
                            MapObject ob = MapControl.Objects[i];
                            if (ob.ObjectID != attackerID) continue;
                            if (ob.Race != ObjectType.Player) break;
                            PlayerObject player = ((PlayerObject) ob);
                            StruckWeapon = player.Weapon;
                            if (player.Class != MirClass.Assassin || StruckWeapon == -1) break;
                            StruckWeapon = 1;
                            break;
                        }
                        PlayFlinchSound();
                        PlayStruckSound();
                        break;
                    case MirAction.Die:
                        switch (BaseImage)
                        {
                            case Monster.DarkDevil:
                                Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.DarkDevil], 336, 6, Frame.Count * Frame.Interval, this));
                                break;
                        }
                        PlayDieSound();
                        break;
                    case MirAction.Dead:
                        GameScene.Scene.Redraw();
                        GameScene.Scene.MapControl.SortObject(this);
                        if (MouseObject == this) MouseObject = null;
                        if (TargetObject == this) TargetObject = null;
                        if (MagicObject == this) MagicObject = null;
                        DeadTime = CMain.Time;
                        break;
                }

            }

            GameScene.Scene.MapControl.TextureValid = false;

            NextMotion = CMain.Time + FrameInterval;

            return true;
        }


        private void ProcessFrames()
        {
            if (Frame == null) return;

            switch (CurrentAction)
            {
                case MirAction.Walking:
                    if (!GameScene.CanMove) return;

                    GameScene.Scene.MapControl.TextureValid = false;

                    if (SkipFrames) UpdateFrame();

                    if (UpdateFrame() >= Frame.Count)
                    {
                        FrameIndex = Frame.Count - 1;
                        SetAction();
                    }

                    break;
                case MirAction.Pushed:
                    if (!GameScene.CanMove) return;

                    GameScene.Scene.MapControl.TextureValid = false;

                    FrameIndex -= 2;

                    if (FrameIndex < 0)
                    {
                        FrameIndex = 0;
                        SetAction();
                    }
                    break;
                case MirAction.Show:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;
                        
                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            switch (BaseImage)
                            {
                                case Monster.ZumaStatue:
                                case Monster.ZumaGuardian:
                                case Monster.RedThunderZuma:
                                case Monster.ZumaTaurus:
                                    Stoned = false;
                                    break;
                                case Monster.Shinsu:
                                    BodyLibrary = Libraries.Monsters[(ushort)Monster.Shinsu1];
                                    BaseImage = Monster.Shinsu1;
                                    BaseSound = (ushort)BaseImage * 10;
                                    Frames = FrameSet.Monsters[2];
                                    break;
                            }

                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Hide:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            switch (BaseImage)
                            {

                                case Monster.CannibalPlant:
                                case Monster.EvilCentipede:
                                    Remove();
                                    return;
                                case Monster.ZumaStatue:
                                case Monster.ZumaGuardian:
                                case Monster.RedThunderZuma:
                                case Monster.ZumaTaurus:
                                    Stoned = true;
                                    return;
                            }


                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Appear:
                case MirAction.Standing:
                case MirAction.Stoned:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Attack1:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                           if (SetAction())
                           {
                               switch (BaseImage)
                               {
                                   case Monster.EvilCentipede:
                                       Effects.Add(new Effect(Libraries.Monsters[(ushort)Monster.EvilCentipede], 42, 10, 600, this));
                                       break;
                               }

                           }
                        }
                        else
                        {
                            if (FrameIndex == 3) PlaySwingSound();
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.AttackRange:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            if (FrameIndex == 2) PlaySwingSound();

                            if (FrameIndex == 4)
                            {
                                switch (BaseImage)
                                {
                                    case Monster.AxeSkeleton:
                                        if (MapControl.GetObject(TargetID) != null)
                                            CreateProjectile(224, Libraries.Monsters[(ushort)Monster.AxeSkeleton], false, 3, 30, 0);
                                        break;
                                    case Monster.Dark:
                                        if (MapControl.GetObject(TargetID) != null)
                                            CreateProjectile(224, Libraries.Monsters[(ushort)Monster.Dark], false, 3, 30, 0);
                                        break;
                                    case Monster.ZumaArcher:
                                        if (MapControl.GetObject(TargetID) != null)
                                            CreateProjectile(224, Libraries.Monsters[(ushort)Monster.ZumaArcher], false, 1, 30, 0);
                                        break;
                                    case Monster.RedThunderZuma:
                                        MapObject ob = MapControl.GetObject(TargetID);
                                        if (ob != null)
                                        {
                                            ob.Effects.Add(new Effect(Libraries.Dragon, 400 + CMain.Random.Next(3) * 10, 5, 300, ob));
                                            SoundManager.PlaySound(BaseSound + 6);
                                        }
                                        break;
                                }
                            }
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Struck:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            SetAction();
                        }
                        else
                        {
                            NextMotion += FrameInterval;
                        }
                    }
                    break;

                case MirAction.Die:
                    if (CMain.Time >= NextMotion)
                    {
                        GameScene.Scene.MapControl.TextureValid = false;

                        if (SkipFrames) UpdateFrame();

                        if (UpdateFrame() >= Frame.Count)
                        {
                            FrameIndex = Frame.Count - 1;
                            ActionFeed.Clear();
                            ActionFeed.Add(new QueuedAction { Action = MirAction.Dead, Direction = Direction, Location = CurrentLocation });
                            SetAction();
                        }
                        else
                        {
                            if (FrameIndex == 3) 
                                PlayDeadSound();
                            NextMotion += FrameInterval;
                        }
                    }
                    break;
                case MirAction.Dead:
                    break;

            }

            if (CurrentAction == MirAction.Standing && NextAction != null)
                SetAction();
            else if (CurrentAction == MirAction.Dead && NextAction != null && NextAction.Action == MirAction.Skeleton)
                SetAction();
        }
        public int UpdateFrame()
        {
            if (Frame == null) return 0;

            if (Frame.Reverse) return Math.Abs(--FrameIndex);

            return ++FrameIndex;
        }


        private Missile CreateProjectile(int baseIndex, MLibrary library, bool blend, int count, int interval, int skip)
        {
            MapObject ob = MapControl.GetObject(TargetID);

            if (ob != null) TargetPoint = ob.CurrentLocation;

            int duration = Functions.MaxDistance(CurrentLocation, TargetPoint) * 50;


            Missile missile = new Missile(library, baseIndex, duration / interval, duration, this, TargetPoint)
            {
                Target = ob,
                Interval = interval,
                FrameCount = count,
                Blend = blend,
                Skip = skip
            };

            Effects.Add(missile);

            return missile;
        }

        private void PlaySummonSound()
        {
            switch (BaseImage)
            {
                case Monster.BoneFamiliar:
                case Monster.Shinsu:
                    SoundManager.PlaySound(BaseSound + 5);
                    return;
            }
        }
        public void PlayAppearSound()
        {
            switch (BaseImage)
            {
                case Monster.CannibalPlant:
                case Monster.EvilCentipede:
                    return;
                case Monster.ZumaArcher:
                case Monster.ZumaStatue:
                case Monster.ZumaGuardian:
                case Monster.RedThunderZuma:
                case Monster.ZumaTaurus:
                    if (Stoned) return;
                    break;
            }
            SoundManager.PlaySound(BaseSound);
        }
        public void PlayPopupSound()
        {
            switch (BaseImage)
            {
                case Monster.ZumaTaurus:
                    SoundManager.PlaySound(BaseSound + 5);
                    return;
                case Monster.Shinsu:
                    SoundManager.PlaySound(BaseSound + 6);
                    return;
            }
            SoundManager.PlaySound(BaseSound);
        }
        public void PlayFlinchSound()
        {
            SoundManager.PlaySound(BaseSound + 2);
        }
        public void PlayStruckSound()
        {
            switch (StruckWeapon)
            {
                case 0:
                case 23:
                case 28:
                case 40:
                    SoundManager.PlaySound(SoundList.StruckWooden);
                    break;
                case 1:
                case 12:
                    SoundManager.PlaySound(SoundList.StruckShort);
                    break;
                case 2:
                case 8:
                case 11:
                case 15:
                case 18:
                case 20:
                case 25:
                case 31:
                case 33:
                case 34:
                case 37:
                case 41:
                    SoundManager.PlaySound(SoundList.StruckSword);
                    break;
                case 3:
                case 5:
                case 7:
                case 9:
                case 13:
                case 19:
                case 24:
                case 26:
                case 29:
                case 32:
                case 35:
                    SoundManager.PlaySound(SoundList.StruckSword2);
                    break;
                case 4:
                case 14:
                case 16:
                case 38:
                    SoundManager.PlaySound(SoundList.StruckAxe);
                    break;
                case 6:
                case 10:
                case 17:
                case 22:
                case 27:
                case 30:
                case 36:
                case 39:
                    SoundManager.PlaySound(SoundList.StruckShort);
                    break;
                case 21:
                    SoundManager.PlaySound(SoundList.StruckClub);
                    break;
            }
        }
        public void PlayAttackSound()
        {
            SoundManager.PlaySound(BaseSound + 1);
        }
        public void PlaySwingSound()
        {
            SoundManager.PlaySound(BaseSound + 4);
        }
        public void PlayDieSound()
        {
            SoundManager.PlaySound(BaseSound + 3);
        }
        public void PlayDeadSound()
        {
            switch (BaseImage)
            {
                case Monster.CaveBat:
                    SoundManager.PlaySound(BaseSound + 5);
                    break;
            }
        }
        public void PlayRangeSound()
        {
            switch (BaseImage)
            {
                case Monster.CrystalSpider:
                    break;
                case Monster.RedThunderZuma:
                case Monster.KingScorpion:
                case Monster.DarkDevil:
                    SoundManager.PlaySound(BaseSound + 5);
                    break;
                default :
                    PlayAttackSound();
                    break;
            }
        }

        public override void Draw()
        {
            float oldOpacity = DXManager.Opacity;
            if (Hidden && !DXManager.Blending) DXManager.SetOpacity(0.5F);

            if (BodyLibrary == null) return;

            if (!DXManager.Blending && Frame.Blend)
                BodyLibrary.DrawBlend(DrawFrame, DrawLocation, DrawColour, true);
            else
                BodyLibrary.Draw(DrawFrame, DrawLocation, DrawColour, true);

            DXManager.SetOpacity(oldOpacity);
        }


        public override bool MouseOver(Point p)
        {
            return MapControl.MapLocation == CurrentLocation || BodyLibrary != null && BodyLibrary.VisiblePixel(DrawFrame, p.Subtract(FinalDrawLocation), false);
        }

        public override void DrawEffects()
        {
            for (int i = 0; i < Effects.Count; i++)
                Effects[i].Draw();


            switch (BaseImage)
            {
                case Monster.Scarecrow:
                    switch (CurrentAction)
                    {
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.Scarecrow].DrawBlend(224 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.CaveMaggot:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            if (FrameIndex >= 1)
                                Libraries.Monsters[(ushort) Monster.CaveMaggot].DrawBlend(175 + FrameIndex + (int) Direction*5, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.Skeleton:
                case Monster.BoneFighter:
                case Monster.AxeSkeleton:
                case Monster.BoneWarrior:
                case Monster.BoneElite:
                    switch (CurrentAction)
                    {
                        case MirAction.Die:
                            Libraries.Monsters[(ushort)Monster.Skeleton].DrawBlend(224 + FrameIndex, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.WoomaTaurus:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.WoomaTaurus].DrawBlend(224 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.Dung:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            if (FrameIndex >= 1)
                                Libraries.Monsters[(ushort)Monster.Dung].DrawBlend(223 + FrameIndex + (int)Direction * 5, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.WedgeMoth:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.WedgeMoth].DrawBlend(224 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.RedThunderZuma:
                    switch (CurrentAction)
                    {
                        case MirAction.Standing:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(320 + FrameIndex + (int)Direction * 4, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Walking:
                        case MirAction.Pushed:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(352 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(400 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                        case MirAction.Struck:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(448 + FrameIndex + (int)Direction * 2, DrawLocation, Color.White, true);
                            break;
                        case MirAction.AttackRange:
                            Libraries.Monsters[(ushort)Monster.RedThunderZuma].DrawBlend(464 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.KingHog:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.KingHog].DrawBlend(224 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
                case Monster.DarkDevil:
                    switch (CurrentAction)
                    {
                        case MirAction.Attack1:
                            Libraries.Monsters[(ushort)Monster.DarkDevil].DrawBlend(342 + FrameIndex + (int)Direction * 6, DrawLocation, Color.White, true);
                            break;
                    }
                    break;
            }
            

        }
    }
}
