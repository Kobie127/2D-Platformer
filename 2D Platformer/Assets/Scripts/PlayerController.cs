using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight;
    public float moveSpeed;
    public Rigidbody2D RB;
    private bool onGround;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    private SpriteRenderer SR;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //This will grab the correct components for later use. 
        anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //This sets the velocity to the players rigid body and will calculate the speed based on the moveSpeed variable and the raw input as soon as a left or right key is pressed
        RB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), RB.velocity.y);
        //This grabs the information from a empty game object known as the ground point and stores it's data into this variable for later use
        onGround = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (onGround)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (onGround)
            {
                //Same concept as moving player forward but this time it will move player upward 
                RB.velocity = new Vector2(RB.velocity.x, jumpHeight);
            }
            else
            {
                //This conditional statement will allow the player to make a second jump
                if (canDoubleJump)
                {
                    RB.velocity = new Vector2(RB.velocity.x, jumpHeight);
                    canDoubleJump = false;  
                }
            }
           
        }

        //These conditions allows the sprite to change direction when moving
        if (RB.velocity.x < 0)
        {
            SR.flipX = true;
        }
        else if (RB.velocity.x > 0)
        {

            SR.flipX = false;
        }
        
        anim.SetFloat("moveSpeed", Mathf.Abs(RB.velocity.x));
        anim.SetBool("onGround", onGround);
    }
}
