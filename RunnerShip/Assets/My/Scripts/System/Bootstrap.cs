using Project.Game.Core;
using Project.Game.Player;
using Project.Game.Score;
using Project.UI;
using UnityEngine;

namespace Project.System
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private Score _score;
        [SerializeField] private GeneratorObstacls _lifeGeneratorObstacls;
        [SerializeField] private Transform _player;

        private void Awake()
        {
            _lifeGeneratorObstacls.Init(_player);
        }

        private void Start() => EventBus.Instance.OnStartGame?.Invoke();
    }
}