using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySoundEffects(2);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(-moveSpeed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth.instance.takeDamage();
        }
        AudioManager.instance.PlaySoundEffects(1);
        Destroy(gameObject);

    }
}
