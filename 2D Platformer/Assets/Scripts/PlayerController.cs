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
        anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), RB.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (onGround)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (onGround)
            {
                RB.velocity = new Vector2(RB.velocity.x, jumpHeight);
            }
            else
            {
                if (canDoubleJump)
                {
                    RB.velocity = new Vector2(RB.velocity.x, jumpHeight);
                    canDoubleJump = false;
                }
            }
           
        }

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
