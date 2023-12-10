using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] LayerMask layerMask;
    private GameObject heldObj;
    private Rigidbody heldObjRB;
    private bool isHolding;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange;
    [SerializeField] private float pickupForce;

    [Header("TV Settings")]
    [SerializeField] LayerMask TVLayerMask;

    void Start()
    {
        pickupRange = 5.0f;
        pickupForce = 25.0f;
        heldObjRB = GetComponent<Rigidbody>();
        isHolding = false;
        GlobalVariables.remoteHeld = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, layerMask))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }
        if (isHolding)
        {
            MoveObject();
        }
    }

    // Function to pick up the object
    public void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;

            isHolding = true;
        }
    }

    // Function to put down the object
    public void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObj.transform.parent = null;
        heldObj = null;

        isHolding = false;
    }

    // Function to move the object
    public void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }

        // TV functionality
        if (heldObj.name == "Remote")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5.0f, TVLayerMask))
            {
                GlobalVariables.remoteHeld = true;
                if (Input.GetMouseButtonDown(0))
                {
                    if (GlobalVariables.TVisOn)
                    {
                        GlobalVariables.TVisOn = false;
                    }
                    else
                    {
                        GlobalVariables.TVisOn = true;
                    }
                }
            }
            else
            {
                GlobalVariables.remoteHeld = false;
            }
        }
    }
}
