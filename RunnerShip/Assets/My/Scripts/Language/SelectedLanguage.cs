using Project.System;
using UnityEngine;
using YG;

namespace Project.Language
{
    public class SelectedLanguage : MonoBehaviour
    {
        private void OnEnable()
        {
            YandexGame.GetDataEvent += Language.Check;
            EventBus.Instance.OnGetLanguage += Language.Check;

            if (YandexGame.SDKEnabled)
                EventBus.Instance.OnGetLanguage?.Invoke();
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= Language.Check;
            EventBus.Instance.OnGetLanguage -= Language.Check;
        }

        public void Set(int index)
        {
            Language.Value = index switch
            {
                1 => Type.RU,
                2 => Type.EN,
                3 => Type.TR,
                _ => Type.EN
            };

            EventBus.Instance.OnSetLanguage?.Invoke();
        }
    }
}