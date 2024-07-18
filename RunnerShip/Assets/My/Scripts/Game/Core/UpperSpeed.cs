using Project.System;
using UnityEngine;

namespace Project.Game.Core
{
    public class UpperSpeed : MonoBehaviour
    {
        [SerializeField] private float _upValue = 1;

        private float _value;

        private void Update() => Add();

        public void Add()
        {
            _value += _upValue * Time.deltaTime;

            EventBus.Instance.OnUpperSpeed?.Invoke((int)_value);
        }

    }
}
