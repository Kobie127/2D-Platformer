using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMananger : MonoBehaviour
{
    public LevelSelectPlayer player;
    private MapPoint[] allPoints;
    // Start is called before the first frame update
    void Start()
    {
        allPoints = FindObjectsOfType<MapPoint>();
        if(PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach(MapPoint point in allPoints)
            {
                if(point.level == PlayerPrefs.GetString("CurrentLevel"))
                {
                    player.transform.position = point.transform.position;
                    player.currentPos = point;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo()
    {
        LevelSelctUI.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / LevelSelctUI.instance.fadeSpeed) + .82f);
        SceneManager.LoadScene(player.currentPos.level);
    }
}
