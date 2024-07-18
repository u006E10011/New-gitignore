using Project.System;
using System.Collections;
using UnityEngine;

namespace Project.Sound
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private float _delayBeforeSinking;

        [SerializeField] private AudioClip _takingDamage;
        [SerializeField] private AudioClip _damageBeforeDeath;
        [SerializeField] private AudioClip _sinking;
        [SerializeField] private AudioSource _audioSource;

        private void Reset() => _audioSource = _audioSource != null ? _audioSource : GetComponent<AudioSource>();

        private void OnEnable()
        {
            EventBus.Instance.OnSoundOfTakingDamage += TakingDamage;
            EventBus.Instance.OnDied += Died;
        }

        private void OnDisable()
        {
            EventBus.Instance.OnSoundOfTakingDamage -= TakingDamage;
            EventBus.Instance.OnDied -= Died;
        }

        public void TakingDamage()
        {
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.PlayOneShot(_takingDamage);
        }

        public void Died()
        {
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.PlayOneShot(_damageBeforeDeath);

            StartCoroutine(SoundDied(_delayBeforeSinking));
        }

        private IEnumerator SoundDied(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);

            _audioSource.PlayOneShot(_sinking);
        }
    }
}