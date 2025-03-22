using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public GameObject popup; // Assign your popup GameObject in the Inspector

    // Method to close the popup
    public void Close()
    {
        if (popup != null)
        {
            popup.SetActive(false); // Disable the popup GameObject
        }
    }
}
