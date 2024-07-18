using System.Collections.Generic;
using UnityEngine;

namespace Project.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundOnClick : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<AudioClip> _clips;

        private void Reset() => _audioSource = _audioSource != null ? _audioSource : GetComponent<AudioSource>();

        public void Play(int index) => _audioSource.PlayOneShot(_clips[index]);
    }
}