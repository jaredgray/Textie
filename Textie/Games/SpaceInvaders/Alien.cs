using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games.SpaceInvaders
{
    public class Alien : Sprite, ITrajectory
    {
        const string data = @"COME ON!!!!!";
        public Alien(int frequency, Direction direction, Size size)
            : base(size.Width, size.Height)
        {
            Frequency = frequency;
            Direction = direction;
            base.SetData(data);
            DataIndex = 1; // set data index to 1 so it will flip back to 0 on first draw
        }

        private int DataIndex { get; set; }

        public List<char> Data2 { get; set; }
        public void SetData2(string data)
        {
            Data2 = new List<char>();
            base.SetData(Data2, data);
        }

        public int Frequency { get; set; }

        public Direction Direction { get; set; }

        public EdgeScreenHandling EdgeOfScreenCondition { get; set; }
        public TrajectoryRendererData TrajectoryRendererData { get; set; }

        public override void Update()
        {
            base.Update();
            ++DataIndex;
            if (DataIndex > 1)
                DataIndex = 0;
        }
        public override char GetCharAt(int index)
        {
            if(DataIndex == 0)
            {
                if (index < Data.Count)
                {
                    return Data[index];
                }
                else
                {

                }
            }
            else
            {
                if (index < Data2.Count)
                {
                    return Data2[index];
                }
                else
                {

                }
            }
            return ' ';
        }
    }
}
