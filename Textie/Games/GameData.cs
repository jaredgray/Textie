using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class GameData
    {
        public Scene Scene { get; set; }

        public Playerboard Playerboard { get; private set; }

        public void SetPlayerboard(Playerboard board)
        {
            if(null != Playerboard)
            {
                Scene.RemoveSprite(Playerboard);
            }

            this.Playerboard = board;
            Scene.AddSprite(Playerboard);
        }

        public bool PlayerDeath { get; set; }
        public bool IsComplete { get; set; }
        public int Level { get; set; }
    }
}
