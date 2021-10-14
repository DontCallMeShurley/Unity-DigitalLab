using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class audio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] audioo = new AudioClip[20];
    public bool sound_1;
    public bool hotfree;
    public GameObject Fish;
    public GameObject girl;
    public bool sound_2;
    public bool sound_3;
    public bool sound_5;
    public SerialPortWrapper sp;
    public Text text;
    public bool start;
    public GameObject shkala;
    public bool sound_4;
    public int a=0;
    public int b = 0;
    bool teat;
    public bool sound_6;
    public bool sound_7;
    public bool sound_8;
    public bool sound_9;
    public float f = 0;
    public static int k = 0;
    public bool sound_10;
   public float chea1 = 0;
    int p = 0;
    bool checkfree;
    // Start is called before the first frame update
    void Start()
    {
        sp.BaudRate = 9600;
        
    }

    // Update is called once per frame
    void Update()
    {
     

        if ((sound_1) && (!source.isPlaying))
        {
            source.clip = audioo[0];
            source.Play();
            sound_1 = false;
            girl.GetComponent<Animator>().Play("speak");
        }
        if (hotfree)
        {

            girl.GetComponent<Animator>().Play("idle");
            Fish.GetComponent<Animator>().Play("freezing");
            Invoke("frost", 1f);
            hotfree = false;
        }
        if ((sound_2) && (!source.isPlaying))
        {
            source.clip = audioo[1];
            source.Play();
            sound_2 = false;
            girl.GetComponent<Animator>().Play("speak 3");
        }
        if ((sound_3) && (!source.isPlaying))
        {
            source.clip = audioo[2];
            source.Play();
            sound_3 = false;
            girl.GetComponent<Animator>().Play("speak 6");
        }
        if ((sound_6) && (!source.isPlaying))
        {
            source.clip = audioo[7];
            source.Play();
            sound_6 = false;
            girl.GetComponent<Animator>().Play("speak 12");
        }
        if ((sound_7) && (!source.isPlaying))
        {
            source.clip = audioo[9];
            source.Play();
            sound_7 = false;
            girl.GetComponent<Animator>().Play("speak 16");
            Fish.GetComponent<Animator>().Play("idle");
        }
        if ((sound_8) && (!source.isPlaying))
        {
            source.clip = audioo[10];
            source.Play();
            sound_8 = false;
            girl.GetComponent<Animator>().Play("speak 18");
        }
        if ((sound_9) && (!source.isPlaying))
        {
            source.clip = audioo[12];
            source.Play();
            sound_9 = false;
            girl.GetComponent<Animator>().Play("speak 20");
        }
        if ((sound_10) && (!source.isPlaying))
        {
            source.clip = audioo[13];
            source.Play();
            sound_10 = false;
            girl.GetComponent<Animator>().Play("speak 24");
        }
        /*   if ((sound_4) && (!source.isPlaying))
           {
               source.clip = audioo[3];
               source.Play();
               sound_4 = false;
           }*/

        if (start)
        {
            girl.GetComponent<Animator>().Play("idle 0");
            if (!sp.IsOpen)
            {
                k++;
                if (k < 10)
                {
                    
                    sp.Open();
                    sp.ReadTimeout = 1;
                    start = false;
                    InvokeRepeating("Resolocation", 0.1f, 0.1f);//если меньше 10 фпс ставьте повторения на 0.132f
                }
            }
            if (k == 10)
            {
                if (!source.isPlaying)
                {
                    source.clip = audioo[17];
                    source.Play();

                }
                girl.GetComponent<Animator>().Play("speak 34");
             
            }
        }
    }
    void frost()
    {
        Fish.GetComponent<Animator>().Play("frost");
        Invoke("hot", 3f);
    }
    void hot()
    {
        Fish.GetComponent<Animator>().Play("hot");
        Invoke("idle", 3f);
    }
    void idle()
    {
        Fish.GetComponent<Animator>().Play("idle");
    }
    void chea()
    {
        chea1 = f;
    }
    void FishAnim(float a)
    {
        if ((a >= 10 && a <= 30))
        {
            checkfree = false;
            Fish.GetComponent<Animator>().Play("happy");
        }

        if ((a < 10))
        {
            if (!checkfree)
            {
                Fish.GetComponent<Animator>().Play("freezing");
                Invoke("frost1", 1f);
            }
        }
        if ((a > 30))
        {
            checkfree = false;
            Fish.GetComponent<Animator>().Play("hot");
        }
    }
    void frost1()
    {
        checkfree = true;
        Fish.GetComponent<Animator>().Play("frost");
    }
    private void Resolocation()
    {

        {
            string s = sp.ReadLine();
           
            s = s.Substring(s.IndexOf("t") + 1, s.IndexOf(";") - s.IndexOf("t") - 1);
            f = (float.Parse(s) /100) ;
            shkala.transform.position = Vector3.Lerp(shkala.transform.position, new Vector3(shkala.transform.position.x, (-2.68f + (f * 0.05f)/2), shkala.transform.position.z), 0.1f);
            shkala.transform.localScale = new Vector3(shkala.transform.localScale.x, 4.6737f + (f * 0.09096f)/2, shkala.transform.localScale.z);
            text.text = (Mathf.Round(f)).ToString() ;
            if ((f < 20.5) && (f > 19.5) && (k==1))
            {
                CancelInvoke("Resolocation");
                sp.Close();
                girl.GetComponent<Animator>().Play("speak 5");
                if (!source.isPlaying)
                {
                    source.clip = audioo[3];
                    source.Play();
                    sound_3 = false;
                }
            }
            if ((f < 15.5) && (f > 14.5) && (k == 2))
            {
                CancelInvoke("Resolocation");
                sp.Close();
                girl.GetComponent<Animator>().Play("speak 9");
                if (!source.isPlaying)
                {
                    source.clip = audioo[4];
                    source.Play();
                    sound_4 = false;
                }
            }
            if ((f < 30.5) && (f > 29.5) && (k == 3))
            {
                CancelInvoke("Resolocation");
                sp.Close();
                girl.GetComponent<Animator>().Play("speak 9");
                if (!source.isPlaying)
                {
                    source.clip = audioo[5];
                    source.Play();
                    sound_5 = false;
                }
            }
            if ((f > 13.5) && (f < 14.5) && (k == 4))
            {
                CancelInvoke("Resolocation");
                sp.Close();
                girl.GetComponent<Animator>().Play("speak 8");
                if (!source.isPlaying)
                {
                    source.clip = audioo[6];
                    source.Play();
                    sound_6 = false;
                }
            }
            if ((f < 30.5) && (f > 29.5) && (k == 5))
            {
                CancelInvoke("Resolocation");
                sp.Close();
                girl.GetComponent<Animator>().Play("speak 15");
                Fish.GetComponent<Animator>().Play("hot");
                if (!source.isPlaying)
                {
                    source.clip = audioo[8];
                    source.Play();
                    
                }
            }
            if ((f < 25.5) && (f > 21.5) && (k == 6))
            {
                CancelInvoke("Resolocation");
                sp.Close();
                girl.GetComponent<Animator>().Play("speak 19");
                Fish.GetComponent<Animator>().Play("happy");
                if (!source.isPlaying)
                {
                    source.clip = audioo[11];
                    source.Play();

                }
            }
            if ((k == 7) || (k==8) || (k==9))
            {
                if (f - chea1 <= 0.2f)
                {
                    CancelInvoke("Resolocation");
                    sp.Close();
                    p++;
                    if (!source.isPlaying)
                    {
                        source.clip = audioo[13 + p];
                        source.Play();

                    }
                    girl.GetComponent<Animator>().Play("speak 33");
                    FishAnim(f);


                }
                else Invoke("chea",0.7f);
            }
        }
       

    }
}
