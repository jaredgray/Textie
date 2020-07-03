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
        }

        public int Frequency { get; set; }

        public Direction Direction { get; set; }

        public EdgeScreenHandling EdgeOfScreenCondition { get; set; }
        public TrajectoryRendererData RendererData { get; set; }
    }
}
