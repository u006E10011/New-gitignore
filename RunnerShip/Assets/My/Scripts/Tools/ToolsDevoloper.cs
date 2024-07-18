using Project.System;
using UnityEngine;
using YG;

namespace Project.Tools
{
    public class ToolsDevoloper : MonoBehaviour
    {
        [SerializeField] private int _addCoin;

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.P))
                DataClear();

            if (UnityEngine.Input.GetKeyDown(KeyCode.I))
                GetData();

            if (UnityEngine.Input.GetKeyDown(KeyCode.O))

                AddCoin();

            if (UnityEngine.Input.GetKeyDown(KeyCode.K))
                Died();
        }

        public void Died() => EventBus.Instance.OnDied?.Invoke();

        public void DataClear()
        {
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress();
            YandexGame.LoadProgress();

            Debug.LogError("Reset data all");
        }


        public void AddCoin()
        {
            YandexGame.savesData.Data.Bank += Mathf.Clamp(_addCoin, 0, int.MaxValue);
            YandexGame.SaveProgress();
        }

        public void GetData()
        {
            Debug.Log(
                $"Speed {YandexGame.savesData.Data.Speed}\n" +
                $"Rotate {YandexGame.savesData.Data.Rotate}\n" +
                $"Max Health {YandexGame.savesData.Data.MaxHealth}\n" +
                $" \n" +
                $"Duration Up Speed {YandexGame.savesData.Data.DurationUpSpeed}\n" +
                $"Duration Down Speed {YandexGame.savesData.Data.DurationDownSpeed}\n" +
                $"Percent Up Speed {YandexGame.savesData.Data.PercentUpSpeed}\n" +
                $"Percent Down Speed {YandexGame.savesData.Data.PercentDownSpeed}\n" +
                $"Percent Invincilibity {YandexGame.savesData.Data.DurationInvincibility}");
        }
    }
}