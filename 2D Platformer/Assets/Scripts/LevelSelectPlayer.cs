using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPlayer : MonoBehaviour
{
    public static LevelSelectPlayer instance;
    public MapPoint currentPos;
    public float moveSpeed = 11f;
    public bool levelLoad;
    public LevelSelectMananger mananger;
    public GameObject LSmusic;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPos.transform.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentPos.transform.position) < .1f && !levelLoad)
        {
            if(Input.GetAxisRaw("Horizontal") > .5f)
            {
                if(currentPos.right != null)
                {
                    AudioManager.instance.PlaySoundEffects(5);
                    SetNextPos(currentPos.right);
                }
            }

            if(Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if(currentPos.left != null)
                {
                    AudioManager.instance.PlaySoundEffects(5);
                    SetNextPos(currentPos.left);
                }
            }

            if(Input.GetAxisRaw("Vertical") > .5f)
            {
                if(currentPos.up != null)
                {
                    AudioManager.instance.PlaySoundEffects(5);
                    SetNextPos(currentPos.up);
                }
            }

            if(Input.GetAxisRaw("Vertical") < -.5f)
            {
                if(currentPos.down != null)
                {
                    AudioManager.instance.PlaySoundEffects(5);
                    SetNextPos(currentPos.down);
                }
            }

            if(currentPos.isLevel && currentPos.level != "" && !currentPos.isLocked)
            {
                if(Input.GetKeyDown("e"))
                {
                    AudioManager.instance.PlaySoundEffects(4);
                    LevelSelctUI.instance.ShowInfo(currentPos);

                    // levelLoad = true;
                    // mananger.LoadLevel();
                }
            }
        }
    }

    public void yes()
    {
        levelLoad = true;
        
        AudioManager.instance.PlaySoundEffects(11);
        mananger.LoadLevel();
        
    }

    public void no()
    {
        levelLoad = false;
        LevelSelctUI.instance.HideInfo();

    }

    public void SetNextPos(MapPoint nextPos)
    {
        currentPos = nextPos;
    }
}
