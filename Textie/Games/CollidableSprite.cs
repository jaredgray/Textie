﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class CollidableSprite : Sprite, ICollider
    {
        public CollidableSprite(GameData gameData, Scene scene, int width, int height) : base(gameData, scene, width, height)
        {
        }

        public bool HasCollided { get; set; }
        public CollisionBehavior CollisionBehavior { get; set; }
        public IEnumerable<string> CollidesWithTypes { get; set; }

        public virtual void OnCollision(Sprite other)
        {
        }

        public virtual void RunDestroySequence()
        {

        }
    }
}
