using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float maxX , minX;

    private float objectWidth;

    // Start is called before the first frame update
    void Start()
    {   
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        SetMinAndMaxX();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Clamp(transform.position.x, minX + objectWidth, maxX- objectWidth);
        transform.position = newPos;
    }

    void SetMinAndMaxX(){
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        maxX = bounds.x;
        minX = -bounds.x;
    }
}
