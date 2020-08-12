using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    private Animator m_animator;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void StartStamp()
    {
        if (!isActive) StartCoroutine(Stamping());
    }

    IEnumerator Stamping()
    {
        isActive = true;
        m_animator.SetTrigger("Stamp");
        yield return new WaitForSeconds(1f);

        isActive = false;
        yield return null;

    }
}
