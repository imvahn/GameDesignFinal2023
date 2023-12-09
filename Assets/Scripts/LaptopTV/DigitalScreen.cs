using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitalScreen : MonoBehaviour
{
    public void ChangeMaterial(Material newMaterial)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && newMaterial != null)
        {
            renderer.material = newMaterial;
        }
    }
}
