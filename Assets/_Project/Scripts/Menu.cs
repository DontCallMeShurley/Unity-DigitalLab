using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public Button gg;
    public Button gg1;
    public Button gg2;
    public Button gg3;
    public Scrollbar sc;
    public Text text;
   
    float n = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        sc.value = 0;
    }
  public void Start1()
    {
        n = sc.value;
        if (sc.value == 0)
        InvokeRepeating("scroll0", 0.1f, 0.05f);
        if ((sc.value > 0.45f) && (sc.value <= 0.52f))
            InvokeRepeating("scroll5", 0.1f, 0.05f);
    }

    void scroll0()
    {
        if (sc.value < 0.5) 
        n = n + 0.125f;
        sc.value = n;
        if ((sc.value > 0.45f) && (sc.value <= 0.52f))
            CancelInvoke("scroll0");
    }

    void scroll5()
    {
        if (sc.value < 1)
            n = n + 0.125f;
        sc.value = n;
        if (sc.value >= 1f)
            CancelInvoke("scroll5");
    }
    
    public void Start2()
    {
        n = sc.value;
        if (sc.value > 0.95f)
            InvokeRepeating("scroll1", 0.1f, 0.05f);
        if ((sc.value > 0.45f) && (sc.value <= 0.52f))
            InvokeRepeating("scroll2", 0.1f, 0.05f);
    }

    void scroll1()
    {
        if (sc.value > 0.5)
            n = n - 0.125f;
        sc.value = n;
        if ((sc.value > 0.45f) && (sc.value <= 0.52f))
            CancelInvoke("scroll1");

    }
    void scroll2()
    {
        if (sc.value > 0)
            n = n - 0.125f;
        
        else CancelInvoke("scroll2");sc.value = n;
    }
    private void Update()
    {
        if (sc.value < 0)
            sc.value = 0;
        if (sc.value > 1)
            sc.value = 1;
    }
}
