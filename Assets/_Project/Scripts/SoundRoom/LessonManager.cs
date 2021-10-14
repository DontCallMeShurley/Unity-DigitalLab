using Bluehorse.Game.Messages;
using System;
using UniRx;
using UnityEngine;

public class LessonManager : MonoBehaviour
{
    //public static event Action<LessonStep> OnStepRun;

    public LessonStepList stepList;

    private LessonStep _currentStep;

    //private void Awake()
    //{

    //}


    //private void OnDestroy()
    //{
    //    GameManager.OnStepFinished -= GameManager_OnStepFinished;
    //    GameManager.OnLessonStart -= GameManager_OnLessonStart;
    //}

    private void GameManager_OnLessonStart()
    {
        _currentStep = stepList.Data[0];
        RunStep(_currentStep);
    }

    private void GameManager_OnStepFinished()
    {
        var nextStepIndex = stepList.Data.IndexOf(_currentStep) + 1;
        _currentStep = stepList.Data[nextStepIndex];

        RunStep(_currentStep);
    }

    private void RunStep(LessonStep value)
    {
        MessageBus.OnStepRun.Send(value);
        //OnStepRun?.Invoke(value);
    }

    private void OnEnable()
    {
        MessageBus.OnStepFinished.Receive += GameManager_OnStepFinished;
        MessageBus.OnLessonStart.Receive += GameManager_OnLessonStart;
        //GameManager.OnStepFinished += GameManager_OnStepFinished;
        //GameManager.OnLessonStart += GameManager_OnLessonStart;
    }

    private void OnDisable()
    {
        MessageBus.OnStepFinished.Receive -= GameManager_OnStepFinished;
        MessageBus.OnLessonStart.Receive -= GameManager_OnLessonStart;
    }
}
