using YG;

namespace Project.Game.Core
{
    public static class Leaderboard
    {
        private const string MAX_SCORE = "MaxScore";

        public static void UpdateLeaderboard(int value)
        {
            if (YandexGame.initializedLB)
            {
                if (value > YandexGame.savesData.Data.MaxScore)
                    YandexGame.NewLeaderboardScores(MAX_SCORE, value);
            }
        }
    }
}