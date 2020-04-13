using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{

    private Animator anim;
    public float bounceForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AudioManager.instance.PlaySoundEffects(10);
            PlayerController.instance.RB.velocity = new Vector2(PlayerController.instance.RB.velocity.x, bounceForce);
            anim.SetTrigger("Bounce");
        }
    }
}
