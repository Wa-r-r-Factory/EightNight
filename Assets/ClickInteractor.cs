﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteractor : MonoBehaviour
{
    public Transform cameraTransform;

    private Transform originParant;

    private bool isGrabbing = false;

    private GameObject grabbedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));


            #region 버튼
            if (Physics.Raycast(ray, out hit, 2))
            {
                Debug.Log("맞았어");

                MyButton button = hit.transform.GetComponent<MyButton>();
                if (button != null)
                {
                    Debug.Log("좋았어");

                    button.Click();
                }
            }
            #endregion

            #region 엘레베이터 버튼
            if (Physics.Raycast(ray, out hit, 2))
            {
                Debug.Log("맞았어");

                ElevatorButton button = hit.transform.GetComponent<ElevatorButton>();
                if (button != null)
                {
                    Debug.Log("좋았어");

                    button.Move();
                }
            }
            #endregion

            #region Grab
            if (isGrabbing)
            {
                grabbedObject.transform.parent = originParant;

                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;

                originParant = null;
                grabbedObject = null;

                isGrabbing = false;

                return;
            }


            if(Physics.Raycast(ray, out hit, 2))
            {
                if (!isGrabbing && hit.transform.CompareTag("Grabbable"))
                {
                    Rigidbody hit_Rigidbody = hit.transform.GetComponent<Rigidbody>();

                    originParant = hit.transform.parent;
                    grabbedObject = hit.transform.gameObject;

                    hit.transform.parent = cameraTransform;
                    hit_Rigidbody.isKinematic = true;
                    Vector3 vec = cameraTransform.position - hit.transform.position;
                    vec.Normalize();
                    Quaternion q = Quaternion.LookRotation(vec);
                    hit.transform.rotation = q;

                    isGrabbing = true;
                }
            }
            #endregion 
        }
    }
}
