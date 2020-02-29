using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{

    private GameObject[] backgrounds;

    private float lastPositionY;
    // Start is called before the first frame update
    void Start()
    {
        GetAllBackgrounds();
    }

    void GetAllBackgrounds()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");

        lastPositionY = backgrounds[0].transform.position.y;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (lastPositionY > backgrounds[i].transform.position.y)
                lastPositionY = backgrounds[i].transform.position.y;
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Background")
        {
            if (other.transform.position.y == lastPositionY)
            {
                Vector3 temp = other.transform.position;
                float height = ((BoxCollider2D)other).size.y;
                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastPositionY = temp.y;

                        backgrounds[i].transform.position = temp;
                        Debug.Log(temp.y);
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
