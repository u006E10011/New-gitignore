using Project.System;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class EventUI : MonoBehaviour
{
    [SerializeField] private GameObject _shopButton;
    [SerializeField] private GameObject _closeUIButton;

    [Space(10)]

    public UnityEvent _isOpenUI;
    public UnityEvent _isCloseUI;

    private void OnEnable()
    {
        EventBus.Instance.OnDied += InvokeOpen;
        EventBus.Instance.OnDied += EnableShopButton;
        EventBus.Instance.OnDied += DisableCloseUIButton;

        _isOpenUI.AddListener(delegate
        {
            TimeScaleZero();
            EventBus.Instance.OnSetInMenuSnapshot?.Invoke();
            EventBus.Instance.OnViewMaxScore?.Invoke(YandexGame.savesData.Data.MaxScore);
        });

        _isCloseUI.AddListener(delegate
        {
            TimeScaleFirst();
            EventBus.Instance.OnSetNormalSnapshot?.Invoke();
        });

        EventBus.Instance.OnViewMaxScore?.Invoke(YandexGame.savesData.Data.MaxScore);
    }

    private void OnDisable()
    {
        EventBus.Instance.OnDied -= InvokeOpen;
        EventBus.Instance.OnDied -= EnableShopButton;
        EventBus.Instance.OnDied -= DisableCloseUIButton;

        _isOpenUI.RemoveListener(delegate
        {
            TimeScaleZero();
            EventBus.Instance.OnViewMaxScore?.Invoke(YandexGame.savesData.Data.MaxScore);
            EventBus.Instance.OnSetInMenuSnapshot?.Invoke();
        });

        _isCloseUI.RemoveListener(delegate
        {
            TimeScaleFirst();
            EventBus.Instance.OnSetNormalSnapshot?.Invoke();
        });
    }

    public void InvokeOpen() => _isOpenUI?.Invoke();
    public void InvokeClose() => _isCloseUI?.Invoke();

    private void EnableShopButton() => _shopButton.SetActive(true);
    private void DisableCloseUIButton() => _closeUIButton.SetActive(false);

    private void TimeScaleZero() => Time.timeScale = 0;
    private void TimeScaleFirst() => Time.timeScale = 1;
}
