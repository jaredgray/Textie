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

            //foreach (var candidate in others.Where(x => !(x is ISpriteGroup)))
            //{
            //    if (candidate is ISpriteGroup || candidate.Type != SpriteTypes.PLAYER_BULLET)
            //        continue;

            //    var candidateCollider = candidate as ICollider;

            //    if (spriteGroup.CollidesWith(candidate))
            //    {
            //        if (candidateCollider.CollisionBehavior == CollisionBehavior.Remove)
            //        {
            //            candidate.MarkDelete = true;
            //        }
            //        else if (candidateCollider.CollisionBehavior == CollisionBehavior.RunDestroySequence)
            //        {
            //            candidateCollider.RunDestroySequence();
            //        }
            //    }
            //}
            //if (spriteGroup.Any())
            //{
            //    var victims = new List<Alien>(spriteGroup.Where(x => x.MarkDelete));
            //    foreach (var victim in victims)
            //    {
            //        spriteGroup.Remove(victim);
            //    }
            //}
        }
    }
}
