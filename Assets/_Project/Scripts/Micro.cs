using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class Micro : MonoBehaviour
{
    public float sensitivity = 100; // чувствительность
    public float loudness = 0; // громкость
    public Text text;
    public float f;
    public float rest = 0;
    void Start()
    {
        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 10, 44100);
        GetComponent<AudioSource>().loop = true; // зацикливаем клип
      //  GetComponent<AudioSource>().mute = true; // отключаем звук
       while (!(Microphone.GetPosition(null) > 0)) { } // Ждем пока запись начнется
        GetComponent<AudioSource>().Play(); // Проигрываем запись
        InvokeRepeating("kek", 0.1f, 0.2f);
    }

    void kek()
    {
        loudness = GetAveragedVolume() * sensitivity;
        text.text = loudness.ToString();
      

    }

    float GetAveragedVolume()  // метод получения громкости
    {
        float[] data = new float[256];
        float[] data1 = new float[1024];
        float a = 0;
        float a1 = 0;
        GetComponent<AudioSource>().GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
         return a / 256;
        
       
    }

}

