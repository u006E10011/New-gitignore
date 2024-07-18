using Project.Game.Player;
using UnityEngine;

namespace Project.Game.Core
{
    public class Zone : MonoBehaviour
    {
        [SerializeField] private float _limit = 100;
        [SerializeField] private Transform _player;

        private void OnEnable () => _player = FindObjectOfType<Controller>().transform;

        private void Update() => _player.transform.position = new Vector3(Mathf.Clamp(_player.transform.position.x, -_limit, _limit), _player.transform.position.y, _player.transform.position.z);
    }
}