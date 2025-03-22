using System.Diagnostics;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 offset;
    private Camera cam;
    private bool isDragging = false;
    private bool placedCorrectly = false;

    void Start()
    {
        cam = Camera.main;
        startPosition = transform.position; // Save the original position
    }

    void OnMouseDown()
    {
        if (!placedCorrectly) // Only allow dragging if not placed correctly
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPos();
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Check if the object is placed in a valid drop zone
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f); // Check for colliders around the object's position

        bool placedInDropZone = false; // Track if placed in a drop zone

        foreach (Collider2D collider in colliders)
        {
            DropZone dropZone = collider.GetComponent<DropZone>();
            if (dropZone != null && dropZone.CanAccept(gameObject))
            {
                // Snap to drop zone center
                transform.position = dropZone.transform.position;
                PlaceCorrectly(); // Lock the object
                placedInDropZone = true; // Mark as placed in drop zone
                dropZone.AddItem(gameObject); // Add item to drop zone
                break; // Exit the loop as we've found a drop zone
            }
        }

        if (!placedInDropZone) // If not placed correctly, reset position
        {
            ResetPosition();
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.nearClipPlane; // Set the Z to the near clipping plane
        return cam.ScreenToWorldPoint(mousePoint);
    }

    public void ResetPosition()
    {
        transform.position = startPosition; // Move back to original position
    }

    public void PlaceCorrectly()
    {
        placedCorrectly = true; // Prevents dragging again after correct placement
    }
}