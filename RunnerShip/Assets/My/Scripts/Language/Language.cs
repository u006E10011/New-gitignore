using UnityEngine;

namespace Project.Language
{
    public enum Type
    {
        RU,
        EN,
        TR
    }

    public static class Language
    {
        public static Type Value = Type.RU;

        public static void Check()
        {
            /*Value = YandexGame.EnvironmentData.language switch
            {
                "ru" => Type.RU,
                "en" => Type.EN,
                "tr" => Type.TR,
                _ => Type.EN
            };*/

            Value = Application.systemLanguage switch
            {
                SystemLanguage.Russian => Type.RU,
                SystemLanguage.English => Type.RU,
                SystemLanguage.Turkish => Type.TR,
                _ => Type.EN
            };
        }
    }
}