using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject linkedDialog;

    private void OnEnable()
    {
        linkedDialog.SetActive(true);
    }

    private void OnDisable()
    {
        linkedDialog.SetActive(false);
    }
}
