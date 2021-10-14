using Bluehorse.Game.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    public Animation ani;
    public GameObject gg;
    public string s;
    public bool kek;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("start1", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start1()
    {
        if (kek)
        {
            //gg.GetComponent<Animator>().Play(s);
            //CancelInvoke("start1");

            MessageBus.OnTemperatureDeviceSetActive.Send(true);
        }
    }
}
