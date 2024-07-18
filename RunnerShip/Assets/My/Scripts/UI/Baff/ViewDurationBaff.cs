using Project.Sound;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI.Baff
{
    public abstract class ViewDurationBaff : MonoBehaviour
    {
        public bool IsActiveBuff { get; private set; }

        protected float Duration;

        private float CurrentTime;

        [SerializeField, Space(10)] protected Color32 FirstColor;
        [SerializeField] protected Color32 SecondColor;

        [SerializeField, Space(10)] protected Image ProgressBar;
        [SerializeField] protected TMP_Text TextValue;

        [SerializeField] private SoundEndBaffActivity _sound;

        protected Coroutine Coroutine;

        private void Reset()
        {
            ProgressBar = ProgressBar != null ? ProgressBar : GetComponent<Image>();
            TextValue = TextValue != null ? TextValue : GetComponentInChildren<TMP_Text>();

            FirstColor = Color.green;
            SecondColor = Color.red;
        }

        public virtual IEnumerator Animation(float duration)
        {
            ProgressBar.enabled = true;

            CurrentTime = Duration;

            yield return new WaitForSeconds(duration);

            IsActiveBuff = false;

            ProgressBar.enabled = false;
            TextValue.enabled = false;

            _sound.Play();
        }

        public void ResetValue()
        {
            CurrentTime = Duration;
            IsActiveBuff = true;
            ProgressBar.enabled = true;
            TextValue.enabled = true;
        }

        public void Fill(float duration)
        {
            CurrentTime -= Time.deltaTime;
            ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount, CurrentTime / duration, Time.deltaTime * duration);

            TextValue.text = CurrentTime.ToString("F1");
        }

        public void UpdateColor(float duration)
        {
            Color color = Color.Lerp(SecondColor, FirstColor, CurrentTime / duration);
            ProgressBar.color = color;
        }
    }
}