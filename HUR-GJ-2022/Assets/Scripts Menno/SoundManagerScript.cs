using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    
    private static SoundManagerScript SoundManager;
    [SerializeField] public AudioSource Deathsound;

    private void Awake()
    {
        if (!SoundManager)
        {
            DontDestroyOnLoad(gameObject);
            SoundManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DeathSound()
    {
        Deathsound.Play();
        
    }
    
}

