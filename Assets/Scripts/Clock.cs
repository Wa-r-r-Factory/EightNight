using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hoursTransform;
    public Transform minutesTransform;
    public Transform secondsTransform;

    const float degreesPerHour = 30f, degreePerMinute = 6f, degreePerSecond = 6f;
    const float invertdegree = 0.0833f;

    private MyTime time;

    private void Awake()
    {
        if (hoursTransform == null || minutesTransform == null || secondsTransform == null) return;

        hoursTransform.localRotation = Quaternion.Euler(0f, 0f, GameManager.Instance.m_Time.hour * degreesPerHour + GameManager.Instance.m_Time.minute * 0.5f);
        minutesTransform.localRotation = Quaternion.Euler(0f, 0f, GameManager.Instance.m_Time.minute * degreePerMinute);
        secondsTransform.localRotation = Quaternion.Euler(0f, 0f, GameManager.Instance.m_Time.second * degreePerSecond);
    }


    void Update()
    {
        hoursTransform.localRotation = Quaternion.Euler(0f, 0f, GameManager.Instance.m_Time.hour * degreesPerHour + GameManager.Instance.m_Time.minute * 0.5f);
        minutesTransform.localRotation = Quaternion.Euler(0f, 0f, GameManager.Instance.m_Time.minute * degreePerMinute);
        secondsTransform.localRotation = Quaternion.Euler(0f, 0f, GameManager.Instance.m_Time.second * degreePerSecond);
    }
}
