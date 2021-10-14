using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;


public class Recolocation1 : MonoBehaviour
{
    public SerialPortWrapper sp;
    public bool B_Check;
    public GameObject[] lamp1 = new GameObject[21];
    public GameObject[] gg = new GameObject[5];
    public SpriteRenderer sr;
    public AudioSource source;
    public AudioClip[] audioo = new AudioClip[20];
    public bool sound_1;
    public bool sound_2;
    public bool sound_3;
    public bool sound_4;
    public bool sound_5;
    public bool sound_6;
    public bool sound_7;
    public bool sound_8;
    public bool sound_9;
    public bool sound_10;
    public bool sound_11;
    public bool sound_12;
    public bool sound_13;
    public bool sound_14;
    public bool sound_15;
    public GameObject girl;
    public bool start;
    int k = 0;
    public GameObject[] gg1 = new GameObject[3];


    public Text text1;
    void Start()
    {
        sp.BaudRate = 9600;
    }

    void Update()
    {
        for (int i = 0; i < 21; i++)
        {
            if (lamp1[i].activeSelf == true)
            {
                int j = (i+1) / 5;
                for (int k = 0; k < j; k++)
                    gg[k].SetActive(true);
            }
            if (i < 21)
            {
                int a = i+1 / 5;
                for (int e = a; e < 4; e++)
                    gg[e].SetActive(false);
            }
        }

        if ((sound_1) && (!source.isPlaying))
        {
            source.clip = audioo[0];
            source.Play();
            sound_1 = false;
            girl.GetComponent<Animator>().Play("speak");
        }
        if ((sound_2) && (!source.isPlaying))
        {
            source.clip = audioo[1];
            source.Play();
            sound_2 = false;
            girl.GetComponent<Animator>().Play("speak 1");
        }
        if ((sound_3) && (!source.isPlaying))
        {
            source.clip = audioo[2];
            source.Play();
            sound_3 = false;
            girl.GetComponent<Animator>().Play("speak 2");
        }
        if ((sound_4) && (!source.isPlaying))
        {
            source.clip = audioo[3];
            source.Play();
            sound_4 = false;
            girl.GetComponent<Animator>().Play("speak 5");
        }
        if ((sound_5) && (!source.isPlaying))
        {
            source.clip = audioo[4];
            source.Play();
            sound_5 = false;
            girl.GetComponent<Animator>().Play("speak 6");
        }
        if ((sound_6) && (!source.isPlaying))
        {
            source.clip = audioo[5];
            source.Play();
            sound_6 = false;
            girl.GetComponent<Animator>().Play("speak 7");
        }
        if ((sound_7) && (!source.isPlaying))
        {
            source.clip = audioo[6];
            source.Play();
            sound_7 = false;
            girl.GetComponent<Animator>().Play("speak 8");
        }
        if ((sound_8) && (!source.isPlaying))
        {
            source.clip = audioo[7];
            source.Play();
            sound_8 = false;
            girl.GetComponent<Animator>().Play("speak 9");
        }

        if (start)
        {
            sp.Open();
            sp.ReadTimeout = 1;
            girl.GetComponent<Animator>().Play("idle 0");
            InvokeRepeating("Resolocation", 0.01f, 0.1f);
            Invoke("stopi", 15f);
            start = false;
        }
    }

    private void stopi()
    {
        gg1[0].SetActive(false);
        gg1[1].SetActive(true);
        gg1[2].SetActive(true);
        gg1[3].SetActive(false);
        gg1[4].SetActive(true);
        sp.Close();
        CancelInvoke("Resolocation");
        
        girl.GetComponent<Animator>().Play("next"+k.ToString());
        k++;

    }
 

    private void Resolocation()
    {
        
        
         string   s = sp.ReadLine();
 
            s = s.Substring(s.IndexOf('i') + 1, s.IndexOf(';') - s.IndexOf('i') - 1);
            int f = (Convert.ToInt32(s));
            
            text1.text = f.ToString();
        if (f > 1260) f = 1260;
            int n = f / 60;
            if (n >= 0)
            {
                if (n <= 21)
                {
                    for (int i = 0; i < n; i++)
                    {

                        lamp1[i].SetActive(true);
                    }
                    if (n < 21)
                        for (int i = n; i < 21; i++)
                        {

                            lamp1[i].SetActive(false);
                        }
                }

            
        }
    }
    

}


    


