using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int currentHealth;
    public int maxHealth;
    public float invincibleLength;
    private float invincibleCounter;
    private SpriteRenderer SpriteRenderer;
    public GameObject deathEffect;
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
            if(invincibleCounter <= 0)
            {
                SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, 1f);
            }
        }
    }

    public void takeDamage()
    {
        if(invincibleCounter <= 0)
        {  
            currentHealth--;
            if(currentHealth <= 0)
            {
                //gameObject.SetActive(false);
                currentHealth = 0;
                Instantiate(deathEffect, transform.position, transform.rotation);
                LevelManager.instance.RespawnPlayer();
            }else
            {
                invincibleCounter = invincibleLength;
                SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, .55f);
                PlayerController.instance.knockBack();
                AudioManager.instance.PlaySoundEffects(9);
            }

            UIController.instance.updateHealthDisplay();
    }
}

public void healPlayer()
{
    currentHealth++;
    if(currentHealth > maxHealth)
    {
        currentHealth = maxHealth;
    }
    UIController.instance.updateHealthDisplay();
}

private void OnCollisionEnter2D(Collision2D other)
{
    if(other.gameObject.tag == "Platform")
    {
        transform.parent = other.transform;
    }
}

private void OnCollisionExit2D(Collision2D other)
{
    if(other.gameObject.tag == "Platform")
    {
        transform.parent = null;
    }
}


}
