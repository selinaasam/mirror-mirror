using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Assign your UI panel in the Inspector
    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false); // Ensure UI is hidden at game start
    }

    void Update()
    {
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
        pauseMenuUI.SetActive(true); // Show UI
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Hide UI
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }
}