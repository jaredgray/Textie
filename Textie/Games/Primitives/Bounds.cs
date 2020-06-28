using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games.Primitives
{
    public class Bounds
    {
        public Bounds()
        {
            Position = new Vector2D();
            Size = new Size();
        }
        public Vector2D Position { get; set; }
        public Size Size { get; set; }

        public void MoveLeft(int amount)
        {
            this.Position.X -= amount;
        }
        public void MoveRight(int amount)
        {
            this.Position.X += amount;
        }
        public void MoveUp(int amount)
        {
            this.Position.Y -= amount;
        }
        public void MoveDown(int amount)
        {
            this.Position.Y += amount;
        }


    }
}
