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
                gameObject.SetActive(false);
                currentHealth = 0;
            }else
            {
                invincibleCounter = invincibleLength;
                SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, .55f);
                PlayerController.instance.knockBack();
            }

            UIController.instance.updateHealthDisplay();
    }
}
}
