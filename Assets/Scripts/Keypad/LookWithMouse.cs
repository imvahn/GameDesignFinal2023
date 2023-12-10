using System.Collections;
using System.Collections.Generic;
using SojaExiles;
using UnityEngine;

public class LookWithMouse : MonoBehaviour, IInteractable
{
    public GameObject UI;
    public FirstPersonController playerMovement;

    private void Start()
    {
        UI.SetActive(false);
    }
    public void Interact()
    {
        if (UI != null)
        {
            bool currentState = UI.activeSelf; // Get the current state
            UI.SetActive(!currentState); // Toggle the current state
            GlobalVariables.isLooking = !currentState; // Set isLooking based on laptopUI state

            if (UI.activeSelf)
            {
                playerMovement?.FreezeMovement(); //stop player movement
                Cursor.visible = true; // Make the cursor visible
                Cursor.lockState = CursorLockMode.None; // Unlock cursor
            }
            else
            {
                playerMovement?.ResumeMovement(); //resume player movement
                Cursor.visible = false; //Make cursor invisible
            }
        }
    }

    public string GetDescription()
    {
        return "Use Keypad";
    }
}
