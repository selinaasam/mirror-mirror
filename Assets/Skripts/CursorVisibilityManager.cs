using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorVisibilityManager : MonoBehaviour
{
    // Specify the scenes where you want to hide the cursor
    public string[] scenesToHideCursor;

    void Start()
    {
        // Check if the current scene is in the specified array
        if (IsCurrentSceneInArray(scenesToHideCursor))
        {
            // Hide the cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked; // Optional: lock the cursor to the center
        }
    }

    void OnDestroy()
    {
        // Reset cursor visibility when leaving the scene
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Optional: unlock the cursor
    }

    private bool IsCurrentSceneInArray(string[] scenes)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        foreach (string scene in scenes)
        {
            if (currentSceneName == scene)
            {
                return true;
            }
        }
        return false;
    }
}