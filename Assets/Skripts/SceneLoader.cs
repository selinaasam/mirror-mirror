using UnityEngine;
using UnityEngine.SceneManagement; // Make sure to include this namespace

public class SceneLoader : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public string sceneName; // Public field for the scene name

    // This function will be called when the button is clicked
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}