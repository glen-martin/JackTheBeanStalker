using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        // Time before the item is automatically gone
        Invoke("DestoryCollectible", 6f);
    }
    void DestoryCollectible(){
        gameObject.SetActive(false);
    }
}
