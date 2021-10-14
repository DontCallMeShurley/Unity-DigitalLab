using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Bluehorse.Game.Messages;
using UnityEngine.UI;

public class TemperatureDevice : MonoBehaviour
{
    public Text text;
    public RectTransform panel;

    public float posXShow = -672.2f;
    public float posXHide = -1267;

    private void OnEnable()
    {
        MessageBus.OnTemperatureDeviceSetActive.Receive += EventsManager_OnPitchDeviceSetActive;
        MessageBus.OnAnalyzeTemperature.Receive += OnAnalyzeTemperature_Receive; ;
    }

    private void OnAnalyzeTemperature_Receive(float obj)
    {
        text.text = $"{obj.ToString("F0")}";
    }

    private void OnDisable()
    {
        MessageBus.OnTemperatureDeviceSetActive.Receive -= EventsManager_OnPitchDeviceSetActive;
        MessageBus.OnAnalyzeTemperature.Receive -= OnAnalyzeTemperature_Receive;
    }

    private void Start()
    {


        panel.DOAnchorPosX(posXHide, 0);
    }

    private void EventsManager_OnPitchDeviceSetActive(bool obj)
    {
        SetActive(obj);
    }

    private void OnDestroy()
    {

    }

    public void SetActive(bool value, TweenCallback callback = null)
    {
        if (value)
        {
            panel.DOAnchorPosX(posXShow, 1).OnComplete(callback); ;
        }
        else
        {
            panel.DOAnchorPosX(posXHide, 1).OnComplete(callback); ;
        }


    }
}