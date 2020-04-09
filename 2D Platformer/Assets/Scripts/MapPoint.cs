using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public static MapPoint instance;
    public MapPoint up, down, right, left;
    public bool isLevel;
    public bool isLocked;
    public string level;
    public string levelToCheck;
    public string levelName;
    public int gemsCollected;
    public int totalGems;
    public float bestTime;
    public float targetTime;
    public GameObject gemBadge;
    public GameObject timeBadge;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(isLevel && level != null)
        {
            if(PlayerPrefs.HasKey(level + "_gems"))
            {
                gemsCollected = PlayerPrefs.GetInt(level + "_gems");
            }

            if(PlayerPrefs.HasKey(level + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(level + "_time");
            }

            if(gemsCollected >= totalGems)
            {
                gemBadge.SetActive(true);
            }

            if(bestTime <= targetTime  && bestTime != 0)
            {
                timeBadge.SetActive(true);
            }

            isLocked = true;
            if(levelToCheck != null)
            {
                if(PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }
            }
        }

        if(level == levelToCheck)
        {
            isLocked = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
