using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public float speed = 1f;
    public float[] floorLevels;

    private Transform playerCharater;
    private bool isActivate = false;

    private void Start()
    {
        playerCharater = GameObject.FindWithTag("Player").transform;
    }

    public void Elevate(int floor)
    {
        float destinationLevel = floorLevels[floor - 1];

        if(transform.position.y < destinationLevel)
        {
            StartCoroutine(ElevateUp(destinationLevel));
        }
        else
        {
            StartCoroutine(ElevateDown(destinationLevel));
        }
    }

    /*
    public void Elevate(float distance)
    {
        float goal = transform.position.y + distance;

        if (distance > 0)
        {
            StartCoroutine(ElevateUp(goal));
        }
        else
        {
            StartCoroutine(ElevateDown(goal));
        }
    }
    */

    IEnumerator ElevateUp(float upLimit)
    {
        if (!isActivate)
        {
            isActivate = true;

            while (transform.position.y <= upLimit)
            {
                playerCharater.position += new Vector3(0, speed * Time.deltaTime, 0);
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                yield return null;
            }

            isActivate = false;
        }
        yield return null;
    }

    IEnumerator ElevateDown(float downLimit)
    {
        if (!isActivate)
        {
            isActivate = true;

            while (transform.position.y >= downLimit)
            {
                playerCharater.position -= new Vector3(0, speed * Time.deltaTime, 0);
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                yield return null;
            }

            isActivate = false;
        }
        yield return null;
    }
}
