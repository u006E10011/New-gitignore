using Project.System;
using YG;

namespace Project.UI.Baff
{
    public class ProgressBarInvincibilityUI : ViewDurationBaff
    {
        private void OnEnable() => EventBus.Instance.OnPlayAnimationInvincibilityUI += Animation;
        private void OnDisable() => EventBus.Instance.OnPlayAnimationInvincibilityUI -= Animation;

        public void Start() => Duration = YandexGame.savesData.Data.DurationInvincibility;

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