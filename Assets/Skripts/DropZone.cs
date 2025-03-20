using System.Diagnostics;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    private int acceptedItemsCount = 0;

    public bool CanAccept(GameObject item)
    {
        // Implement your logic to determine if the item can be accepted
        // For example, check item type or tag
        return true; // Replace with actual condition
    }

    public void AddItem(GameObject item)
    {
        acceptedItemsCount++;
        // Additional logic when an item is added (e.g., updating UI or state)
    }
}