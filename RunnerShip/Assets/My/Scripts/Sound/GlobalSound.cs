using Project.System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using YG;

namespace Project.Sound
{
    public class GlobalSound : MonoBehaviour
    {
        private const string MASTER = "MasterVolume";

        private float _volume;

        [SerializeField] private Slider _slider;
        [SerializeField] private AudioMixerGroup _mixer;

        private void OnEnable() => YandexGame.GetDataEvent += GetData;
        private void OnDisable() => YandexGame.GetDataEvent -= GetData;

        private void Start()
        {
            if (YandexGame.SDKEnabled)
                GetData();
        }

        private void GetData()
        {
            _volume = YandexGame.savesData.Data.SoundVolume;
            _slider.value = _volume;
        }

        public void ChangeVolume(float volume)
        {
            _volume = volume;
            _mixer.audioMixer.SetFloat(MASTER, Mathf.Lerp(-80, 0, _volume));
        }

        public void Save()
        {
            YandexGame.savesData.Data.SoundVolume = _volume;
            YandexGame.SaveProgress();
        }
    }
}