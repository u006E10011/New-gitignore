using UnityEngine;

namespace Project.Data
{
    public enum Type
    {
        Int,
        Float,
        String
    }

    public static class SaveSystem
    {
        public static void Save(string path, object value, Type type)
        {
            switch (type)
            {
                case Type.Int:
                    PlayerPrefs.SetInt(path, (int)value);
                    break;
                case Type.Float:
                    PlayerPrefs.SetFloat(path, (float)value);
                    break;
                case Type.String:
                    PlayerPrefs.SetString(path, (string)value);
                    break;
            }
        }

        public static int Int(string path) => PlayerPrefs.GetInt(path);
        public static float Float(string path) => PlayerPrefs.GetFloat(path);
        public static string String(string path) => PlayerPrefs.GetString(path);

    }
}