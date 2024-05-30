using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip playMusic;

    private void Start()
    {
        musicSource.clip = playMusic;
        musicSource.Play();
    }
}
