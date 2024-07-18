using Project.System;
using UnityEngine;
using YG;

namespace Project.Game.Player
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private float _durationInvulnerability = 3;

        [SerializeField, Space(10)] private AnimationPlayer _animation;

        private int _maxHealth;

        public Coroutine Carutina;

        public Invulnerability Invulnerability = new();

        private void OnEnable()
        {
            YandexGame.GetDataEvent += GetData;
            EventBus.Instance.OnDamaged += TakeDamage;
            EventBus.Instance.OnDied += Died;
        }
        private void OnDisable()
        {
            YandexGame.GetDataEvent -= GetData;
            EventBus.Instance.OnDamaged -= TakeDamage;
            EventBus.Instance.OnDied -= Died;
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled)
                GetData();
        }

        private void GetData()
        {
            _maxHealth = _health = YandexGame.savesData.Data.MaxHealth;
            _durationInvulnerability = YandexGame.savesData.Data.DurationInvincibility;

            EventBus.Instance.OnChangedHealth?.Invoke(_maxHealth, _health);
        }

        public void Add(int value)
        {
            if (_maxHealth > _health)
                _health += value;

            EventBus.Instance.OnChangedHealth?.Invoke(_maxHealth, _health);
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            _animation.AnimationTakingDamage.Play(() => { }, () => { });
            EventBus.Instance.OnChangedHealth?.Invoke(_maxHealth, _health);

            if (_health <= 0)
                EventBus.Instance.OnDied?.Invoke();
            else
            {
                EventBus.Instance.OnSoundOfTakingDamage?.Invoke();

                InvokeCarutina();
            }
        }

        public void InvokeCarutina()
        {
            if (Carutina != null)
                StopCoroutine(Carutina);

            Carutina = StartCoroutine(Invulnerability.InvincibilityTimer(_durationInvulnerability));
        }

        private void Died()
        {
            InvokeCarutina();

            _animation.Died(() =>
            {
                GetComponent<Controller>().enabled = false;
            });
        }


    }
}