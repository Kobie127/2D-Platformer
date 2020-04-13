using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene;
    public string continueScene;
    public GameObject continueButton;
    public GameObject continueB;
    public GameObject startB;
    public GameObject quitB;
    public GameObject controlB;
    public GameObject controls;
   

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(startScene + "_unlocked"))
        {
            continueButton.SetActive(true);
        }else
        {
            continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll();
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(continueScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        continueB.SetActive(false);
        startB.SetActive(false);
        quitB.SetActive(false);
        controlB.SetActive(false);
        controls.SetActive(true);
       

    }

    public void Back()
    {
        continueB.SetActive(true);
        startB.SetActive(true);
        quitB.SetActive(true);
        controlB.SetActive(true);
        controls.SetActive(false);
       
    }
}
