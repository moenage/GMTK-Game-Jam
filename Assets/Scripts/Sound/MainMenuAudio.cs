using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour {
    [SerializeField] AudioSource musicSource;

    public AudioClip backgroundMusic;

    private void Start() {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
}
