using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicked : MonoBehaviour, IInteractable
{

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
    }

    public void Interact()
    {

    }

    public string GetDescription()
    {
        if (rb.useGravity) // If the object is not being picked up
        {
            return "Pick Up";
        }
        else
        {
            if (GlobalVariables.remoteHeld == true)
            {
                return "Left Click TV";
            }
            return "Put Down";
        }
    }
}
