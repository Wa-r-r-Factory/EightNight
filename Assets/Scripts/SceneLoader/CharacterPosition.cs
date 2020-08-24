using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPosition : MonoBehaviour
{
    public void SetDefaultPosition()
    {
        transform.position = new Vector3(transform.position.x, 0.85f, transform.position.z);
    }
}
