using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class Recolocation:MonoBehaviour {
    public GameObject game;
    public bool B_Check;
    public SerialPort sp = new SerialPort("COM3", 1200);
    public Text text;
    
    public float maxtemp;
    public float mintemp;
    public GameObject Fish;
    bool checkfree;
    public  AudioClip[] audio = new AudioClip[20];
    bool check;
    public GameObject girl;
    public AudioSource source;
     int it = 0;


    private void Updat1e()
    {
        //сценарий
        if (it == 0)
        {
           
            if ((!source.isPlaying) && (!check))
            {
                check = true;
                Fish.GetComponent<Animator>().Play("freezing");

                /*        var animatorStateInfo = Fish.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
                      // смотрим, есть ли в нем имя какой-то анимации, то возвращаем true
                      if (!animatorStateInfo.IsName("freezing"))
                      {
                          Fish.GetComponent<Animator>().Play("freezing");
                      }*/
                Invoke("hot", 1f);
            }
        }
        


    }

    void hot()
    {
        Fish.GetComponent<Animator>().Play("hot");
        Invoke("Idle", 1f);
    }
    void Idle()
    {
        Fish.GetComponent<Animator>().Play("idle");
    }
    public void Start1()
    {
        if (!B_Check)
        {
            B_Check = true;
            sp.Open();

        }
        else
        {
            B_Check = false;
            sp.Close();

        }
    
       InvokeRepeating("Resolocation", 0.1f, 0.132f);
       // Process.Start("C:\\Users/lord1/source/repos/ConsoleApp15/ConsoleApp15/bin/Debug/ConsoleApp15.exe");
       // Invoke("Resolocation", 0.1f);
    }
    public void Stop()
    {
        B_Check = false;
        sp.Close();
    }
        private void Resolocation()
    {
        if (B_Check)
        {
            string s= sp.ReadLine();
            s = s.Substring(s.IndexOf('T') + 1, s.IndexOf('E') - s.IndexOf('T') - 1);
            float f = (float.Parse(s.Substring(0, s.IndexOf('.'))) / 100);
            game.transform.position = Vector3.Lerp(game.transform.position,new Vector3(game.transform.position.x, (-2.68f + (f * 0.05f)), game.transform.position.z),0.1f);
            game.transform.localScale = new Vector3(game.transform.localScale.x, 4.6737f + (f  * 0.09096f), game.transform.localScale.z);
            text.text = f.ToString();
            FishAnim(f);
        }

        
   
    }
     void FishAnim(float a)
    {
        if ((a >= mintemp && a <= maxtemp))
        {
            checkfree = false;
            Fish.GetComponent<Animator>().Play("happy");
        }

        if ((a < mintemp) )
        {
            if (!checkfree)
            {
                Fish.GetComponent<Animator>().Play("freezing");
                Invoke("frost", 1f);
            }
        }
        if ((a > maxtemp))
        {
            checkfree = false;
            Fish.GetComponent<Animator>().Play("hot");
        }
    }
    void frost()
    {
        checkfree = true;
        Fish.GetComponent<Animator>().Play("frost");
    }


    }

