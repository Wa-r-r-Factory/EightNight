using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDialog : MonoBehaviour
{
    public Transform parent;

    private void Start()
    {
        transform.parent = parent;
    }
}
