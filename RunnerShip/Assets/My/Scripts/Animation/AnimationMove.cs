using DG.Tweening;
using UnityEngine;

namespace Project.Animation
{
    public class AnimationMove : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _delay;

        [SerializeField, Space(10)] private float _targetPositionY;

        [SerializeField, Space(10)] private Transform _target;

        private void OnValidate() => _target = _target ? _target : transform;

        public void Play()
        {
            var tween = DOTween.Sequence()
                .AppendInterval(_delay)
                .Append(_target.DOMove(new Vector3(_target.position.x, _targetPositionY, _target.position.z), _duration));

            tween.SetLink(_target.gameObject);
        }
    }
}