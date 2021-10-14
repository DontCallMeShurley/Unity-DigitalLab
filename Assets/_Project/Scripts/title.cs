using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    public Scrollbar sc;
    public GameObject gg1;
    public GameObject gg2;
    // Start is called before the first frame update
   public void Start1()
    {
        CancelInvoke("Do");
        sc.value = 1;
        InvokeRepeating("Do", 0.1f, 0.001f);
    }
    void Do()
    {
        sc.value -= 0.0002f;
        if (sc.value < 0.05f)
            {
            gg1.SetActive(false);
            gg2.SetActive(true);
            CancelInvoke("Do");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
