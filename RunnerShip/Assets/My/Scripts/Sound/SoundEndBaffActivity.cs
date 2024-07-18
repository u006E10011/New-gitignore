using UnityEngine;

namespace Project.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEndBaffActivity : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private void Reset() => _audioSource = _audioSource != null ? _audioSource : GetComponent<AudioSource>();

        public void Play() => _audioSource.PlayOneShot(_audioSource.clip);
    }
}