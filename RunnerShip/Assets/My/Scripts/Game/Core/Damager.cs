using Project.Game.Player;
using Project.System;
using UnityEngine;

namespace Project.Game.Core
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
            {
                if (!health.Invulnerability.IsInvincible)
                    EventBus.Instance.OnDamaged?.Invoke(_damage);
            }
        }
    }
}