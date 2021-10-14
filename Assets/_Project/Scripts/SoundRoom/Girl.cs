using Bluehorse.Game.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        //GameManager.OnSpeechActive += GameManager_OnSpeechActive;
        MessageBus.OnSpeechActive.Receive += GameManager_OnSpeechActive;
    }

    private void Start()
    {
        SetPosition();
    }

    private void GameManager_OnSpeechActive(bool obj)
    {
        _animator.SetBool("Speech", obj);
    }

    private void OnDestroy()
    {
        MessageBus.OnSpeechActive.Receive -= GameManager_OnSpeechActive;
    }

    public void SetPosition()
    {
        transform.position = new Vector3(1.32f, -1.53f, -0.046875f);
    }
}