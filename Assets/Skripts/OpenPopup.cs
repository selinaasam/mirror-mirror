using UnityEngine;

public class OpenPopup : MonoBehaviour
{
    public GameObject popup; // Assign your popup GameObject in the Inspector

    // Method to open the popup
    public void Open()
    {
        if (popup != null)
        {
            popup.SetActive(true); // Enable the popup GameObject
        }
    }
}
