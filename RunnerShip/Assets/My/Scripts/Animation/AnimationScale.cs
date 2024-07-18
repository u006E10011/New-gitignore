using DG.Tweening;
using System;
using UnityEngine;

namespace Project.Animation
{
    public class AnimationScale : MonoBehaviour
    {
        [SerializeField] private float _startDuration;
        [SerializeField] private float _endDuration;
        [SerializeField] private float _delay;

        [SerializeField, Space(10)] private Vector3 _targetScale;
        [SerializeField] private Vector3 _endScale;

        [SerializeField, Space(10)] private Transform _target;

        private void Reset()
        {
            _target = _target ? _target : transform;
            _endScale = _target ? _target.localScale : transform.localScale;
        }

        public void Play(Action OnStart, Action OnExit)
        {
            var tween = DOTween.Sequence()
                .AppendCallback(() => OnStart?.Invoke())
                .Append(_target.DOScale(_targetScale, _startDuration))
                .AppendInterval(_delay)
                .Append(_target.DOScale(_endScale, _endDuration))
                .AppendInterval(_delay)
                .AppendCallback(() => OnExit?.Invoke());

            tween.SetLink(gameObject);
        }
    }
}