using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleConveyorbelt : MonoBehaviour
{
    public float speed = 0.5f; // 속도
    public int isReverse = 1;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = rigid.position;
        rigid.position += transform.forward * isReverse * -speed * Time.fixedDeltaTime;
        rigid.MovePosition(pos);
    }

    public void TurnDirection()
    {
        isReverse *= -1;
    }
}
