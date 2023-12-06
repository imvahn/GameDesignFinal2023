using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopPuzzle : MonoBehaviour, IInteractable // Must add the IInteractable class
{
    public GameObject manuscriptUI; // Reference to the UI elements for the manuscript
    public FirstPersonController playerMovement; // Reference to controller to freeze player movement while reading the texts. This is because the player needs to be looking
                                                 // at the object to start/end the interaction, and this was the easiest solution.
    private void Start()
    {
        // Ensure the manuscript UI is initially disabled
        if (manuscriptUI != null)
        {
            manuscriptUI.SetActive(false);
        }
    }

    public void Interact()
    {
        // Toggle the manuscript UI on interaction
        if (manuscriptUI != null) // Check if the manuscriptUI is assigned
        {
            bool currentState = manuscriptUI.activeSelf; // Get the current state
            manuscriptUI.SetActive(!currentState); // Toggle the state

            if (!currentState) // If the UI was just activated
            {
                playerMovement?.FreezeMovement();
            }
            else // If the UI was just deactivated
            {
                playerMovement?.ResumeMovement();
            }
        }
    }

    public string GetDescription()
    {
        return "Read manuscript";
    }
}
