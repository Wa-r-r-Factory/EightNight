using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductGenerator : MonoBehaviour
{
    public float genTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateProduct());
    }

    IEnumerator CreateProduct()
    {
        while (true)
        {
            yield return new WaitForSeconds(genTime);
            GameObject product = ProductPoolingManager.instance.GetQueue();
            product.transform.position = transform.position;
            product.transform.rotation = transform.rotation;
        }
    }
}
