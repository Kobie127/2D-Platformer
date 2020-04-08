using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint;
    public Transform rightPoint;
    private bool movingRight;
    private Rigidbody2D Rigidbody;
    private Animator anim;
    public SpriteRenderer SR;
    public float moveTime;
    public float waitTime;
    private float moveCount;
    private float waitCount;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        leftPoint.parent = null;
        rightPoint.parent = null;
        movingRight = true;
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if(movingRight)
            {
                Rigidbody.velocity = new Vector2(moveSpeed, Rigidbody.velocity.y);
                SR.flipX = true;
                if(transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }else
            {
                Rigidbody.velocity = new Vector2(-moveSpeed, Rigidbody.velocity.y);
                SR.flipX = false;
                if(transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            if(moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", true);
        } else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            Rigidbody.velocity = new Vector2(0f, Rigidbody.velocity.y);
            if(waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, moveTime * 1.25f);
            }
            anim.SetBool("isMoving", false);
        }
    }
}
