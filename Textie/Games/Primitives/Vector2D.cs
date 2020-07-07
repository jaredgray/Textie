using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D
            {
                X = a.X + b.X,
                Y = a.Y + b.Y
            };
        }
    }
}
