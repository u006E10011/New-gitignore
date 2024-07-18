using Project.System;
using YG;

namespace Project.UI.Baff
{
    public class ProgressBarDownSpeedUI : ViewDurationBaff
    {
        private void OnEnable() => EventBus.Instance.OnPlayAnimationDownSpeedUI += Animation;
        private void OnDisable() => EventBus.Instance.OnPlayAnimationDownSpeedUI -= Animation;

        public void Start() => Duration = YandexGame.savesData.Data.DurationDownSpeed;

        private void Update()
        {
            if (IsActiveBuff)
            {
                Fill(Duration);
                UpdateColor(Duration);
            }
        }

        public void Animation()
        {
            ResetValue();

            if (Coroutine != null)
                StopCoroutine(Coroutine);

            Coroutine = StartCoroutine(base.Animation(Duration));
        }
    }
}