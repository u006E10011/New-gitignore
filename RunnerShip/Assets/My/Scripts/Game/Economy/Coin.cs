using Project.System;
using UnityEngine;
using System;
using YG;
using Project.Sound;

namespace Project.Game.Economy
{
    public class Coin : MonoBehaviour
    {
        public event Action<int> OnAddCoin;

        [SerializeField] private CoinType _coinType;
        [SerializeField] private CoinValue _coinValue;

        private void OnEnable() => OnAddCoin += Bank.Instance.Add;
        private void OnDisable() => OnAddCoin -= Bank.Instance.Add;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == Layers.PLAYER)
                Add();

            EventBus.Instance.OnViewBankValue?.Invoke(YandexGame.savesData.Data.Bank);
        }

        private void Add()
        {
            OnAddCoin?.Invoke((int)(ShowType() * YandexGame.savesData.Data.MultiplierCoin));

            PlaySoundConsumables.Play(Consumables.Coin);

            gameObject.SetActive(false);
        }

        private int ShowType()
        {
            var value = _coinType switch
            {
                CoinType.Gold => _coinValue.Gold,
                CoinType.Silver => _coinValue.Silver,
                CoinType.Bronze => _coinValue.Bronze,
                _ => _coinValue.Bronze
            };

            return value;
        }
    }
}