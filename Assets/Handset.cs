using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handset : MonoBehaviour
{
    private AudioSource audio;
    private AudioClipCarrier clipCarrier;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        clipCarrier = GetComponent<AudioClipCarrier>();

        audio.PlayOneShot(clipCarrier.clips[0]);
    }

    public void OnClicked()
    {
        StartCoroutine(PlayClips());
    }

    IEnumerator PlayClips()
    {

        audio.loop = false;
        audio.PlayOneShot(clipCarrier.clips[1]);

        yield return new WaitWhile(() => audio.isPlaying);

        audio.PlayOneShot(clipCarrier.clips[2]);
    }
}
