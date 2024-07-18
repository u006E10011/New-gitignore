using Project.System;
using TMPro;
using UnityEngine;

namespace Project.UI
{
    public class ViewScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _GUIText;
        [SerializeField] private TMP_Text _maxText;

        private void OnEnable()
        {
            EventBus.Instance.OnViewGUIScore += View;
            EventBus.Instance.OnViewMaxScore += ViewMax;
        }

        private void OnDisable()
        {
            EventBus.Instance.OnViewGUIScore -= View;
            EventBus.Instance.OnViewMaxScore -= ViewMax;
        }

        public void View(int value) => _GUIText.text = Mathf.FloorToInt(value).ToString();
        public void ViewMax(int value) => _maxText.text = Mathf.FloorToInt(value).ToString();

    }
}