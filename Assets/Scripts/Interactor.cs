using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// All interactee behavior inherits this interface so the interactor can invoke specific bevhaiors
interface IInteractable
{
    public void Interact();
    string GetDescription();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource; // Stores a reference to the transform from which the interacting ray will be casted
    public float interactRange; // Determines the length of the raycast
    private bool hitSomething; // Bool to determine if the raycast has hit something
    public LayerMask layerMask; // Makes sure object is interactable
    private RaycastHit hitInfo; // Declaring the RaycastHit variable outside the scope

    public GameObject interactionUI; // UI
    public TextMeshProUGUI interactionText; // Text

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Interactable") | LayerMask.GetMask("Walls");
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();

        //Debug ray visualization
        DebugRay();
    }

    private void CastRay()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward); // Raycast created with position and direction of interactor source

        hitSomething = false;

        if (Physics.Raycast(r, out hitInfo, interactRange, layerMask)) // Check if raycast detects a collider
        {
            IInteractable interactable = hitInfo.collider.gameObject.GetComponent<IInteractable>(); // Use collision information to attempt an interaction with the object by attempting to get an instance of an interactable interface
            if (interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDescription(); // Calls GetDescription function on given object
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact(); // Calls interact function on given object
                }
            }
        }

        interactionUI.SetActive(hitSomething); // Show interaction UI if player hits something
    }

    private void DebugRay()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        Debug.DrawRay(r.origin, r.direction * interactRange, Color.blue); // Draw debug ray from InteractorSource position in the forward direction

        // Optionally, draw the hit point if something is hit by the raycast
        if (hitSomething)
        {
            Debug.DrawRay(r.origin, r.direction * hitInfo.distance, Color.red);
        }
    }
}
