using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project.Tools
{
    public class SetFontTMP_Text : MonoBehaviour
    {
        [SerializeField] private TMP_FontAsset _font;
        [SerializeField] private List<TMP_Text> _text;

        private void Reset() => Get();

        private void OnValidate() => Set();


        [ContextMenu(nameof(Get))]
        public void Get() => _text = new List<TMP_Text>(FindObjectsByType<TMP_Text>((FindObjectsSortMode)FindObjectsInactive.Exclude));


        [ContextMenu(nameof(Set))]
        public void Set()
        {
            for (int i = 0; i < _text.Count; i++)
            {
                if (_text[i] == null)
                    _text.Remove(_text[i]);

                _text[i].font = _font;
            }
        }
    }
}