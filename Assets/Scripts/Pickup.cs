using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{

    private Rigidbody rgb;
    public bool isHolding;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float pickupForce = 150.0f;

    private InteractorScript interactor;

    void Start()
    {
        isHolding = false;
        rgb = GetComponent<Rigidbody>();
        interactor = GameObject.FindObjectOfType<InteractorScript>();
    }

    void Update()
    {
        if (isHolding)
        {
            MoveObject();
        }
    }

    public void Interact()
    {
        if (!isHolding)
        {
            MoveObject();
            PickUp();
        }
        else
        {
            PutDown();
        }

    }

    public string GetDescription()
    {
        if (isHolding)
        {
            return "Put down";
        }
        else
        {
            return "Pick up";
        }
    }

    // Function to pick up the object
    public void PickUp()
    {
        rgb.useGravity = false;
        rgb.drag = 10;
        rgb.constraints = RigidbodyConstraints.FreezeRotation;
        isHolding = true;
    }

    // Function to put down the object
    public void PutDown()
    {
        rgb.useGravity = true;
        rgb.drag = 1;
        rgb.constraints = RigidbodyConstraints.None;
        isHolding = false;
    }

    // Function to move the object
    public void MoveObject()
    {
        Vector3 hitPoint = interactor.GetHitPoint();
        Vector3 directionToCamera = cameraTransform.position - hitPoint;
        float distance = Vector3.Distance(hitPoint, cameraTransform.position); // Calculate distance between hit point and camera
        Vector3 targetPosition = cameraTransform.position + directionToCamera.normalized * (distance - 5.0f); // Adjust pickupDistance as needed
        transform.position = targetPosition;
    }
}
