using UnityEngine.SceneManagement;
using UnityEngine;
using Project.System;
using YG;
using Project.Game.Economy;


namespace Project.Game.Core
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;

        private void OnEnable()
        {
            EventBus.Instance.OnStartGame += LoadSave;
            EventBus.Instance.OnStartGame += Bank.Instance.Reset;
            EventBus.Instance.OnStartGame += () => EventBus.Instance.OnViewGUICoin?.Invoke(0);

            EventBus.Instance.OnRestartGame += Restart;
        }
        private void OnDisable()
        {
            EventBus.Instance.OnStartGame -= LoadSave;
            EventBus.Instance.OnStartGame -= Bank.Instance.Reset;
            EventBus.Instance.OnStartGame -= () => EventBus.Instance.OnViewGUICoin?.Invoke(0);

            EventBus.Instance.OnRestartGame -= Restart;
        }

        private void Awake() => YandexGame.GameReadyAPI();

        public void Restart()
        {
            ResetGame();
            TimeScale();
        }

        public void ResetGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        public void TimeScale() => Time.timeScale = 1;

        private void LoadSave()
        {
            if (YandexGame.SDKEnabled)
            {
                if (YandexGame.savesData.isFirstSession)
                    YandexGame.SaveProgress();

                YandexGame.LoadProgress();
            }
        }
    }
}