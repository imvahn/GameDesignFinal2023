using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{

    private bool isHolding; 
    private Rigidbody rgb;
    public Transform playerCamera;

    void Start()
    {
        isHolding = false;
        rgb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    public void Interact()
    {
        if (isHolding == true)
        {
            PutDown();
        }
        else
        {
            PickUp();
        }

    }

    public void PickUp()
    {
        transform.SetParent(playerCamera); //attaches item to camera to carry around
        rgb.isKinematic = true; //turns off physics of item
        isHolding = true;
    }

    public void PutDown()
    {
        transform.parent = null; //removes item from camera
        rgb.isKinematic = false; //turns on physics of item
        isHolding = false;
    }

    public string GetDescription()
    {
        if (isHolding == true)
        {
            return "Put down";
        }
        else
        {
            return "Pick up";
        }
    }
}
