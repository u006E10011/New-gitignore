using Project.System;
using TMPro;
using UnityEngine;

namespace Project.UI
{
    public class ViewCoinGUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _GUIText;

        private void OnEnable() => EventBus.Instance.OnViewGUICoin += View;
        private void OnDisable() => EventBus.Instance.OnViewGUICoin -= View;

        public void View(int value) => _GUIText.text = value.ToString();
    }
}