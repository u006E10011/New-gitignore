using System;

namespace Project.System
{
    public class EventBus
    {
        private static EventBus _instance;

        public static EventBus Instance
        {
            get
            {
                _instance ??= new();

                return _instance;
            }
        }

        // Game
        public Action OnStartGame;
        public Action OnRestartGame;
        
        // Player
        public Action OnDied;
        public Action<int> OnDamaged;
        public Action<int, int> OnChangedHealth;
        public Action<int> OnUpperSpeed;

        // System
        public Action OnGetLanguage;
        public Action OnSetLanguage;

        // UI
        public Action<int> OnViewBankValue;
        public Action<int> OnViewMaxScore;
        public Action<int> OnViewGUICoin;
        public Action<int> OnViewGUIScore;

        public Action OnPlayAnimationInvincibilityUI;
        public Action OnPlayAnimationUpSpeedUI;
        public Action OnPlayAnimationDownSpeedUI;

        //Sound
        public Action OnSetInMenuSnapshot;
        public Action OnSetNormalSnapshot;
        public Action OnSoundOfTakingDamage;
    }
}