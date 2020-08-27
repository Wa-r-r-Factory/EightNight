using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audio;

    public AudioClip factorySound;

    private void Start()
    {
        instance = this;

        audio = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
}
