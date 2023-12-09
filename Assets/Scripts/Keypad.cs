using System.Collections;
using System.Collections.Generic;
using SojaExiles;
using UnityEngine;

public class Keypad : MonoBehaviour, IInteractable
{
    public GameObject keypadUI;
    public FirstPersonController playerMovement;

    private void Start()
    {
        keypadUI.SetActive(false);
    }
    public void Interact()
    {
        if (keypadUI != null)
        {
            bool currentState = keypadUI.activeSelf; // Get the current state
            keypadUI.SetActive(!currentState); // Toggle the current state
            GlobalVariables.isLooking = !currentState; // Set isLooking based on laptopUI state

            if (keypadUI.activeSelf)
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
