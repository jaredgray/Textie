using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textie.Games.Infrastructure;
using Textie.Games.Services;

namespace Textie.Games
{
    public class Session
    {
        public Session(ILeaderboardService leaderboardService, string gameId)
        {
            // also noted int MachineInfo - this might be the most difficult thing to port. See MachineInfo for details
            SessionBeginTime = DateTime.Now;
            LeaderboardService = leaderboardService;
            UserId = MachineInfo.GetMacAddress();
            var leaderboard = leaderboardService.GetLeaderboardByGameId(gameId);
            Player = leaderboard.GetPlayerByUniqueId(UserId);
            if (null == Player)
                Player = new LeaderboardPlayer() { UniqueId = UserId };
            leaderboard.AddPlayer(Player);
        }
        public ILeaderboardService LeaderboardService { get; set; }
        public DateTime SessionBeginTime { get; set; }
        public string UserId { get; set; }
        public LeaderboardPlayer Player { get; set; }

        public void Save()
        {
            LeaderboardService.SavePlayer(Player);
        }
    }
}
