﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankMineController : MonoBehaviour
{
    public GameObject explosion;
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
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            PlayerHealth.instance.takeDamage();
            AudioManager.instance.PlaySoundEffects(3);
        }
    }

    public void Explode()
    {
        Destroy(gameObject);
        AudioManager.instance.PlaySoundEffects(3);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
