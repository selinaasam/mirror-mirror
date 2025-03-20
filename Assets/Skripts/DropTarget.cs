using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Diagnostics;

public class DropTarget : MonoBehaviour, IDropHandler
{
    private float spacing = 250f; // Abstand zwischen abgelegten Elementen
    private int droppedItemCount = 0;
    private static int leftCount = 0;
    private static int rightCount = 0;

    public GameObject popupPanel; // Referenz zum Popup-Panel
    public string nextSceneName; // Name der nächsten Szene

    void Start()
    {
        // Reset counts to avoid static variable issues when reloading the scene
        leftCount = 0;
        rightCount = 0;

        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (EventSystem.current.currentSelectedGameObject != null)
            return; // Exit if another UI element is selected

        DragObject draggedItem = eventData.pointerDrag?.GetComponent<DragObject>();

        if (draggedItem != null && CanDropItem(draggedItem))
        {
            RectTransform draggedRectTransform = draggedItem.GetComponent<RectTransform>();
            RectTransform dropTargetRectTransform = GetComponent<RectTransform>();

            // Berechne die neue Position und setze das Element
            draggedRectTransform.anchoredPosition = dropTargetRectTransform.anchoredPosition +
                new Vector2(0, GetListHeight(dropTargetRectTransform) + spacing * droppedItemCount);

            droppedItemCount++;

            // Aktualisiere Zähler für links und rechts
            if (name.StartsWith("Left"))
                leftCount++;
            else if (name.StartsWith("Right"))
                rightCount++;

            draggedItem.DisableDragging();

            CheckCompletion();
        }
    }

    private bool CanDropItem(DragObject draggedItem)
    {
        return (draggedItem.name.StartsWith("Left") && name.StartsWith("Left")) ||
               (draggedItem.name.StartsWith("Right") && name.StartsWith("Right"));
    }

    private float GetListHeight(RectTransform dropTarget)
    {
        if (dropTarget.childCount == 0) return 0f; // Avoid error if no children are present

        float height = -250f;
        foreach (Transform child in dropTarget)
        {
            RectTransform rect = child.GetComponent<RectTransform>();
            if (rect != null)
                height += rect.rect.height;
        }
        return height;
    }

    private void CheckCompletion()
    {

        if (leftCount == 3 && rightCount == 3)
        {
            ShowPopup();
            StartCoroutine(ChangeScene(2f));
        }
    }

    private void ShowPopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
        }
    }

    IEnumerator ChangeScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}