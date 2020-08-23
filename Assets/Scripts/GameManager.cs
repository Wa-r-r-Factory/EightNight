using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Transform playerCharacter = null;

    public MyTime m_Time;
    public Vector3 time;

    private void Awake()
    {
        playerCharacter = GameObject.FindWithTag("Player").transform;
        m_Time.SetTime((int)time.x, (int)time.y, (int)time.z);

        StartCoroutine(TimeGo());
    }

    public void ResetPosition()
    {
        playerCharacter.position = Vector3.zero;
    }

    IEnumerator TimeGo()
    {
        int maxHour = 12, maxMinute = 60, maxSecond = 60;

        while (true)
        {
            for (; m_Time.minute < maxMinute; m_Time.minute++)
            {
                for (; m_Time.second < maxSecond; m_Time.second++)
                {
                    yield return new WaitForSeconds(1f);
                }
                m_Time.second = 0;
            }
            m_Time.minute = 0;
            m_Time.hour++;
        }
    }
}

public struct MyTime
{
    public int hour, minute, second;

    public void SetTime(int h, int m, int s)
    {
        hour = h;
        minute = m;
        second = s;
    }
}
