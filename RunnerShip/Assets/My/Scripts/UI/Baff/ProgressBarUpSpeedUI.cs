using Project.System;
using UnityEngine;
using YG;

namespace Project.UI.Baff
{
    public class ProgressBarUpSpeedUI : ViewDurationBaff
    {
        private void OnEnable() => EventBus.Instance.OnPlayAnimationUpSpeedUI+= Animation;
        private void OnDisable() => EventBus.Instance.OnPlayAnimationUpSpeedUI -= Animation;

        public void Start() => Duration = YandexGame.savesData.Data.DurationUpSpeed;

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