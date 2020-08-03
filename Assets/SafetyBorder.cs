using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyBorder : MonoBehaviour
{
    MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public void SetAlpha(float alphaValue)
    {
        Color currentColor = mesh.material.color;
        currentColor.a = alphaValue;
        mesh.material.color = currentColor;
    }
}
