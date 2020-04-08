using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomping : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectible1;
    public GameObject collectible2;
    private float randomCollectible;
    [Range(0, 100)]public float chanceToDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            PlayerController.instance.Bounce();
            float dropSelect = Random.Range(0, 100f);
            randomCollectible = Random.Range(0, 2f);
            if(dropSelect <= chanceToDrop)
            {
                if(randomCollectible <= 1){
                    Instantiate(collectible1, other.transform.position, other.transform.rotation);
                }else if (randomCollectible >= 1)
                {
                    Instantiate(collectible2, other.transform.position, other.transform.rotation);
                }
            }
            AudioManager.instance.PlaySoundEffects(3);
        }
    }
}
