using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetySystem : MonoBehaviour
{
    public float rayDistance = 2f;
    private float inverseRayDistance;

    [Range(0,1)]
    public float alphaValue = 0.3f;
    public LayerMask layer;
    public SafetyBorder safety;

    // Start is called before the first frame update
    void Start()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 5, Color.white);
        inverseRayDistance = 1 / rayDistance;
        safety = FindObjectOfType<SafetyBorder>().GetComponent<SafetyBorder>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, layer))
        {
            float distance = (hit.transform.position - transform.position).magnitude;
            float dangerDegree = rayDistance - distance;

            safety.SetAlpha(dangerDegree * inverseRayDistance);
        }
    }
}
