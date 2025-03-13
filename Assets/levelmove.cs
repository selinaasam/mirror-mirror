using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmove : MonoBehaviour
{
    [SerializeField] private string newLevel; // Set this in the Inspector
    private bool playerInTrigger = false; // Track if the player is inside the trigger

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true; // Player entered the trigger area
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false; // Player left the trigger area
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E)) // Check if player is in trigger and pressed 'E'
        {
            if (!string.IsNullOrEmpty(newLevel))
            {
                SceneManager.LoadScene(newLevel);
            }
        }
    }
}