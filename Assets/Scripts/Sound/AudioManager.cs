using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource hitSource;

    public AudioClip backgroundMusic;
    public AudioClip laserSound;
    public AudioClip playerHit;
    public AudioClip enemyHit;
    public AudioClip bulletHell;

    private void Start() {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }

    public void playHit(AudioClip clip) {
        hitSource.PlayOneShot(clip);
    }
}
