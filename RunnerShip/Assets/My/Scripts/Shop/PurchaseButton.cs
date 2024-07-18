using Project.Sound;
using Project.System;
using Project.UI;
using UnityEngine;
using YG;

namespace Project.Shop
{
    public class PurchaseButton : MonoBehaviour
    {
        private const int SOUND_CLICK_BUTTON = 0;
        private const int SOUND_PURCHASE_BUTTON = 1;

        private int _currentLevel;

        [SerializeField] private Product _product;
        [SerializeField] private ViewProductPanel _viewProduct;
        [SerializeField] private ProgressBarUpgrade _progressBar;
        [SerializeField] private SoundOnClick _sound;

        private void OnValidate()
        {
            _progressBar = _progressBar != null ? _progressBar : GetComponentInChildren<ProgressBarUpgrade>();
            _sound = _sound != null ? _sound : GetComponentInChildren<SoundOnClick>();
        }

        private void OnEnable() => YandexGame.GetDataEvent += delegate
        {
            Data();

            Visual();
        };

        private void OnDisable() => YandexGame.GetDataEvent -= Data;

        private void Start()
        {
            Data();
            Visual();
        }

        public void Purchase()
        {
            if (CheckBalance())
            {
                if (IsUpLevel())
                {
                    YandexGame.savesData.Data.Bank -= Mathf.Clamp(_product.Upgrades[_currentLevel].Parce, 0, int.MaxValue);

                    Shop.Upgrade(_product.Name, _product.Upgrades[_currentLevel].Value, _currentLevel);

                    Visual();

                    _sound.Play(SOUND_PURCHASE_BUTTON);

                    EventBus.Instance.OnViewBankValue?.Invoke(YandexGame.savesData.Data.Bank);

                    YandexGame.SaveProgress();

                    return;
                }
                else
                    _sound.Play(SOUND_CLICK_BUTTON);
            }
            else
                _sound.Play(SOUND_CLICK_BUTTON);

        }

        private bool CheckBalance()
        {
            if (_currentLevel + 1 >= _product.Upgrades.Count)
                return false;

            if (YandexGame.savesData.Data.Bank >= _product.Upgrades[_currentLevel + 1].Parce)
                return true;

            return false;
        }

        private bool IsUpLevel()
        {
            if (_currentLevel < _product.Upgrades.Count - 1)
            {
                _currentLevel++;

                return true;
            }

            return false;
        }

        private void Visual()
        {
            _progressBar.OnFillingProgressBarUpgrade?.Invoke(_currentLevel);
            _viewProduct.OnViewPanel?.Invoke(_product);
        }

        private void Data() => _currentLevel = Shop.Level(_product.name);
    }
}
