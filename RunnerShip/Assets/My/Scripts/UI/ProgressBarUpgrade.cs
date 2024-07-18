using Project.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class ProgressBarUpgrade : MonoBehaviour
    {
        public Action<int> OnFillingProgressBarUpgrade;

        [SerializeField, Space(10)] private List<Image> _images;
        [SerializeField, Space(10)] private Color32 _full;

        private void OnValidate() => _images = GetComponentsInChildren<Image>().ToList();
        private void OnEnable() => OnFillingProgressBarUpgrade += Filling;
        private void OnDisable() => OnFillingProgressBarUpgrade -= Filling;

        public void Filling(int value)
        {
            if (value >= _images.Count + 1)
                return;

            for (int i = 0; i < value; i++)
                _images[i].color = _full;
        }

    }
}