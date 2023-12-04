using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Laptop : MonoBehaviour, IInteractable
{

    public GameObject laptopUI;
    public GameObject inputField;

    private bool isInteracting;
    private bool isLoggedIn;

    public FirstPersonController playerMovement;

    void Start()
    {
        isLoggedIn = false;
        
        if (laptopUI != null)
        {
            laptopUI.SetActive(false);
        }
    }

    //void Update()
    //{
    //    if (laptopUI.activeSelf)
    //    {
    //        if (!isLoggedIn)
    //        {
    //            string password = inputField.GetComponent<TMP_InputField>().text;
    //            if (password == "dgbcg")
    //            {
    //                isLoggedIn = true;
    //            }
    //        }
    //    }
    //}

    public void LogIn()
    {
        string password = inputField.GetComponent<TMP_InputField>().text;
        if (password == "dgbcg")
        {
            isLoggedIn = true;
        }
    }

    public void Interact()
    {
        if (laptopUI != null)
        {
            laptopUI.SetActive(!laptopUI.activeSelf);

            if (laptopUI.activeSelf)
            {
                playerMovement?.FreezeMovement();
                if (isLoggedIn)
                {
                    laptopUI.SetActive(false);
                    //display email
                    playerMovement?.ResumeMovement();
                }
            }
        }
    }

    public string GetDescription()
    {
        return "Use Computer";
    }
}
