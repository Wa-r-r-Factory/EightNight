using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleConveyorbelt : MonoBehaviour
{
    public float speed = 0.5f; // 속도
    public Vector3 direction; // 작동 방향

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = rigid.position;
        rigid.position += direction * -speed * Time.fixedDeltaTime;
        rigid.MovePosition(pos);
    }

    public void TurnDirection()
    {
        direction = -1 * direction;
    }
}
