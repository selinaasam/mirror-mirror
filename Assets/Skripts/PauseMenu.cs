using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private InventoryManager inventoryManager;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ClosePauseMenu();
            }
            else
            {
                if (inventoryManager != null && inventoryManager.IsInventoryOpen())
                {
                    inventoryManager.CloseInventory();
                    GamePauseManager.SwitchMenu(); // Keeps the game paused
                }
                OpenPauseMenu();
            }
        }
    }

    public void OpenPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        GamePauseManager.PauseGame();
        isPaused = true;
    }

    public void ClosePauseMenu()
    {
        pauseMenuUI.SetActive(false);
        GamePauseManager.ResumeGame();
        isPaused = false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
