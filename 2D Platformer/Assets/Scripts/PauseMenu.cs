using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelect;
    public string mainMenu;
    public GameObject pauseScreen;
    public bool isPaused;
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            AudioManager.instance.bgMusic.SetActive(true);
        }else
        {

            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            AudioManager.instance.bgMusic.SetActive(false);
        }
    }

    public void PauseUnpauseLS()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            LSmusic.SetActive(true);
        }else
        {

            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            LSmusic.SetActive(false);
        }

    }

    public void LevelSelect()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

}
