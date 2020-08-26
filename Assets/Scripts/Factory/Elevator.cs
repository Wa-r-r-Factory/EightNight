using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public float speed = 1f;
    public float[] floorLevels;
    public Door door;

    private Transform playerCharater;
    private AudioSource audio;
    private AudioClipCarrier clipCarrier;
    [HideInInspector]
    public bool isActivate = false;
    [HideInInspector]
    public bool isDoorOpen = true;

    private void Start()
    {
        playerCharater = GameObject.FindWithTag("Player").transform;
        audio = GetComponent<AudioSource>();
        clipCarrier = GetComponent<AudioClipCarrier>();
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
        door.DoorClose();
        audio.PlayOneShot(clipCarrier.clips[0]);

        while (isDoorOpen)
        {
            yield return null;
        }

        if (!isActivate)
        {
            isActivate = true;
            audio.PlayOneShot(clipCarrier.clips[1]);

            while (transform.position.y <= upLimit)
            {
                playerCharater.position += new Vector3(0, speed * Time.deltaTime, 0);
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                yield return null;
            }

            audio.Stop();
            audio.PlayOneShot(clipCarrier.clips[2]);

            yield return new WaitWhile(() => audio.isPlaying);
            isActivate = false;

            audio.PlayOneShot(clipCarrier.clips[3]);
        }
        yield return null;
    }

    IEnumerator ElevateDown(float downLimit)
    {
        door.DoorClose();
        audio.PlayOneShot(clipCarrier.clips[0]);


        while (isDoorOpen)
        {
            yield return null;
        }

        if (!isActivate)
        {
            isActivate = true;
            audio.PlayOneShot(clipCarrier.clips[1]);


            while (transform.position.y >= downLimit)
            {
                playerCharater.position -= new Vector3(0, speed * Time.deltaTime, 0);
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                yield return null;
            }

            audio.Stop();
            audio.PlayOneShot(clipCarrier.clips[2]);

            yield return new WaitWhile(() => audio.isPlaying);
            isActivate = false;

            audio.PlayOneShot(clipCarrier.clips[3]);

        }
        yield return null;
    }
}
