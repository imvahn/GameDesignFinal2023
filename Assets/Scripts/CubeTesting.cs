using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTesting : MonoBehaviour, IInteractable // Must add the IInteractable class
{

    Material mat;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    public void Interact()
    {
        mat.color = new Color(Random.value, Random.value, Random.value);
    }

    public string GetDescription()
    {
        return "Click Me!";
    }
}
