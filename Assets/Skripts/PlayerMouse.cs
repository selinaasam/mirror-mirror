using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    public Texture2D customCursor; // Drag your custom cursor image into this field in Unity
    public Vector2 cursorOffset = Vector2.zero; // Offset if needed (adjust in Inspector)

    void Start()
    {
        // Hide the default system cursor and replace it with a custom one
        Cursor.SetCursor(customCursor, cursorOffset, CursorMode.Auto);
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Keep cursor at the correct depth in 2D
        transform.position = mousePosition; // Move player to follow mouse
    }
}