using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games
{
    public class TrajectoryController : IUpdateSpriteHandler
    {
        public TrajectoryController(Size gameArea)
        {
            GameArea = gameArea;
        }
        public Size GameArea { get; set; }

        private void HandleScreenEdge(Sprite sprite, ITrajectory trajectory)
        {
            //if (sprite.Bounds.Position.X < 0)
            //    sprite.Bounds.Position.X = 0;
            //if (sprite.Bounds.Position.X + sprite.Bounds.Size.Width > Size.Width)
            //    sprite.Bounds.Position.X = Size.Width - sprite.Bounds.Size.Width;
            //if (sprite.Bounds.Position.Y < 0)
            //    sprite.Bounds.Position.Y = 0;
            //if (sprite.Bounds.Position.Y + sprite.Bounds.Size.Height > Size.Height)
            //    sprite.Bounds.Position.Y = Size.Height - sprite.Bounds.Size.Height;
        }

        public void HandleSprites(IEnumerable<Sprite> sprites)
        {
            var trajectorysprites = sprites.Where(x => x is ITrajectory);
            foreach (var sprite in trajectorysprites)
            {
                var trajectory = sprite as ITrajectory;
                if(trajectory.Direction == Primitives.Direction.Up)
                {
                    sprite.Bounds.Position.Y--;
                }
                else if(trajectory.Direction == Direction.Right)
                {
                    sprite.Bounds.Position.X++;
                }
                else if (trajectory.Direction == Direction.Down)
                {
                    sprite.Bounds.Position.Y++;
                }
                else if (trajectory.Direction == Direction.Left)
                {
                    sprite.Bounds.Position.X--;
                }
            }
        }
    }
}
