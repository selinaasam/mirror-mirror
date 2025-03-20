using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stoppe das Spiel im Editor
#else
        UnityEngine.Application.Quit(); // Beende das Spiel im Standalone-Build
#endif
    }
}