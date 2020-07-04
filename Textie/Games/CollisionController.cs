using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class CollisionController : ICollisionController
    {
        public CollisionController()
        {
            
        }

        public void HandleSprite(Sprite sprite, IEnumerable<Sprite> others)
        {
            var spriteCollider = sprite as ICollider;
            if (sprite.MarkDelete || spriteCollider.HasCollided)
                return;
            foreach (var candidate in others)
            {
                var candidateCollider = candidate as ICollider;
                // stop hitting yourself.. stop hitting yourself
                if (candidate == sprite || candidateCollider.HasCollided)
                    continue;

                if(sprite.CollidesWith(candidate))
                {
                    spriteCollider.HasCollided = candidateCollider.HasCollided = true;
                    if(spriteCollider.CollisionBehavior == CollisionBehavior.Remove)
                    {
                        sprite.MarkDelete = true;
                    }
                    else if(spriteCollider.CollisionBehavior == CollisionBehavior.RunDestroySequence)
                    {
                        spriteCollider.RunDestroySequence();
                    }

                    if (candidateCollider.CollisionBehavior == CollisionBehavior.Remove)
                    {
                        candidate.MarkDelete = true;
                    }
                    else if (candidateCollider.CollisionBehavior == CollisionBehavior.RunDestroySequence)
                    {
                        candidateCollider.RunDestroySequence();
                    }
                    break;
                }
            }
        }
    }
}
