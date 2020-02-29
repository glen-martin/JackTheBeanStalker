using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;

    [SerializeField]
    private Rigidbody2D myBody;
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        PlayerMoveKeyBoard();
    }
    void PlayerMoveKeyBoard(){
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if(h > 0){
            if(vel< maxVelocity){
                forceX = speed;
            }
            turnRight();
            animator.SetBool("Walk",true);
        }else if(h<0) {
            if(vel< maxVelocity){
                forceX = -speed;
            }
            turnLeft();
            animator.SetBool("Walk",true);
        } else{
            animator.SetBool("Walk",false);
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }

    void turnLeft(){
        Vector3 localScale = transform.localScale;
            if(localScale.x > 0){
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
    }

    void turnRight(){
        Vector3 localScale = transform.localScale;
            if(localScale.x < 0){
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
    }
}// Player
