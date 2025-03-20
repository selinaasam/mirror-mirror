using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    // Methode zum Fortsetzen des Spiels
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Spielgeschwindigkeit auf normal setzen
        // Hier kannst du eventuell andere Logik hinzufügen, um das Spiel zu aktualisieren
    }
}