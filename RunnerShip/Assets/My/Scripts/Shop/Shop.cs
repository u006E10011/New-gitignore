using YG;

using static Project.Shop.ProductPath;

namespace Project.Shop
{
    /// <summary>
    /// Мне стыдно за способ реализации
    /// </summary>

    public static class Shop
    {
        public static void Upgrade(string path, object value, int level)
        {
            switch (path)
            {
                // Player
                case SPEED:
                    YandexGame.savesData.Data.Speed = int.TryParse(value.ToString(), out int result1) ? result1 : default;
                    YandexGame.savesData.Data.LevelSpeed = level;
                    break;
                case ROTATE:
                    YandexGame.savesData.Data.Rotate = value is float ? (float)value : default;
                    YandexGame.savesData.Data.LevelRotate = level;
                    break;
                case MAX_HEALTH:
                    YandexGame.savesData.Data.MaxHealth = int.TryParse(value.ToString(), out int result2) ? result2 : default;
                    YandexGame.savesData.Data.LevelMaxHealth = level;
                    break;

                // Baff
                case DURATION_UP_SPEED:
                    YandexGame.savesData.Data.DurationUpSpeed = value is float ? (float)value : default;
                    YandexGame.savesData.Data.LevelDurationUpSpeed = level;
                    break;
                case DURATION_DOWN_SPEED:
                    YandexGame.savesData.Data.DurationDownSpeed = value is float ? (float)value : default;
                    YandexGame.savesData.Data.LevelDurationDownSpeed = level;
                    break;
                case PERCENT_UP_SPEED:
                    YandexGame.savesData.Data.PercentUpSpeed = value is float ? (float)value : default;
                    YandexGame.savesData.Data.LevelPercentUpSpeed = level;
                    break;
                case PERCENT_DOWN_SPEED:
                    YandexGame.savesData.Data.PercentDownSpeed = value is float ? (float)value : default;
                    YandexGame.savesData.Data.LevelPercentDownSpeed = level;
                    break;

                case DURATION_INVULNERABILITY:
                    YandexGame.savesData.Data.DurationInvincibility = value is float ? (float)value : default;
                    YandexGame.savesData.Data.LevelDurationInvincibility = level;
                    break;

                // Economy
                case MULTIPLIER_COIN:
                    YandexGame.savesData.Data.MultiplierCoin = value is float ? (float)value : default;
                    YandexGame.savesData.Data.LevelMultiplierCoin = level;
                    break;
            }
        }

        public static int Level(string path)
        {
            int value = path switch
            {
                SPEED => YandexGame.savesData.Data.LevelSpeed,
                ROTATE => YandexGame.savesData.Data.LevelRotate,
                MAX_HEALTH => YandexGame.savesData.Data.LevelMaxHealth,
                DURATION_UP_SPEED => YandexGame.savesData.Data.LevelDurationUpSpeed,
                DURATION_DOWN_SPEED => YandexGame.savesData.Data.LevelDurationDownSpeed,
                PERCENT_UP_SPEED => YandexGame.savesData.Data.LevelPercentUpSpeed,
                PERCENT_DOWN_SPEED => YandexGame.savesData.Data.LevelPercentDownSpeed,
                DURATION_INVULNERABILITY => YandexGame.savesData.Data.LevelDurationInvincibility,
                MULTIPLIER_COIN => YandexGame.savesData.Data.LevelMultiplierCoin,
                _ => 0
            };

            return value;
        }
    }
}