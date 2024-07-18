using DG.Tweening;
using UnityEngine;

namespace Project.Animation
{
    public class AnimationRotate : MonoBehaviour
    {
        [SerializeField] private RotateMode _rotateMove = RotateMode.FastBeyond360;
        [SerializeField] private LoopType _loopType = LoopType.Restart;
        [SerializeField] private Ease _ease = Ease.Linear;

        [SerializeField, Space(10)] private bool _isPlayingInStart;

        [SerializeField, Space(10)] private float _duration = 3;
        [SerializeField] private int _setLoops = -1;
        [SerializeField] private Vector3 _direction;

        [SerializeField, Space(10)] private Transform _target;

        private Tween _tween;

        private void OnValidate()
        {
            _target = _target ? _target : transform;
        }

        private void OnEnable()
        {
            if (_isPlayingInStart)
                Play();
        }
        private void OnDisable() => _tween.Kill();

        public void Play()
        {
                _tween = _target
                    .DORotate(_direction, _duration, _rotateMove )
                    .SetLoops(_setLoops, _loopType)
                    .SetRelative()
                    .SetEase(_ease)
                    .SetLink(gameObject);
        }
    }
}