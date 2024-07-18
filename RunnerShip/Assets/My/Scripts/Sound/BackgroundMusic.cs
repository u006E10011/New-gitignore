using System.Collections.Generic;
using UnityEngine;

namespace Project.Sound
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _music;
        [SerializeField] private AudioSource _audioSource;

        private void OnEnable() => _audioSource = _audioSource != null ? _audioSource : GetComponent<AudioSource>();

        private void Update()
        {
            if (!_audioSource.isPlaying)
                Switch();
        }

        private void Switch()
        {
            _audioSource.clip = _music[Random.Range(0, _music.Count)];
            _audioSource.Play();
        }
    }

}