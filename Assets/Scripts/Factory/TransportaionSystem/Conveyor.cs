using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = rigidbody.position * speed;
        rigidbody.position += Vector3.back * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(pos);
    }
}
