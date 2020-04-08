using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;
    public AudioSource backgroundMusic;
    public AudioSource endMusic;
    public AudioSource titleMusic;

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
      if(PauseMenu.instance.isPaused)
      {
          backgroundMusic.Pause();
      }
      else
      {
        backgroundMusic.Play();
      }   
    }

    public void PlaySoundEffects(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        soundEffects[soundToPlay].Play();
    }

    public void PauseMusic(AudioSource backgroundMusic)
    {
        backgroundMusic.Pause();
    }

    public void ResumeMusic(AudioSource backgroundMusic)
    {
        backgroundMusic.Play();
    }

    


}
