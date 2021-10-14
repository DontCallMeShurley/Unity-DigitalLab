using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesScreenFitter : MonoBehaviour
{
    public GameObject[] sprites;
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        foreach (var item in sprites)
        {
            var objectWidth = item.transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
            var objectHeight = item.transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2

            SetRelatedPosition(item, new Vector2(objectWidth, objectHeight));
        }
    }

    public void SetRelatedPosition(GameObject go, Vector2 size)
    {
        Vector3 viewPos = go.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + size.x, screenBounds.x - size.x);
        //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + size.y, screenBounds.y - size.y);
        go.transform.position = viewPos;
    }

    Bounds GetMaxBounds(GameObject g)
    {
        var b = new Bounds(g.transform.position, Vector3.zero);
        foreach (Renderer r in g.GetComponentsInChildren<Renderer>())
        {
            b.Encapsulate(r.bounds);
        }
        return b;
    }
}