using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stoppe das Spiel im Editor
#else
        Application.Quit(); // Beende das Spiel im Standalone-Build
#endif
    }
}