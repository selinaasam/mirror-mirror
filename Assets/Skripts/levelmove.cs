using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Für TextMeshPro

public class levelmove : MonoBehaviour
{
    [SerializeField] private string newLevel; // Levelname im Inspector setzen
    [SerializeField] private TextMeshProUGUI uiText; // UI-Textfeld für die Nachricht

    private bool playerInTrigger = false; // Verfolgt, ob der Spieler im Trigger ist

    private void Start()
    {
        if (uiText != null)
        {
            uiText.gameObject.SetActive(false); // Text zu Beginn ausblenden
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true; // Spieler ist im Trigger
            if (uiText != null)
            {
                uiText.gameObject.SetActive(true); // UI-Text anzeigen
                uiText.text = "Press 'E' to enter"; // Nachricht anpassen
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false; // Spieler hat den Trigger verlassen
            if (uiText != null)
            {
                uiText.gameObject.SetActive(false); // UI-Text ausblenden
            }
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E)) // Spieler im Trigger & Taste gedrückt
        {
            if (!string.IsNullOrEmpty(newLevel))
            {
                SceneManager.LoadScene(newLevel);
            }
        }
    }
}