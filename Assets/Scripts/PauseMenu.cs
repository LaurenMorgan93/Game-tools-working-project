using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;


    private void Start()
    {
        pauseScreen.SetActive(false); // Deactivate the pause panel
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Set time scale to 0 to pause the game
        pauseScreen.SetActive(true); // Activate the pause panel
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Set time scale back to 1 to resume the game
        pauseScreen.SetActive(false); // Deactivate the pause panel
    }
}
