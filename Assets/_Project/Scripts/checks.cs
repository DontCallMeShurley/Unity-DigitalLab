using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checks : MonoBehaviour
{
    public GameObject gg;
    public bool k1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("kek", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void kek()
    {
        if (k1)
        {
            gg.SetActive(true);
            CancelInvoke("kek");
        }
    }
}
