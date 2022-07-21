using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    
    private static SoundManagerScript SoundManager;
    public AudioClip[] SFX;
    [SerializeField] public AudioSource source;

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
        source.clip = SFX[0];
        source.Play();
        
    }
    public void MouseOverButton()
    {
        source.clip = SFX[1];
        source.Play();

    }
    public void ButtonPressed()
    {
        source.clip = SFX[2];
        source.Play();

    }

}

