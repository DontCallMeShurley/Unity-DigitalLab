using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehaviour : MonoBehaviour
{
    public void Rotate(float val)
    {
        var angle = Mathf.Lerp(500, 300, Mathf.InverseLerp(0, 100, val));
        transform.eulerAngles = new Vector3(0, 0, -angle);
    }
}
