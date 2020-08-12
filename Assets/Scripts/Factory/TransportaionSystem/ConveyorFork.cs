using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorFork : MonoBehaviour
{
    public int order; // from 1
    public int maxOrder; // 한 라인에 배치되어있는 작업대 수

    public float waitingTime = 1f;


    private int interval; // 이 Fork가 가지게 되는 간격 (이 Fork는 interval개마다 한 번씩 제품을 통과시킨다. 나머지는 지나보낸다.)
    private int remainNum; // 남은 지나보내기 횟수

    private bool isActive = false;

    private void Start()
    {

        interval = maxOrder - order;
        remainNum = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SwitchOrder()) StartCoroutine(Fork());
    }

    private bool SwitchOrder()
    {
        if (!isActive)
        {
            if (remainNum == 0)
            {
                remainNum = interval;
                return true;
            }
            else
            {
                remainNum--;
                return false;
            }
        }
        return false;
    }

    public IEnumerator Fork()
    {
        isActive = true;

        for (int i = 0; i < 45; i++)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(i, transform.localRotation.y, transform.localRotation.z));
            yield return null;
        }

        yield return new WaitForSeconds(waitingTime);

        for (int i = 45; i > 0; i--)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(i, transform.localRotation.y, transform.localRotation.z));
            yield return null;
        }

        isActive = false;
    }
}
