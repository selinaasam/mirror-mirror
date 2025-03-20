using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit(); // Quit the game in standalone build
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop the game in the editor (optional)
#endif
    }
}