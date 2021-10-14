using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class FitCamera : MonoBehaviour
{
    private float baseAspect = 1920.0f / 1080.0f;

    void Start()
    {
        var currAspect = 1.0 * Screen.width / Screen.height;
        Debug.Log(Camera.main.projectionMatrix);
        Debug.Log(baseAspect + ", " + currAspect + ", " + baseAspect / currAspect);
        Camera.main.projectionMatrix = Matrix4x4.Scale(new Vector3((float)currAspect / baseAspect, 1.0f, 1.0f)) * Camera.main.projectionMatrix;
    }
}
