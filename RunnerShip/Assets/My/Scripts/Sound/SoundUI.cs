using Project.System;
using UnityEngine;
using UnityEngine.Audio;

namespace Project.Sound
{
    public class SoundUI : MonoBehaviour
    {
        [SerializeField] private float _smoothing = .5f;

        [SerializeField, Space(10)] private AudioMixerSnapshot _normal;
        [SerializeField] private AudioMixerSnapshot _inMenu;

        private void Awake()
        {
            EventBus.Instance.OnSetInMenuSnapshot += InMenu;
            EventBus.Instance.OnSetNormalSnapshot += Normal;
        }
        private void OnDisable()
        {
            EventBus.Instance.OnSetInMenuSnapshot -= InMenu;
            EventBus.Instance.OnSetNormalSnapshot -= Normal;
        }

        private void Normal() => _normal.TransitionTo(_smoothing);
        private void InMenu() => _inMenu.TransitionTo(_smoothing);
    }
}