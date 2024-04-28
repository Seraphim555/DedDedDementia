using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    [SerializeField] AudioClip backgroundMainMenuMusic;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayBackgroundMusic()
    {
        if (backgroundMainMenuMusic != null)
        {
            audioSource.loop = true;
            audioSource.clip = backgroundMainMenuMusic;
            audioSource.Play();
        }
    }
}

