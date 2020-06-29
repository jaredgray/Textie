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

        private void HandleScreenEdgeReverseDirection(Sprite sprite, ITrajectory trajectory)
        {

        }

        private void HandleScreenEdgeDisappear(Sprite sprite, ITrajectory trajectory)
        {
            // NEXT: delete parts of the sprite as it exits the screen before just deleting it
            if (sprite.Bounds.Position.X < 0)
                sprite.MarkDelete = true;
            if (sprite.Bounds.Position.X + sprite.Bounds.Size.Width > GameArea.Width)
                sprite.MarkDelete = true;
            if (sprite.Bounds.Position.Y < 0)
                sprite.MarkDelete = true;
            if (sprite.Bounds.Position.Y + sprite.Bounds.Size.Height > GameArea.Height)
                sprite.MarkDelete = true;
        }

        private void HandleScreenEdge(Sprite sprite, ITrajectory trajectory)
        {

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
                HandleScreenEdgeDisappear(sprite, trajectory);
            }
        }
    }
}
