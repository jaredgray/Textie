using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class GameData
    {
        public bool StopGame { get; set; }
        public bool IsAlive { get; set; }
        public bool IsActive { get; set; }
        public bool PlayerDeath { get; set; }
        public bool IsComplete { get; set; }
        public int Level { get; set; }
    }
}
