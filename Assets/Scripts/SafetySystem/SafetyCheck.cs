﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SafetyCheck : MonoBehaviour
{
    public List<MeshRenderer> meshes;
    public LayerMask layer;

    private float safetyRange = 1f;
    // 나눗셈 연산을 한번만 실행시키기 위한 변수
    private float reciprocalSafetyRange;
    private bool isActive = false;

    private void Start()
    {
        reciprocalSafetyRange = 1 / safetyRange;
        GameObject[] Warnings = GameObject.FindGameObjectsWithTag("Warning");

        for (int i = 0; i < Warnings.Length; i++)
        {
            meshes.Add(Warnings[i].GetComponent<MeshRenderer>());
            meshes[i].enabled = isActive;
        }

    }

    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * safetyRange, Color.white);
        Debug.DrawRay(transform.position, (transform.forward + transform.right).normalized * safetyRange, Color.white);
        Debug.DrawRay(transform.position, (transform.forward - transform.right).normalized * safetyRange, Color.white);

        float dangerDegree = 0f;

        if (Physics.Raycast(transform.position, transform.forward, out hit, safetyRange, layer))
        {
                float dis = hit.distance;
                dangerDegree = (safetyRange - dis) * reciprocalSafetyRange;
        }

        if (Physics.Raycast(transform.position, transform.forward + transform.right, out hit, safetyRange, layer))
        {
            float dis = hit.distance;
            float newDangerDegree = (safetyRange - dis) * reciprocalSafetyRange;

            if (newDangerDegree > dangerDegree) dangerDegree = newDangerDegree;
        }

        if (Physics.Raycast(transform.position, transform.forward - transform.right, out hit, safetyRange, layer))
        {
            float dis = hit.distance;
            float newDangerDegree = (safetyRange - dis) * reciprocalSafetyRange;

            if (newDangerDegree > dangerDegree) dangerDegree = newDangerDegree;
        }

        if(dangerDegree > 0.05f && !isActive)
        {
            for (int i = 0; i < meshes.Count; i++)
            {
                meshes[i].enabled = true;
            }
            isActive = true;
        }

        if (dangerDegree < 0.05f && isActive)
        {
            for (int i = 0; i < meshes.Count; i++)
            {
                meshes[i].enabled = false;
            }
            isActive = false;
        }

        if(isActive) SetAlpha(meshes, dangerDegree);
    }

    void SetAlpha(List<MeshRenderer> meshes, float alphaValue)
    {
        for (int i = 0; i < meshes.Count; i++)
        {
            Color color = meshes[i].material.color;
            color.a = alphaValue;
            meshes[i].material.color = color;
        }
    }


}
