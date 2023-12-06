using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material newMaterial; // Reference to the new material you want to apply

    void ChangeObjectMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && newMaterial != null)
        {
            renderer.material = newMaterial;
        }
    }
}
