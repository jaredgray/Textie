using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Primitives;

namespace Textie.Games.SpaceInvaders
{
    public class AlienGroup : SpriteGroup<Alien>, ITrajectory, ICollider
    {
        const string data = @"COME ON!!!!!";
        public AlienGroup(int frequency, Direction direction)
        {
            Frequency = frequency;
            Direction = direction;
            EdgeOfScreenCondition = EdgeScreenHandling.ReverseDirection;
            base.SetData(data);
            CollisionBehavior = CollisionBehavior.None;
        }

        public int Frequency { get; set; }

        public Direction Direction { get; set; }

        public EdgeScreenHandling EdgeOfScreenCondition { get; set; }
        public TrajectoryRendererData TrajectoryRendererData { get; set; }

        public override void Update()
        {
            base.Update();
            if(this.Frequency == this.TrajectoryRendererData.IterationsSinceLastMovement)
            {
                foreach (var sprite in this)
                {
                    sprite.Update();
                }
                base.RebuildData();
            }
            var victims = this.Where(x => x.MarkDelete);
            foreach (var victim in victims)
            {
                this.Remove(victim);
            }
            if (this.Count == 0)
                this.MarkDelete = true;
        }


        public bool HasCollided { get; set; }
        public CollisionBehavior CollisionBehavior { get; set; }

        public void RunDestroySequence()
        {
            throw new NotImplementedException("An AlienGroup cannot run a DestroySequence");
        }

        public override bool CollidesWith(Sprite other)
        {
            if (other is ISpriteGroup)
                return false;
            if (0 == this.Count)
            {

            }
            foreach (var alien in this)
            {
                var alienBounds = new Bounds()
                {
                    Position = new Vector2D()
                    {
                        X = alien.Bounds.Position.X + this.Bounds.Position.X,
                        Y = alien.Bounds.Position.Y + this.Bounds.Position.Y
                    },
                    Size = alien.Bounds.Size
                };
                if(alienBounds.IntersectsWith(other.Bounds))
                {
                    alien.MarkDelete = true;
                    alien.RunDestroySequence();
                    return true;
                }
            }

            

            return false;
        }

    }
}
