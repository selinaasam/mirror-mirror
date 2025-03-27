using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    private static int activeMenus = 0;
    private static Player player; // Reference to Player script

    public static void RegisterPlayer(Player p)
    {
        player = p;
    }

    public static void PauseGame()
    {
        activeMenus++;
        Time.timeScale = 0f;

        if (player != null)
        {
            player.SetSpeed(0f); // Stop player movement when paused
        }
    }

    public static void ResumeGame()
    {
        activeMenus = Mathf.Max(0, activeMenus - 1);
        if (activeMenus == 0)
        {
            Time.timeScale = 1f;

            if (player != null)
            {
                player.ResetSpeed(); // Restore player movement when unpaused
            }
        }
    }

    public static void SwitchMenu()
    {
        // Prevents unpausing when switching between inventory and pause menu
        Time.timeScale = 0f;
    }

    public static bool IsGamePaused()
    {
        return activeMenus > 0;
    }
}
