using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notepad : MonoBehaviour
{
    private bool isActive = false;
    private Animator m_animator;
    private AudioSource audio;

    public GameObject dialog;

    public AudioClip openSound;
    public AudioClip closeSound;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        audio = GetComponentInParent<AudioSource>();
    }

    public void Activate()
    {
        Debug.Log("불렀어?");

        if (!isActive)
        {
            isActive = true;

            m_animator.SetTrigger("Open");
            audio.PlayOneShot(openSound);
            dialog.SetActive(true);
        }
        else
        {
            isActive = false;

            m_animator.SetTrigger("Close");
            audio.PlayOneShot(closeSound);
            dialog.SetActive(false);
        }
    }

}
