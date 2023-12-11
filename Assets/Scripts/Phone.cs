using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Phone : MonoBehaviour, IInteractable // Must add the IInteractable class
{

    public GameObject phoneUI; // Reference to the UI elements for the phone screen
    public TextMeshProUGUI textDisplay; // Reference to the Text component where text will be displayed
    public string[] linesOfText; // Array of text lines to display

    public bool hasDisplayedOnce; // Bool to check if the texts have been read for the first time

    private bool isTyping; // Bool to check if the typing coroutine is running to prevent the coroutine from being run again before it's finished
    private bool isInteracting; // Flag to track if interaction is in progress
    private bool isRunning; // Bool to check if the type coroutine is running (for the pause menu)

    public FirstPersonController playerMovement; // Reference to controller to freeze player movement while reading the texts. This is because the player needs to be looking
                                                 // at the object to start/end the interaction, and this was the easiest solution.

    public GameObject tutorial; //tutorial ui

    private void Start()
    {
        isTyping = false;
        hasDisplayedOnce = false;

        // Adding text lines manually
        linesOfText = new string[]
        {
        "Girlfriend: I'm really disappointed in you",
        "\n",
        "\n",
        "Girlfriend: You need to get your life together. Your apartment is a mess. You haven't done any work in weeks. You used to be such a great musician.",
        "\n",
        "\n",
        "Girlfriend: You need to complete the song you've been working on or we're through. And clean your apartment while you're at it!!",
        "\n",
        "\n",
        "\n",
        "Press [E] to close this window."
        };

        // Ensure the phone UI is initially disabled
        if (phoneUI != null)
        {
            phoneUI.SetActive(false);
        }
        if (tutorial != null)
        {
            tutorial.SetActive(true);
        }
    }

    public void Interact()
    {
        // Check if already interacting (coroutine running), prevent new interaction
        if (isInteracting)
        {
            return;
        }

        // Toggle the phone screen UI on interaction
        if (phoneUI != null)
        {
            phoneUI.SetActive(!phoneUI.activeSelf);

            if (phoneUI.activeSelf)
            {

                tutorial.SetActive(false);
                isInteracting = true; // Set flag to true to prevent new interactions

                if (!hasDisplayedOnce) // If text has not been displayed yet, start typing
                {
                    GlobalVariables.isLooking = true;
                    StartCoroutine(TypeText());
                }
                else // If text has been displayed once, show all text immediately
                {
                    GlobalVariables.isLooking = true;
                    DisplayAllText();
                    isInteracting = false;
                }
            }
            else
            {
                StopAllCoroutines();
                GlobalVariables.isLooking = false;
                playerMovement?.ResumeMovement(); // Resume player movement
                isInteracting = false; // Reset flag when interaction finishes
            }
        }
    }

    // Type text out character by character
    IEnumerator TypeText()
    {
        isTyping = true;
        isRunning = true;
        playerMovement?.FreezeMovement(); // Freeze player movement

        for (int i = 0; i < linesOfText.Length; i++)
        {
            foreach (char letter in linesOfText[i].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.03f); // Adjust the speed of typing
            }
        }

        isInteracting = false;
        isTyping = false;
        isRunning = false;
        hasDisplayedOnce = true; // Text has been displayed once
        yield return new WaitForSeconds(0.5f); // Delay before resetting flag
    }

    public bool IsTyping()
    {
        return isRunning;
    }

    // Display all text immediately
    private void DisplayAllText()
    {
        playerMovement?.FreezeMovement(); // Freeze player movement
        isTyping = false; // Stops typing coroutine if it's running
        textDisplay.text = string.Join("", linesOfText); // Concatenate all lines and display at once
    }

    public string GetDescription()
    {
        return "Read texts";
    }
}
