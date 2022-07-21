using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUIScript : MonoBehaviour
{
    public void GoToMainMenu()
    {
        BGM_Handler handler = FindObjectOfType<BGM_Handler>();
        handler.StopMusic();
        SceneManager.LoadScene(0);
        handler.PlayedMusic = false;
        StartCoroutine(handler.BGM_Music());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
