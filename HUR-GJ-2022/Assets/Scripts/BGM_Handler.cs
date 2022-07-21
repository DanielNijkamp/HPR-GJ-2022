using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_Handler : MonoBehaviour
{
    private static BGM_Handler bgm_handler;
    [Range(0.1f, 1f)]
    public float BGMVolume;

    public AudioClip[] BGM;
    public bool GameStarted = false;

    public AudioSource bgmSource;
    public bool PlayedMusic = false;
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!PlayedMusic && !GameStarted)
            {
                StartCoroutine(MainMenuMusic());
                PlayedMusic = true;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex != 10 && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (!PlayedMusic && !GameStarted)
            {
                StartCoroutine(BGM_Music());
                PlayedMusic = true;
            }
        }
    }
    public IEnumerator MainMenuMusic()
    {
        while (true)
        {
            bgmSource.volume = BGMVolume;
            bgmSource.clip = BGM[0];
            bgmSource.Play();
            yield return new WaitForSecondsRealtime(bgmSource.clip.length);
        }
    }
    public IEnumerator BGM_Music()
    {
        while (true)
        {
            bgmSource.volume = BGMVolume;
            bgmSource.clip = BGM[1];
            bgmSource.Play();
            yield return new WaitForSecondsRealtime(bgmSource.clip.length);
        }
    }
    public void StopMusic()
    {
        bgmSource.Stop();
        GameStarted = true;
    }
    private void Awake()
    {
        if (!bgm_handler)
        {
            DontDestroyOnLoad(gameObject);
            bgm_handler = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
    

        
