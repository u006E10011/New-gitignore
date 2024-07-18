using System.Collections.Generic;
using UnityEngine;

namespace Project.Sound
{
    public enum Consumables
    {
        Coin,
        UpSpeed,
        DownSpeed,
        HealthPack,
        Invincibility
    }

    [RequireComponent(typeof(AudioSource))]
    public class PlaySoundConsumables : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _clips = new();

        private static AudioSource _audioSource;
        private static List<AudioClip> _clipsStatic = new();

        private void OnValidate()
        {
            _audioSource = _audioSource != null ? _audioSource : GetComponent<AudioSource>();
            _clipsStatic = _clips;
        }

        public static void Play(Consumables type) => _audioSource.PlayOneShot(_clipsStatic[ShowType(type)]);

        private static int ShowType(Consumables type)
        {
            var index = type switch
            {
                Consumables.Coin => 0,
                Consumables.UpSpeed => 1,
                Consumables.DownSpeed => 2,
                Consumables.HealthPack => 3,
                Consumables.Invincibility => 4,
                _ => 0
            };

            return index;
        }
    }
}