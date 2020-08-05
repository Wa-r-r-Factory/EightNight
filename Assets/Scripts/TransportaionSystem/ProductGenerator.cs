using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateProduct());
    }

    IEnumerator CreateProduct()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject product = ProductPoolingManager.instance.GetQueue();
            product.transform.position = transform.position;
        }
    }
}
