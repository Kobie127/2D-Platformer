using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject objectToSwitch;
    public SpriteRenderer SR; 
    public Sprite downSprite;
    private bool hasSwitched;
    public bool deactivateSwitch;
    // Start is called before the first frame update
    void Start()
    {
       // SR.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !hasSwitched)
        {
            if(deactivateSwitch)
            {
                objectToSwitch.SetActive(false);
            }else
            {
                objectToSwitch.SetActive(true);
            }
            SR.sprite = downSprite;
            objectToSwitch.SetActive(false);
            hasSwitched = true;
        }
    }
}
