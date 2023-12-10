using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject crosshair;
    private bool isPaused;

    public FirstPersonController playerMovement;
    public Phone phone; // Reference to phone script to see if the type coroutine is running

    void Start()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false); // Initially hide pause menu UI
        Cursor.visible = false; // Make sure mouse cursor isn't visible
    }

    void Update()
    {
        // Check for pause button input (e.g., "P" key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if (!phone.IsTyping()) // Pause menu can only be activated if the text isn't typing.
            //{
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            //}
        }
    }

    public void PauseGame()
    {
        playerMovement?.FreezeMovement(); // Freeze player movement
        isPaused = true;
        pauseMenuUI.SetActive(true); // Show the pause menu UI
        crosshair.SetActive(false); // Hide the crosshair
        Cursor.visible = true; // Make the cursor visible
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
    }

    public void ResumeGame()
    {
        if (!GlobalVariables.isLooking)
        {
            playerMovement?.ResumeMovement(); // Resume player movement
        }
        isPaused = false;
        crosshair.SetActive(true); // Make the crosshair visible
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
        Cursor.visible = false; // Hide the cursor
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
