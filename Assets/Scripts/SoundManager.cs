using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource MusicSource;
    public AudioSource SFXSource;

    public AudioClip[] MusicClips;
    public AudioClip[] SFXClips;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayMusic(int index)
    {
        MusicSource.clip = MusicClips[index];
        MusicSource.Play();
    }

    public void PlaySFX(int index)
    {
        SFXSource.clip = SFXClips[index];
        SFXSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.pitch = Random.Range(0.9f, 1.1f);
        SFXSource.PlayOneShot(clip);
    }
}
