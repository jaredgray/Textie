namespace Textie.Games.Services
{
    public interface ILeaderboardService
    {
        Leaderboard GetLeaderboardByGameId(string gameId);
        void SavePlayer(LeaderboardPlayer leaderboardPlayer);
    }
}