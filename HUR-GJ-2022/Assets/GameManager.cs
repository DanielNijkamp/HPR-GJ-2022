using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject hudContainer, GameOverPanel;
    public Text timeCounter;
    public bool gamePlaying { get; private set; }

    private float startTime, elapsedTime;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        gamePlaying = true;
    }
    private void EndGame()
    {
        gamePlaying = false;
    }
}
