using Project.Animation;
using Project.Game.Player;
using Project.Sound;
using Project.System;
using System;
using UnityEngine;
using YG;

namespace Project.Game.Baff
{
    public class SpeedControll : MonoBehaviour
    {
        [SerializeField] private Type _type;

        [SerializeField, Space(10)] private float _percent = 30;
        [SerializeField] private float _duration = 3;

        [SerializeField, Space(10)] private AnimationScale _animationScale;

        private Action _animation;

        public enum Type
        {
            Up,
            Down
        }

        private void Reset() => _animationScale = _animationScale != null ? _animationScale : GetComponent<AnimationScale>();

        private void OnEnable() => YandexGame.GetDataEvent += GetData;
        private void OnDisable() => YandexGame.GetDataEvent -= GetData;

        private void Start()
        {
            if (YandexGame.SDKEnabled)
                GetData();
        }

        private void GetData()
        {
            _percent = _type == Type.Up ? YandexGame.savesData.Data.PercentUpSpeed : -YandexGame.savesData.Data.PercentDownSpeed;
            _duration = _type == Type.Up ? YandexGame.savesData.Data.DurationUpSpeed : YandexGame.savesData.Data.DurationDownSpeed;

            _animation = _type == Type.Up ? EventBus.Instance.OnPlayAnimationUpSpeedUI : EventBus.Instance.OnPlayAnimationDownSpeedUI;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Controller controller))
            {
                controller.Coroutine(_percent, _duration);

                _animation?.Invoke();
                Sound();

                _animationScale?.Play(() => { }, () => gameObject.SetActive(false));
            }
        }

        private void Sound()
        {
            if (_type == Type.Up)
                PlaySoundConsumables.Play(Consumables.UpSpeed);
            else
                PlaySoundConsumables.Play(Consumables.DownSpeed);
        }
    }
}