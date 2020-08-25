using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private AudioSource audio;
    public GameObject[] dialogs;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        StartCoroutine(PlayRadio());
    }
    

    IEnumerator PlayRadio()
    {
        for (int i = 0; i < dialogs.Length; i++)
        {
            dialogs[i].SetActive(true);
            audio.Play();


            yield return new WaitForSeconds(3f);
            dialogs[i].SetActive(false);   

            yield return new WaitForSeconds(1f);

        }

    }
}
