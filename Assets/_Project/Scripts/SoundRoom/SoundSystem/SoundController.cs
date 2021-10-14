using Bluehorse.Game.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SoundController : MonoSingleton<SoundController>
{
    public SoundLibrary SoundLibrary => soundLibrary;

    public object Obesrvable { get; private set; }

    [SerializeField] SoundLibrary soundLibrary;
    [SerializeField] AudioSource audioSource;

    public void PlaySound(LessonStepID soundName, Action callback = null)
    {
        Sound sound = soundLibrary.Data.Find(item => item.lessonStepID == soundName);
        audioSource.volume = sound.volume;
        //audioSource.PlayOneShot(sound.audioClip);

        foreach (var item in sound.audioClips)
        {
            audioSource.PlayOneShot(item);
        }
    }

    private void Awake()
    {
        MessageBus.OnSpeechActive.Receive += GameManager_OnSpeechActive;
        //GameManager.OnSpeechActive += GameManager_OnSpeechActive;
    }

    private void GameManager_OnSpeechActive(bool obj)
    {
       
    }

    private void OnDisable()
    {
        StopCoroutine(cor);
    }

    private void OnDestroy()
    {
        MessageBus.OnSpeechActive.Receive -= GameManager_OnSpeechActive;

    }

    private Coroutine cor;

    public void PlaySound1(LessonStepID soundName, Action callback = null)
    {
        //var cancel = Observable.FromCoroutine(PlaySoundRoutine).Subscribe().AddTo(this);

        if (cor != null)
        {
            StopCoroutine(cor);
            cor = null;
        }

        cor = StartCoroutine(PlaySoundRoutine(soundName, callback));
    }
    

    public IEnumerator PlaySoundRoutine(LessonStepID soundName, Action callback = null)
    {
        Sound sound = soundLibrary.Data.Find(item => item.lessonStepID == soundName);
        audioSource.volume = sound.volume;

        foreach (var item in sound.audioClips)
        {
            audioSource.PlayOneShot(item);

            yield return new WaitWhile(() => audioSource.isPlaying);
        }

        callback();
    }

   
}