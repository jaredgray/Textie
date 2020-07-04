using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public interface ICollisionController
    {
        void HandleSprite(Sprite sprite, IEnumerable<Sprite> others);
    }
}
