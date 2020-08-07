using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPoolingManager : MonoBehaviour
{
    public static ProductPoolingManager instance;

    public GameObject productPrefab = null;

    public Queue<GameObject> myQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        GameObject parentObject = new GameObject();
        parentObject.name = "Object Pool";
        

        for (int i = 0; i < 500; i++)
        {
            GameObject product = Instantiate(productPrefab, Vector3.zero, Quaternion.identity);
            myQueue.Enqueue(product);
            product.transform.parent = parentObject.transform;

            product.SetActive(false);
        }
    }

    public void InsertQueue(GameObject product)
    {
        myQueue.Enqueue(product);
        product.SetActive(false);
    } 

    public GameObject GetQueue()
    {
        GameObject product = myQueue.Dequeue();
        product.SetActive(true);
        return product;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
