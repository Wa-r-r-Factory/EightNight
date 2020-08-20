using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductDispenser : MonoBehaviour
{
    public Transform outputPoint;


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Dispense(other.gameObject));
    }


    IEnumerator Dispense(GameObject product)
    {
        product.SetActive(false);
        product.transform.position = outputPoint.position;

        yield return new WaitForSeconds(1f);

        product.SetActive(true);
    }
}
