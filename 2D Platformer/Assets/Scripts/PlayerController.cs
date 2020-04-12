using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float jumpHeight;
    public float moveSpeed;
    public Rigidbody2D RB;
    private bool onGround;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    private SpriteRenderer SR;
    private Animator anim;
    public float knockbackLength, knockbackForce;
    private float knockbackCounter;
    private bool isHit;
    public float bounceForce;
    public bool stopInput;
    public GameObject stompbox;
    public float stompboxLength;
    private void Awake()
    {
        instance = this;
    }

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
        if(!PauseMenu.instance.isPaused && !stopInput)
        {
            if(knockbackCounter <= 0 && knockbackCounter <= 0)
            {
                stompbox.SetActive(true);
                //This sets the velocity to the players rigid body and will calculate the speed based on the moveSpeed variable and the raw input as soon as a left or right key is pressed
                RB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), RB.velocity.y);
                //This grabs the information from a empty game object known as the ground point and stores it's data into this variable for later use
                onGround = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

                if (onGround)
                {
                    canDoubleJump = true;
                    if(Input.GetKeyDown("s"))
                    {
                        anim.SetTrigger("crouch");
                    } 
                    else
                    {
                        anim.SetTrigger("stand");
                    }
                }

                if (Input.GetButtonDown("Jump"))
                {
                    if (onGround)
                    {
                        //Same concept as moving player forward but this time it will move player upward 
                        RB.velocity = new Vector2(RB.velocity.x, jumpHeight);
                        AudioManager.instance.PlaySoundEffects(10);
                    }
                    else
                    {
                        //This conditional statement will allow the player to make a second jump
                        if (canDoubleJump)
                        {
                            RB.velocity = new Vector2(RB.velocity.x, jumpHeight);
                            canDoubleJump = false;  
                            AudioManager.instance.PlaySoundEffects(10);

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
            }else
            {
                stompbox.SetActive(false);
                stompboxLength -= Time.deltaTime;
                knockbackCounter -= Time.deltaTime;
                if(!SR.flipX)
                {
                    RB.velocity = new Vector2(-knockbackForce, RB.velocity.y);
                    
                }else
                {
                    RB.velocity = new Vector2(knockbackForce, RB.velocity.y);

                }
        }
        
        anim.SetFloat("moveSpeed", Mathf.Abs(RB.velocity.x));
        anim.SetBool("onGround", onGround);
    }
    }

    public void knockBack()
    {
        knockbackCounter = knockbackLength;
        RB.velocity = new Vector2(0f, knockbackForce);
        anim.SetTrigger("hurt");

    }

    public void Bounce()
    {
        RB.velocity = new Vector2(RB.velocity.x, bounceForce);
        AudioManager.instance.PlaySoundEffects(10);
    }
}
