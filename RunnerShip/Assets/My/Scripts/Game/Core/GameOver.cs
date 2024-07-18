using Project.System;
using UnityEngine;
using YG;

namespace Project.Game.Core
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;

        private void OnEnable()
        {
            EventBus.Instance.OnDied += ActivateMenu;
            EventBus.Instance.OnDied += Save;
        }

        private void OnDisable()
        {
            EventBus.Instance.OnDied -= ActivateMenu;
            EventBus.Instance.OnDied -= Save;
        }

        public void Save()
        {
            YandexGame.SaveProgress();
            Leaderboard.UpdateLeaderboard(YandexGame.savesData.Data.MaxScore);
        }

        private void ActivateMenu() => _menu.SetActive(true);

    }
}