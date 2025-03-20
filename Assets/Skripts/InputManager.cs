using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager GetInstance()
    {
        if (_instance == null)
        {
            GameObject inputManagerObject = new GameObject("InputManager");
            _instance = inputManagerObject.AddComponent<InputManager>();
        }
        return _instance;
    }

    public bool GetInteractPressed()
    {
        return Input.GetKeyDown(KeyCode.E); // Key for interaction
    }

    public bool GetSubmitPressed() // Updated method for submission
    {
        // Check for spacebar or left mouse button click
        return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
    }
}