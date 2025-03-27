using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI;
    private bool isInventoryOpen = false;
    private PauseMenu pauseMenu;

    void Start()
    {
        inventoryUI.SetActive(false);
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isInventoryOpen)
            {
                CloseInventory();
            }
            else
            {
                if (pauseMenu != null && pauseMenu.IsPaused())
                {
                    pauseMenu.ClosePauseMenu();
                    GamePauseManager.SwitchMenu(); // Keeps the game paused
                }
                OpenInventory();
            }
        }
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
        GamePauseManager.PauseGame();
        isInventoryOpen = true;
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
        GamePauseManager.ResumeGame();
        isInventoryOpen = false;
    }

    public bool IsInventoryOpen()
    {
        return isInventoryOpen;
    }
}
