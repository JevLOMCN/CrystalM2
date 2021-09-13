using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.MirObjects
{
    public class FrameSet
    {
        public static FrameSet Players;
        public static List<FrameSet> NPCs; //Make Array
        public static List<FrameSet> Monsters;

        public Dictionary<MirAction, Frame> Frames = new Dictionary<MirAction, Frame>();


        static FrameSet()
        {
            FrameSet frame;
            NPCs = new List<FrameSet>();

            Monsters = new List<FrameSet>();

            Players = new FrameSet();
            Players.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            Players.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            Players.Frames.Add(MirAction.Running, new Frame(80, 6, 0, 100));
            Players.Frames.Add(MirAction.Stance, new Frame(128, 1, 0, 2000));
            Players.Frames.Add(MirAction.Attack1, new Frame(136, 6, 0, 100));
            Players.Frames.Add(MirAction.Attack2, new Frame(184, 6, 0, 100));
            Players.Frames.Add(MirAction.Attack3, new Frame(232, 8, 0, 100));
            Players.Frames.Add(MirAction.Spell, new Frame(296, 6, 0, 100));
            Players.Frames.Add(MirAction.Harvest, new Frame(344, 2, 0, 300));
            Players.Frames.Add(MirAction.Struck, new Frame(360, 3, 0, 100));
            Players.Frames.Add(MirAction.Die, new Frame(384, 4, 0, 100));
            Players.Frames.Add(MirAction.Dead, new Frame(387, 1, 3, 1000));
            Players.Frames.Add(MirAction.Attack4, new Frame(416, 6, 0, 100));



            /*
             * NPCS
             */
            NPCs.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 450));
            frame.Frames.Add(MirAction.Harvest, new Frame(12, 10, 0, 200));

            NPCs.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 450));
            frame.Frames.Add(MirAction.Harvest, new Frame(12, 10, 0, 200));

            NPCs.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 450));
            frame.Frames.Add(MirAction.Harvest, new Frame(12, 20, 0, 200));

            NPCs.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 450));


            /*
             * MONSTERS             
             */

            //0
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(80, 6, 0, 100));


            //1
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(80, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(128, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(144, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(153, 1, 9, 1000));
            frame.Frames.Add(MirAction.Skeleton, new Frame(224, 1, 0, 1000));

            //2 - Regular
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(80, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(128, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(144, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(153, 1, 9, 1000));

            //3
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, -4, 500));
            frame.Frames.Add(MirAction.Show, new Frame(4, 8, -8, 200));
            frame.Frames.Add(MirAction.Hide, new Frame(11, 8, -8, 200) { Reverse = true });
            frame.Frames.Add(MirAction.Attack1, new Frame(12, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(60, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(76, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(85, 1, 9, 1000));

            //4
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(80, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(128, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(144, 4, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(147, 1, 3, 1000));
            
            //5
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(80, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack2, new Frame(128, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(176, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(192, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(201, 1, 9, 1000));

            //6
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 10, -10, 500));
            frame.Frames.Add(MirAction.Struck, new Frame(10, 2, -2, 200));
            frame.Frames.Add(MirAction.Die, new Frame(12, 10, -10, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(21, 1, -1, 1000));

            //7
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, -4, 1000));
            frame.Frames.Add(MirAction.Show, new Frame(22, 10, -10, 150));
            frame.Frames.Add(MirAction.Hide, new Frame(31, 10, -10, 150) { Reverse = true });
            frame.Frames.Add(MirAction.Attack1, new Frame(4, 6, -6, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(10, 2, -2, 200));
            frame.Frames.Add(MirAction.Die, new Frame(12, 10, -10, 150));
            frame.Frames.Add(MirAction.Dead, new Frame(21, 1, -1, 1000));

            //8
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, -4, 1000));
            frame.Frames.Add(MirAction.Attack1, new Frame(4, 6, -6, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(10, 2, -2, 200));
            frame.Frames.Add(MirAction.Die, new Frame(12, 10, -10, 150));
            frame.Frames.Add(MirAction.Dead, new Frame(21, 1, -1, 1000));

            //9
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(80, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(128, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(144, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(153, 1, 9, 1000));
            frame.Frames.Add(MirAction.AttackRange, new Frame(224, 6, 0, 100));

            //10
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, -4, 1000));
            frame.Frames.Add(MirAction.Attack1, new Frame(4, 6, -6, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(10, 2, -2, 200));
            frame.Frames.Add(MirAction.Die, new Frame(12, 20, -20, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(31, 1, -1, 1000));

            //11
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Stoned, new Frame(0, 1, 5, 100));
            frame.Frames.Add(MirAction.Show, new Frame(0, 6, 0, 100));
            frame.Frames.Add(MirAction.Hide, new Frame(5, 6, 0, 100) { Reverse = true });
            frame.Frames.Add(MirAction.Standing, new Frame(48, 4, 0, 1000));
            frame.Frames.Add(MirAction.Walking, new Frame(80, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(128, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(176, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(192, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(201, 1, 9, 1000));

            //12
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Stoned, new Frame(0, 1, -1, 100));
            frame.Frames.Add(MirAction.Show, new Frame(0, 20, -20, 100));
            frame.Frames.Add(MirAction.Standing, new Frame(20, 4, 0, 1000));
            frame.Frames.Add(MirAction.Walking, new Frame(52, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(100, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(148, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(164, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(173, 1, 9, 1000));

            //13
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(80, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(128, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(144, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(153, 1, 9, 1000));
            frame.Frames.Add(MirAction.AttackRange, new Frame(224, 6, 0, 100));
            frame.Frames.Add(MirAction.Stoned, new Frame(272, 1, 5, 100));
            frame.Frames.Add(MirAction.Show, new Frame(272, 6, 0, 100));
            frame.Frames.Add(MirAction.Hide, new Frame(277, 6, 0, 100) { Reverse = true });
            
            //14
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(80, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(128, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(144, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(153, 1, 9, 1000));
            frame.Frames.Add(MirAction.AttackRange, new Frame(224, 6, 0, 100));

            //15
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Standing, new Frame(0, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(32, 6, 0, 100));
            frame.Frames.Add(MirAction.Attack1, new Frame(80, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(128, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(144, 10, 0, 100));
            frame.Frames.Add(MirAction.Dead, new Frame(153, 1, 9, 1000));
            frame.Frames.Add(MirAction.Appear, new Frame(224, 10, -10, 100) { Blend = true });

            //16
            Monsters.Add(frame = new FrameSet());
            frame.Frames.Add(MirAction.Appear, new Frame(0, 10, 0, 100));
            frame.Frames.Add(MirAction.Standing, new Frame(80, 4, 0, 500));
            frame.Frames.Add(MirAction.Walking, new Frame(112, 6, 0, 100));
            frame.Frames.Add(MirAction.Struck, new Frame(160, 2, 0, 200));
            frame.Frames.Add(MirAction.Die, new Frame(176, 10, 0, 100));
            frame.Frames.Add(MirAction.Show, new Frame(256, 10, 0, 100));
            frame.Frames.Add(MirAction.Hide, new Frame(265, 10, 0, 100) { Reverse = true });
        }
    }

    

    public class Frame
    {
        public int Start, Count, Skip;
        public int Interval;
        public bool Reverse, Blend;

        public int OffSet
        {
            get { return Count + Skip; }
        }

        public Frame(int start, int count, int skip, int interval)
        {
            Start = start;
            Count = count;
            Skip = skip;
            Interval = interval;
        }
    }

}
