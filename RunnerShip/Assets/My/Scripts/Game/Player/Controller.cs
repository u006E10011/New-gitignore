using Project.Input;
using Project.System;
using System.Collections;
using UnityEngine;
using YG;

namespace Project.Game.Player
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotate;
        [SerializeField] private float _rotationLimit = 45f;

        [SerializeField] private Joystick _joystick;

        private float _maxSpeed;
        private float _currentRotation;
        private int _upperValueSpeed;

        [SerializeField] private Rigidbody _rb;

        private void OnValidate()
        {
            _rb = _rb != null ? _rb : GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            YandexGame.GetDataEvent += GetData;
            EventBus.Instance.OnUpperSpeed += UpperSpeed;
        }
        private void OnDisable()
        {
            YandexGame.GetDataEvent -= GetData;
            EventBus.Instance.OnUpperSpeed -= UpperSpeed;
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled)
                GetData();
        }

        private void GetData()
        {
            _maxSpeed = _speed = YandexGame.savesData.Data.Speed;
            _rotate = YandexGame.savesData.Data.Rotate;
        }

        private void FixedUpdate() => Move();
        private void Update() => Rotate();

        public Coroutine Coroutine(float percent, float delay) => StartCoroutine(ChangedSpeed(percent, delay));

        public void UpperSpeed(int value) => _upperValueSpeed = value;

        private void Move() => _rb.velocity = transform.forward * (_speed + _upperValueSpeed) * Time.fixedDeltaTime;

        private void Rotate()
        {
            if (InputTouch.Direction != 0 && UnityEngine.Input.GetMouseButton(0))
            {
                float targetRotation = _currentRotation + InputTouch.Direction * _rotate * Time.deltaTime;
                targetRotation = Mathf.Clamp(targetRotation, -_rotationLimit, _rotationLimit);

                _currentRotation = Mathf.Lerp(_currentRotation, targetRotation, Time.deltaTime * _rotate);
                transform.rotation = Quaternion.Euler(0f, _currentRotation, 0f);
            }
        }

        private IEnumerator ChangedSpeed(float percent, float delay)
        {
            _speed += (_maxSpeed / 100) * percent;

            yield return new WaitForSeconds(delay);

            _speed = _maxSpeed;
        }

        private float PlayerPositionZ() => transform.position.z;
    }
}
