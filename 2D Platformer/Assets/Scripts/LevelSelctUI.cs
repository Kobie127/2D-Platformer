using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSelctUI : MonoBehaviour
{
    public static LevelSelctUI instance;
    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack;
    public bool shouldFadeFromBlack;
    public GameObject levelCompleteText;
    public GameObject levelInfoPanel;
    public Text levelName, gemsFound, gemsTotal, bestTime, targetTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
         if(shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }

        }
        
    }

     public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }

     public void ShowInfo(MapPoint levelInfo)
    {
        levelName.text = levelInfo.levelName;
        gemsFound.text = "FOUND: " + levelInfo.gemsCollected;
        gemsTotal.text = "IN LEVEL: " + levelInfo.totalGems;
        targetTime.text = "TARGET: " + levelInfo.targetTime + "s";
        if(levelInfo.bestTime == 0)
        {
            bestTime.text = "BEST: ---";
        }else
        {
            bestTime.text = "BEST: " + levelInfo.bestTime.ToString("F1") + "s"; //F1 will display it with a decimal in one place
        }
        levelInfoPanel.SetActive(true);
    }

      public void yes()
    {
        LevelSelectPlayer.instance.LSmusic.SetActive(false);
        AudioManager.instance.PlaySoundEffects(11);
        LevelSelectPlayer.instance.levelLoad = true;
        LevelSelectPlayer.instance.mananger.LoadLevel();
        //levelLoad = true;
        //mananger.LoadLevel();
    }

    public void HideInfo()
    {
        levelInfoPanel.SetActive(false);
    }
}
