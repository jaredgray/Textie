using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Services;

namespace Textie.Games.SpaceInvaders
{
    public class SIGameData : GameData
    {
        public SIGameData(ILeaderboardService leaderboardService, string gameId) : base(leaderboardService, gameId) { }
        public bool PlayerDeath { get; set; }
    }
}
