using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetViewPortCoordinates : MonoBehaviour
{
    public GameObject go;
    public float xVal;

    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Update()
    {
        if (!go) return;

        GetCoord();
    }

    public void GetCoord()
    {
        var coord = Camera.main.WorldToViewportPoint(go.transform.position);
        Debug.Log($"coord: {coord}");
    }

    public void SetCoord()
    {
        var resultPos = Camera.main.ViewportToScreenPoint(new Vector2(xVal, 0));
        go.transform.position = new Vector3(resultPos.x, 0, -0.87f);
    }

    public void SetCoord2()
    {
        Vector3 viewPos = go.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        go.transform.position = viewPos;
    }

    void Start()
    {
        MainCamera = Camera.main;

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = go.transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = go.transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

}
