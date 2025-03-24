using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private InventoryManager inventoryManager; // Reference to InventoryManager

    void Start()
    {
        pauseMenuUI.SetActive(false);
        inventoryManager = FindObjectOfType<InventoryManager>(); // Find InventoryManager in the scene
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
                // Close inventory if it's open
                if (inventoryManager != null && inventoryManager.IsPaused())
                {
                    inventoryManager.ResumeGame();
                }
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}