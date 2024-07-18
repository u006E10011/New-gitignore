using Project.Animation;
using Project.Game.Player;
using Project.Sound;
using Project.System;
using UnityEngine;

namespace Project.Game.Baff
{
    public class Invincibility : MonoBehaviour
    {
        [SerializeField] private AnimationScale _animationScale;

        private void Reset() => _animationScale = _animationScale != null ? _animationScale : GetComponent<AnimationScale>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Health health))
            {
                health.InvokeCarutina();
                EventBus.Instance.OnPlayAnimationInvincibilityUI?.Invoke();

                PlaySoundConsumables.Play(Consumables.Invincibility);

                _animationScale?.Play(() => { }, () => gameObject.SetActive(false));
            }
        }


    }
}