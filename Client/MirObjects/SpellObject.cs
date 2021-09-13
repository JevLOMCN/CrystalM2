using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Client.MirGraphics;
using Client.MirScenes;
using S = ServerPackets; 

namespace Client.MirObjects
{
    class SpellObject : MapObject
    {
        public override ObjectType Race
        {
            get { return ObjectType.Spell; }
        }

        public override bool Blocking
        {
            get { return false; }
        }

        public Spell Spell;
        public int FrameCount, FrameInterval, FrameIndex;
        

        public SpellObject(uint objectID) : base(objectID)
        {
        }

        public void Load(S.ObjectSpell info)
        {
            CurrentLocation = info.Location;
            MapLocation = info.Location;
            GameScene.Scene.MapControl.AddObject(this);
            Spell = info.Spell;

            switch (Spell)
            {
                case Spell.TrapHexagon:
                    BodyLibrary = Libraries.Magic;
                    DrawFrame = 1390;
                    FrameInterval = 100;
                    FrameCount = 10;
                    break;
                case Spell.FireWall:
                    BodyLibrary = Libraries.Magic;
                    DrawFrame = 1630;
                    FrameInterval = 120;
                    FrameCount = 6;
                    Light = 3;
                    break;
                case Spell.PoisonField:
                    BodyLibrary = Libraries.Magic2;
                    DrawFrame = 1650;
                    FrameInterval = 120;
                    FrameCount = 20;
                    Light = 3;
                    break;
            }


            NextMotion = CMain.Time + FrameInterval;
            NextMotion -= NextMotion % 100;
        }
        public override void Process()
        {
            if (CMain.Time >= NextMotion)
            {
                if (++FrameIndex >= FrameCount)
                    FrameIndex = 0;
                NextMotion = CMain.Time + FrameInterval;
            }

            DrawLocation = new Point((CurrentLocation.X - User.Movement.X + MapControl.OffSetX) * MapControl.CellWidth, (CurrentLocation.Y - User.Movement.Y + MapControl.OffSetY) * MapControl.CellHeight);

            DrawLocation.Offset(User.OffSetMove);
        }

        public override void Draw()
        {
            if (BodyLibrary == null) return;

            BodyLibrary.DrawBlend(DrawFrame + FrameIndex, DrawLocation, DrawColour, true, 0.8F);
        }

        public override bool MouseOver(Point p)
        {
            return false;
        }

        public override void DrawEffects()
        {
            
        }
    }
}
