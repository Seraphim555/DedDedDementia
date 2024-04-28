using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] AudioClip doctorWatchAmbient;
    [SerializeField] AudioClip doctorSneze;

    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
        StartCoroutine(PlayDoctorSnezeRandomly());
        StartCoroutine(PlayDoctorWatchAmbientRandomly());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            audioSource.loop = true;
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
    }

    private IEnumerator PlayDoctorSnezeRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(20f, 40f));
            if (doctorSneze != null)
            {
                audioSource.PlayOneShot(doctorSneze);
            }
        }
    }

    private IEnumerator PlayDoctorWatchAmbientRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(20f, 40f));
            if (doctorWatchAmbient != null)
            {
                audioSource.PlayOneShot(doctorWatchAmbient);
            }
        }
    }
}
