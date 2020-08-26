using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float speed = 30f;
    public Elevator elevator;

    public void DoorOpen(float degree)
    {
        StartCoroutine(Open(degree));
    }
    public void DoorClose()
    {
        StartCoroutine(Close());
    }

    IEnumerator Open(float time)
    {
        float go_time = 0;
        while(go_time < time)
        {
            transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
            go_time += Time.deltaTime;
            yield return null;
        }
        elevator.isDoorOpen = true;
        yield return null;
    }

    IEnumerator Close()
    {
        while (transform.rotation.y > 0)
        {
            transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
            yield return null;
        }
        elevator.isDoorOpen = false;
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => !elevator.isActivate);

        DoorOpen(2f);
    }
}
