using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notepad : MonoBehaviour
{
    private bool isActive = false;
    private Animator m_animator;

    public GameObject dialog;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        Debug.Log("불렀어?");

        if (!isActive)
        {
            isActive = true;

            m_animator.SetTrigger("Open");
            dialog.SetActive(true);
        }
        else
        {
            isActive = false;

            m_animator.SetTrigger("Close");
            dialog.SetActive(false);
        }
    }

}
