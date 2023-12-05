using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Start()
    {
        // Initially hide the pause menu UI
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // Check for pause button input (e.g., "P" key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Stop time to pause the game
        isPaused = true;
        pauseMenuUI.SetActive(true); // Show the pause menu UI
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time to continue the game
        isPaused = false;
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
