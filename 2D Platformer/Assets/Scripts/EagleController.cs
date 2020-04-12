using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;
    public SpriteRenderer SR; 
    public float distanceToAttackPlayer;
    public float chaseSpeed;
    private Vector3 attackTarget;
    //private bool hasAttacked;
    public float waitAfterAttack;
    private float attackCounter;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }else
        {
            if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAttackPlayer)
            {
                attackTarget = Vector3.zero;
                //Debug.Log(Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime));
                transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
                if(Vector3.Distance(transform.position, points[currentPoint].position) < .05f)
                {
                    currentPoint++;
                    if(currentPoint >= points.Length)
                    {
                        currentPoint = 0;
                    }
                }
                if(transform.position.x < points[currentPoint].position.x)
                {
                    SR.flipX = true;
                }else if (transform.position.x > points[currentPoint].position.x)
                {
                    SR.flipX = false;
                }
                
            }else
            {
                //Attacking player
                if(attackTarget == Vector3.zero)//All values for x, y, z are 0
                {
                    attackTarget = PlayerController.instance.transform.position;
                } 
                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);
                if(Vector3.Distance(transform.position, attackTarget) <= .1f)
                {
                    //hasAttacked = true;
                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }
            }
        }
    }
}
