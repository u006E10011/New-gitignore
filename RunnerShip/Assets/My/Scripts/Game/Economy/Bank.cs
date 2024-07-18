using Project.System;
using System;
using YG;

namespace Project.Game.Economy
{
    public class Bank
    {
        private static Bank _instance;
        public static Bank Instance
        {
            get
            {
                _instance ??= new();

                return _instance;
            }
        }

        private int _value;

        public void Add(int value)
        {
            _value += value;

            EventBus.Instance.OnViewGUICoin?.Invoke(_value);

            YandexGame.savesData.Data.Bank += Math.Clamp(value, 0, int.MaxValue);
        }

        public void Reset() => _value = 0; 
    }
}