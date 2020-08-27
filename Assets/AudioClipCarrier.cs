using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipCarrier : MonoBehaviour
{
    public AudioClip[] clips;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayClip(int index)
    {
        audio.PlayOneShot(clips[index]);
    }
}
