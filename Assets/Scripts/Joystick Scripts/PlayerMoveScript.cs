using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;
    private Rigidbody2D myBody;
    private Animator animator;

    private bool moveLeft, moveRight;

    // Start is called before the first frame update

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (moveLeft)
        {
            MoveLeft();
        }
        else if (moveRight)
        {
            MoveRight();
        }else{
            PlayerMoveKeyBoard();
        }
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }

    public void SetMoveRight(bool moveRight)
    {
        this.moveRight = moveRight;
        this.moveLeft = !moveRight;
    }

    public void StopMovement()
    {
        moveLeft = moveRight = false;
        animator.SetBool("Walk", false);
    }

    void PlayerMoveKeyBoard()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h < 0)
        {
            MoveLeft();
        }
        else if (h > 0)
        {
            MoveRight();
        }
        else
        {
            StopMovement();
        }
    }

    void MoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        if (vel < maxVelocity)
        {
            forceX = -speed;
        }
        turnLeft();
        animator.SetBool("Walk", true);
        myBody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        if (vel < maxVelocity)
        {
            forceX = speed;
        }
        turnRight();
        animator.SetBool("Walk", true);
        myBody.AddForce(new Vector2(forceX, 0));
    }

    void turnLeft()
    {
        Vector3 localScale = transform.localScale;
        if (localScale.x > 0)
        {
            localScale.x = -localScale.x;
            transform.localScale = localScale;
        }
    }

    void turnRight()
    {
        Vector3 localScale = transform.localScale;
        if (localScale.x < 0)
        {
            localScale.x = -localScale.x;
            transform.localScale = localScale;
        }
    }

}
