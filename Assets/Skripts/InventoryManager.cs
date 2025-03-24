using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI;
    private bool isPaused = false;
    private PauseMenu pauseMenu; // Reference to PauseMenu

    void Start()
    {
        inventoryUI.SetActive(false);
        pauseMenu = FindObjectOfType<PauseMenu>(); // Find PauseMenu in the scene
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                // Close pause menu if it's open
                if (pauseMenu != null && pauseMenu.IsPaused())
                {
                    pauseMenu.ResumeGame();
                }
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        inventoryUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}