using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Project.Animation
{
    public class AnimationScaleUI : MonoBehaviour
    {
        [SerializeField] private float _startDuration = 0.05f;
        [SerializeField] private float _endDuration;

        [SerializeField, Space(10)] private bool _isResetScale = true;

        [SerializeField, Space(10)] private Vector3 _startScale = new(1, 1, 1);
        [SerializeField] private Vector3 _targetScale = new(1.05f, 1.05f, 1.05f);

        [SerializeField, Space(10)] private Button _button;
        [SerializeField] private RectTransform _transform;

        private UnityAction _action;

        private void Reset()
        {
            _button = _button != null ? _button : GetComponent<Button>();
            _transform = _transform != null ? _transform : GetComponentInChildren<RectTransform>();
        }

        private void Awake() => _action = _isResetScale ? ResetToStartScale : SetScale;

        private void OnEnable() => _button.onClick?.AddListener(_action);
        private void OnDisable() => _button.onClick?.RemoveListener(_action);

        public void SetScale() => _transform.DOScale(_targetScale, _startDuration);

        public void ResetToStartScale()
        {
            var tween = DOTween.Sequence()
                .Append(_transform.DOScale(_targetScale, _startDuration))
                .AppendInterval(_endDuration)
                .Append(_transform.DOScale(_startScale, _endDuration));

            tween.SetLink(gameObject);
        }
    }
}