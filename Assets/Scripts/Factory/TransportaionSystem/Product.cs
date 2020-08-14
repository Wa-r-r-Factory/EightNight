using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    Rigidbody rigid = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish")) StartCoroutine(DisableProduct());
        if (other.CompareTag("Stamp")) Processing();
    }

    private void OnEnable()
    {
        if(rigid == null)
        {
            rigid = GetComponent<Rigidbody>();
        }

        rigid.velocity = Vector3.zero;
    }

    IEnumerator DisableProduct()
    {
        yield return null;
        ProductPoolingManager.instance.InsertQueue(gameObject);
    }

    private void Processing()
    {
        
    }

}
