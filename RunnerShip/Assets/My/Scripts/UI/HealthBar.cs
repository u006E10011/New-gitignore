using Project.Game.Player;
using Project.System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Color32 _full;
        [SerializeField] private Color32 _empty;

        [SerializeField, Space(10)] private Image[] _image;

        private void OnEnable() => EventBus.Instance.OnChangedHealth += Changed;
        private void OnDisable() => EventBus.Instance.OnChangedHealth -= Changed;

        public void Changed(int maxHealth, int currentHealth)
        {
            for (int i = 0; i < _image.Length; i++)
            {
                if (i < currentHealth)
                    _image[i].color = _full;
                else
                    _image[i].color = _empty;

                if (i < maxHealth)
                    _image[i].enabled = true;
                else
                    _image[i].enabled = false;
            }
        }
    }

}