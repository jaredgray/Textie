using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class CollidableSprite : Sprite, ICollider
    {
        public CollidableSprite(GameData gameData, int width, int height) : base(gameData, width, height)
        {
        }

        public bool HasCollided { get; set; }
        public CollisionBehavior CollisionBehavior { get; set; }
        public IEnumerable<string> CollidesWithTypes { get; set; }

        public void RunDestroySequence()
        {

        }
    }
}
