using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    public GameObject gameManagerTemplate;

    private void Start()
    {
        Instantiate(gameManagerTemplate);
    }
}
