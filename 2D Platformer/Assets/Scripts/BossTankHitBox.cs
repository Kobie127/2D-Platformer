﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankHitBox : MonoBehaviour
{
    public BossTankController bossController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && PlayerController.instance.transform.position.y > transform.position.y)
        {
            bossController.takeHit();
            PlayerController.instance.Bounce();
            gameObject.SetActive(false);
        }
    }
}
