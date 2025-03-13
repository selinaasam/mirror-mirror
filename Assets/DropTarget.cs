using UnityEngine;
using UnityEngine.EventSystems;

public class DropTarget : MonoBehaviour, IDropHandler
{
    private float spacing = 250f; // Spacing between dropped items
    private int droppedItemCount = 0; // Track number of dropped items

    public void OnDrop(PointerEventData eventData)
    {
        DragObject draggedItem = eventData.pointerDrag.GetComponent<DragObject>();

        if (draggedItem != null && CanDropItem(draggedItem))
        {
            RectTransform draggedRectTransform = draggedItem.GetComponent<RectTransform>();
            RectTransform dropTargetRectTransform = GetComponent<RectTransform>();

            // Set the dragged item's position based on the order of dropping
            draggedRectTransform.anchoredPosition = dropTargetRectTransform.anchoredPosition + new Vector2(0, GetListHeight(dropTargetRectTransform) + spacing * droppedItemCount);
            droppedItemCount++; // Increment the count of dropped items

            // Disable dragging for the correctly placed item
            draggedItem.DisableDragging();
        }
    }

    // Method to check if the item can be dropped
    private bool CanDropItem(DragObject draggedItem)
    {
        // Check if the dragged item name matches the drop target name
        return (draggedItem.name.StartsWith("Left") && name.StartsWith("Left")) ||
               (draggedItem.name.StartsWith("Right") && name.StartsWith("Right"));
    }

    // Method to calculate the height of all currently dropped items
    private float GetListHeight(RectTransform dropTarget)
    {
        float height = -250f;

        // Iterate through all children of the drop target
        foreach (Transform child in dropTarget)
        {
            // Sum the height of each child item
            height += child.GetComponent<RectTransform>().rect.height;
        }

        return height;
    }
}