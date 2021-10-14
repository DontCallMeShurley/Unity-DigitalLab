using System;
using UnityEngine;

public enum LessonStepID
{
    step01,
    step02,
    step03,
    step04,
    step05,
    step06,
    step07,
    step08,
    step09,
    step10,
    step11,
    step12,
    step13,
    step14,
    step15,
    step16,
    step17,
    step18,
    step19,
    step20,
    step21,
    step22
}

[Serializable]
public struct Sound
{
    public LessonStepID lessonStepID;
    public AudioClip[] audioClips;
    public float volume;

    public Sound(LessonStepID lessonStepID, AudioClip[] audioClips, float volume)
    {
        this.lessonStepID = lessonStepID;
        this.audioClips = audioClips;
        this.volume = 1;
    }
}
