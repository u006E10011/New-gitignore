using Project.Game.Player;
using Project.System;
using UnityEngine;
using YG;

namespace Project.Game.Score
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Controller _player;

        private float _value;

        private void OnValidate() => _player = _player ? _player : FindObjectOfType<Controller>();

        private void Update() => Add();

        public void Add()
        {
            _value = _player.transform.position.z;

            EventBus.Instance.OnViewGUIScore?.Invoke(Mathf.FloorToInt(_value));

            if (YandexGame.savesData.Data.MaxScore < _value)
                YandexGame.savesData.Data.MaxScore = Mathf.FloorToInt(_value);
        }
    }
}