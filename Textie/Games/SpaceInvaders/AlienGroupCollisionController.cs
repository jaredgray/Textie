using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games.SpaceInvaders
{
    public class AlienGroupCollisionController : ICollisionController
    {
        public void HandleSprite(Sprite sprite, IEnumerable<Sprite> others)
        {
            var spriteGroup = sprite as AlienGroup;

            foreach (var candidate in others.Where(x => !(x is ISpriteGroup)))
            {
                if (candidate is ISpriteGroup)
                    continue;

                var candidateCollider = candidate as ICollider;
                if (spriteGroup.CollidesWith(candidate))
                {
                    if (candidateCollider.CollisionBehavior == CollisionBehavior.Remove)
                    {
                        candidate.MarkDelete = true;
                    }
                    else if (candidateCollider.CollisionBehavior == CollisionBehavior.RunDestroySequence)
                    {
                        candidateCollider.RunDestroySequence();
                    }
                }
                //var spriteCollider = alien as ICollider;
                //if (alien.MarkDelete || spriteCollider.HasCollided)
                //    continue;
                //var candidateCollider = candidate as ICollider;
                //// stop hitting yourself.. stop hitting yourself
                //if (candidate == alien || candidateCollider.HasCollided)
                //    continue;

                //if (alien.Bounds.IntersectsWith(candidate.Bounds))
                //{
                //    spriteCollider.HasCollided = candidateCollider.HasCollided = true;
                //    if (spriteCollider.CollisionBehavior == CollisionBehavior.Remove)
                //    {
                //        alien.MarkDelete = true;
                //    }
                //    else if (spriteCollider.CollisionBehavior == CollisionBehavior.RunDestroySequence)
                //    {
                //        spriteCollider.RunDestroySequence();
                //    }

                //    if (candidateCollider.CollisionBehavior == CollisionBehavior.Remove)
                //    {
                //        sprite.MarkDelete = true;
                //    }
                //    else if (candidateCollider.CollisionBehavior == CollisionBehavior.RunDestroySequence)
                //    {
                //        candidateCollider.RunDestroySequence();
                //    }
                //    break;
                //}
            }
            if (spriteGroup.Any())
            {
                var victims = new List<Alien>(spriteGroup.Where(x => x.MarkDelete));
                foreach (var victim in victims)
                {
                    spriteGroup.Remove(victim);
                }
                //for (int i = victims.Count - 1; i >= 0; i--)
                //{
                //    spriteGroup.RemoveAt(spriteGroup.IndexOf(victims[i]));
                //}
            }
        }
    }
}
