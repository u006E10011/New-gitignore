using DG.Tweening;
using Project.Language;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace Project.UI
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private int _indexScene;
        [SerializeField] private float _delayStartAnimation;
        [SerializeField] private float _speedAnimationProgress;

        private string _progressValue;
        private string _playTextValue;

        private AsyncOperation _asyncOperation;

        [SerializeField, Space(10)] private TMP_Text _ProgressText;
        [SerializeField] private TMP_Text _playText;

        [SerializeField] private Translate _translateProgress;
        [SerializeField] private Translate _translatePlay;

        private void OnEnable() => YandexGame.GetDataEvent += GetText;
        private void OnDisable() => YandexGame.GetDataEvent -= GetText;

        private void Start()
        {
            Invoke(nameof(GetText), .1f);
            StartCoroutine(LoadScene());
        }

        public void Load() => _asyncOperation.allowSceneActivation = true;

        private void Update()
        {
            if (_asyncOperation != null && _asyncOperation.progress >= 0.89f)
            {
                _ProgressText.enabled = false;
                _playText.enabled = true;
            }
        }

        private IEnumerator LoadScene()
        {
            AnimationPropgress();

            yield return new WaitForSecondsRealtime(_delayStartAnimation);

            _asyncOperation = SceneManager.LoadSceneAsync(_indexScene);
            _asyncOperation.allowSceneActivation = false;

            while (_asyncOperation.allowSceneActivation)
                yield return null;

        }

        private void GetText()
        {
            _progressValue = _translateProgress.Value;
            _playTextValue = _translatePlay.Value;
        }

        private void AnimationPropgress()
        {
            var tween = DOTween.Sequence()
               .AppendCallback(() => _ProgressText.text = _progressValue + ".")
               .AppendInterval(_speedAnimationProgress)
               .AppendCallback(() => _ProgressText.text = _progressValue + "..")
               .AppendInterval(_speedAnimationProgress)
               .AppendCallback(() => _ProgressText.text = _progressValue + "...")
               .AppendInterval(_speedAnimationProgress)
               .SetLoops(-1, LoopType.Restart)
               .SetRelative()
               .SetEase(Ease.Linear);

            tween.SetLink(gameObject);
        }
    }
}