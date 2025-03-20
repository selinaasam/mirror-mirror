using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel;
    public Button closeButton;
    public Sprite closeButtonSprite; // Dein X-Icon als Sprite

    void Start()
    {
        popupPanel.SetActive(true);

        // Überprüfen, ob ein Sprite zugewiesen wurde
        if (closeButtonSprite != null)
        {
            closeButton.image.sprite = closeButtonSprite; // Button-Sprite setzen
        }

        closeButton.onClick.AddListener(ClosePopup);
    }

    void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}