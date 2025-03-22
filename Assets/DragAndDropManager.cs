using System.Collections; // Add this directive
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // If you're using TextMeshPro

public class DragAndDropManager : MonoBehaviour
{
    public List<DragObject> draggableObjects; // Assign your draggable objects in the inspector
    public TextMeshProUGUI messageText; // Assign your TextMeshPro text in the inspector (or use UI.Text)
    public string nextSceneName; // Set the name of the next scene

    private void Start()
    {
        messageText.gameObject.SetActive(false); // Hide message initially
    }

    public void CheckAllPlaced()
    {
        foreach (var draggable in draggableObjects)
        {
            if (draggable.IsDraggable())
            {
                Debug.Log($"{draggable.name} is still draggable."); // Debug log
                return; // If any object is still draggable, exit the function
            }
        }

        Debug.Log("All objects are placed correctly!"); // Debug log
        StartCoroutine(DisplayMessageAndChangeScene());
    }

    private IEnumerator DisplayMessageAndChangeScene()
    {
        messageText.text = "Correct!";
        messageText.gameObject.SetActive(true); // Show the message

        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        SceneManager.LoadScene(nextSceneName); // Change to the next scene
    }
}