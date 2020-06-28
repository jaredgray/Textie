using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games.Shooter
{
    public class Bullet : Sprite, ITrajectory
    {
        const string data = @"*";
        public Bullet(int frequency, Direction direction)
            : base(1, 1)
        {
            Frequency = frequency;
            Direction = direction;
            base.SetData(data);
        }

        public int Frequency { get; set; }

        public Direction Direction { get; set; }
    }
}
