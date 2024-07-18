using Project.System;
using TMPro;
using UnityEngine;

namespace Project.Language
{
    public class Translate : MonoBehaviour
    {
        [SerializeField] private string DiscriptionRU;
        [SerializeField] private string DiscriptionEN;
        [SerializeField] private string DiscriptionTR;

        public string Value { get; private set; }

        [SerializeField, Space(10)] private TMP_Text _text;

        private void Reset() => _text = _text != null ? _text : GetComponent<TMP_Text>();

        private void OnEnable()
        {
            EventBus.Instance.OnSetLanguage += Set;

            EventBus.Instance.OnSetLanguage?.Invoke();
        }
        private void OnDestroy() => EventBus.Instance.OnSetLanguage -= Set;

        private void Set()
        {
            string text = Language.Value switch
            {
                Type.RU => DiscriptionRU,
                Type.EN => DiscriptionEN,
                Type.TR => DiscriptionTR,
                _ => DiscriptionEN
            };

            Value = text;
            _text.text = text;
        }
    }
}