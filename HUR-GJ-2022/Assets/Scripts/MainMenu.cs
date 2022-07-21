using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public Button[] levelbuttons;

    public void LoadLevel(int index)
    {
        BGM_Handler handler = FindObjectOfType<BGM_Handler>();
        handler.StopMusic();
        SceneManager.LoadScene(index);
        handler.PlayedMusic = false;
        StartCoroutine(handler.BGM_Music());
    }
}
