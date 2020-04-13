using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;
    public GameObject bgMusic;
    public GameObject levelVic;
    public AudioSource bossMusic;
    

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
  
    }

    public void PlaySoundEffects(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        soundEffects[soundToPlay].Play();
    }

    public void PlayBackgroundMusic(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
        soundEffects[soundToPlay].loop = true;
        soundEffects[soundToPlay].volume = 1f;
    }

    public void stopBackgroundMusic(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
    }

    public void levelWin(int soundToPlay)
    {
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

    public void PlayBossMusic()
    {
        bgMusic.SetActive(false);
        bossMusic.Play();
    }

    public void StopBossMusic()
    {
        bossMusic.Stop();
        bgMusic.SetActive(true);
    }
    


}
