using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSwitch : MonoBehaviour
{
    public SimpleConveyorbelt conveyorbelt;

    private bool isActive = false;

    private void Start()
    {
        conveyorbelt = GetComponentInParent<SimpleConveyorbelt>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isActive)
        {

            conveyorbelt.TurnDirection();
            StartCoroutine(PauseDetection());
        }   
    }

    IEnumerator PauseDetection()
    {
        isActive = true;

        yield return new WaitForSeconds(0.3f);

        isActive = false;
    }
}
