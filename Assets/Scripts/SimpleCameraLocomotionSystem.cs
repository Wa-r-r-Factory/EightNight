using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraLocomotionSystem : MonoBehaviour
{
    public bool isDebuging = true;
    public Transform centerCameraAncher = null;
    public float speed = 8f;


    private void Update()
    {
        if (isDebuging)
        {
            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");
            Quaternion moveRotation = centerCameraAncher.rotation;

            transform.Translate(new Vector3(xMove, 0, yMove) * speed * Time.deltaTime, Space.Self);
        }
    }
}
