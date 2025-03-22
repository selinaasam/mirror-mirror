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
            // Force release GUI control to prevent Unity GUI errors
            UnityEngine.GUIUtility.hotControl = 0;
            UnityEngine.GUIUtility.keyboardControl = 0;

            if (name.StartsWith("Left"))
                leftCount++;
            else if (name.StartsWith("Right"))
                rightCount++;

            RectTransform draggedRectTransform = draggedItem.GetComponent<RectTransform>();
            RectTransform dropTargetRectTransform = GetComponent<RectTransform>();

            draggedRectTransform.anchoredPosition = dropTargetRectTransform.anchoredPosition +
                new Vector2(0, GetListHeight(dropTargetRectTransform) + spacing * droppedItemCount);

            droppedItemCount++;
            draggedItem.DisableDragging();

            UnityEngine.Debug.Log($"Left Count: {leftCount}, Right Count: {rightCount}");

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

        if (string.IsNullOrEmpty(nextSceneName))
        {
            UnityEngine.Debug.LogError("Error: nextSceneName is empty! Set it in the Inspector.");
            yield break;
        }

        UnityEngine.Debug.Log($"Loading Scene: {nextSceneName}");
        SceneManager.LoadScene(nextSceneName);
    }

    public void DisableDragging()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        UnityEngine.GUIUtility.hotControl = 0;
        UnityEngine.GUIUtility.keyboardControl = 0;
    }


}