using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    private PlayerMoveScript moveScript;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        moveScript = GameObject.Find("Player").GetComponent<PlayerMoveScript>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left Button")
        {
            moveScript.SetMoveLeft(true);
        }
        else if (gameObject.name == "Right Button")
        {
            moveScript.SetMoveRight(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        moveScript.StopMovement();
    }
}
