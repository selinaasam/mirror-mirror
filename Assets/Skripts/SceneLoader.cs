using UnityEngine;
using UnityEngine.SceneManagement; // Make sure to include this namespace

public class SceneLoader : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject

    // This function will be called when the button is clicked
    public void LoadRoomKai()
    {
        SceneManager.LoadScene("room-kai");
    }
}