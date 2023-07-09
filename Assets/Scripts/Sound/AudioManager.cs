using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    //[SerializeField] AudioClip SFXSource;

    public AudioClip backgroundMusic;

    private void Start() {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
}
