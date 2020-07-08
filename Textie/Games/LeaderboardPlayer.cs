using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textie.Games
{
    public class LeaderboardPlayer
    {
        public LeaderboardPlayer()
        {

        }

        public List<int> Scores { get; set; }

        public string Name { get; set; }

        public int GamesPlayed { get; set; }

        public DateTime LastGame { get; set; }

        public string UniqueId { get; set; }
    }
}
