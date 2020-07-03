using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games.SpaceInvaders
{
    public class AlienGroup : SpriteGroup, ITrajectory
    {
        const string data = @"COME ON!!!!!";
        public AlienGroup(int frequency, Direction direction)
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
