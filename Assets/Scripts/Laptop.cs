using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Laptop : MonoBehaviour, IInteractable
{

    public GameObject laptopUI;
    public TMP_InputField inputField;
    public TMP_Text errorText;
    public GameObject email;

    private bool isLoggedIn;

    public FirstPersonController playerMovement;
    public GameObject Screen;

    void Start()
    {
        isLoggedIn = false;
        
        if (laptopUI != null)
        {
            laptopUI.SetActive(false);
            email.SetActive(false);
        }
    }

    public void Clear()
    {
        errorText.text = string.Empty;
    }

    public void LogIn()
    {
        string password = inputField.text;
        if (password == "dgbcg")
        {
            isLoggedIn = true;
            email.SetActive(true);
            //set screen to email
        }
        else
        {
            errorText.text = "Incorrect";
        }
    }

    public void Interact()
    {
        if (laptopUI != null)
        {
            bool currentState = laptopUI.activeSelf; // Get the current state
            laptopUI.SetActive(!currentState); // Toggle the current state
            GlobalVariables.isLooking = !currentState; // Set isLooking based on laptopUI state

            if (laptopUI.activeSelf) //open laptop
            {
                playerMovement?.FreezeMovement(); //stop player movement
                Cursor.visible = true; // Make the cursor visible
                Cursor.lockState = CursorLockMode.None; // Unlock cursor
                if (isLoggedIn)
                {
                    email.SetActive(true); //show email if already logged in
                    //set screen to email
                }
                else
                {
                    //set screen to login
                }
            }
            else //close laptop
            {
                playerMovement?.ResumeMovement(); //resume player movement
                Cursor.visible = false; //Make curse invisible
                laptopUI.SetActive(false); //close laptop UI
            }
        }
    }

    public string GetDescription()
    {
        return "Use Computer";
    }
}
