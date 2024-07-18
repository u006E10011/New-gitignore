using Project.Animation;
using Project.Game.Player;
using Project.Sound;
using UnityEngine;

namespace Project.Game.Baff
{
    public class HealthPack : MonoBehaviour
    {
        [SerializeField, Min(1)] private int _value = 1;

        [SerializeField, Space(10)] private AnimationScale _animationScale;

        private void Reset() => _animationScale = _animationScale != null ? _animationScale : GetComponent<AnimationScale>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.Add(_value);

                PlaySoundConsumables.Play(Consumables.HealthPack);

                _animationScale?.Play(() => { }, () => gameObject.SetActive(false));
            }
        }
    }
}