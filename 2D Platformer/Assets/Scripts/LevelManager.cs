using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public float waitToRespawn;

    public int gemsCollected;
    public string nextLevel;
    public float timeInLevel;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       //AudioManager.instance.levelVic.SetActive(false);
       timeInLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // AudioManager.instance.PlayBackgroundMusic(13);
        timeInLevel += Time.deltaTime;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        AudioManager.instance.PlaySoundEffects(8);
        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .2f);
        UIController.instance.FadeFromBlack();
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealth.instance.currentHealth = PlayerHealth.instance.maxHealth;
        UIController.instance.updateHealthDisplay();
    }

    public void LevelEnd()
    {
        StartCoroutine(LevelEndCo());
    }

    public IEnumerator LevelEndCo()
    {
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollowingPlayer = true;
        UIController.instance.levelCompleteText.SetActive(true);
        //AudioManager.instance.stopBackgroundMusic(13);
        //AudioManager.instance.levelWin(14);
        AudioManager.instance.bgMusic.SetActive(false);
        //AudioManager.instance.levelVic.SetActive(true);
        AudioManager.instance.levelWin(13);
        yield return new WaitForSeconds(1.5f);
        PlayerController.instance.moveSpeed = 0;
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 1.60f);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if(gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
            }
        }else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
        }

        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if(timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }
        SceneManager.LoadScene(nextLevel);
    }

}
