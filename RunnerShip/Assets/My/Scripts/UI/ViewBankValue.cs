using Project.System;
using TMPro;
using UnityEngine;
using YG;

namespace Project.UI
{
    public class ViewBankValue : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bankText;

        private void OnEnable()
        {
            EventBus.Instance.OnViewBankValue += View;

            EventBus.Instance.OnViewBankValue?.Invoke(YandexGame.savesData.Data.Bank);
        }
        private void OnDisable() => EventBus.Instance.OnViewBankValue -= View;
    
        public void View(int value) => _bankText.text = value.ToString();

    }
}