using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFoward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");

        transform.parent = cam.transform;

        transform.localPosition = new Vector3(0f, 0f, 0.5f);
        transform.LookAt(cam.transform);
    }

}
