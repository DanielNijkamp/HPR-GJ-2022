using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private PlayerMovement player;

    public GameObject PauseUI;
    private bool IsPaused = false;
    private BGM_Handler bgm_handler;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Unpause();

            }
            else
            {
                Pause();
            }
        }
    }
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        bgm_handler = FindObjectOfType<BGM_Handler>();
    }
    public void Pause()
    {
        PauseUI.SetActive(true);
        player.enabled = false;
        Time.timeScale = 0;
        IsPaused = true;
    }
    public void Unpause()
    {
        PauseUI.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1;
        IsPaused = false;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.enabled = true;
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        bgm_handler.StopMusic();
        SceneManager.LoadScene(0);
        bgm_handler.PlayedMusic = false;
        StartCoroutine(bgm_handler.MainMenuMusic());
    }
    
}
