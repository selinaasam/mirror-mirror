using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject VisualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON; // Corrected spelling

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        VisualCue.SetActive(false); // Corrected method and variable name
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            VisualCue.SetActive(true); // Corrected variable name
            if (InputManager.GetInstance().GetInteractPressed())
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            VisualCue.SetActive(false); // Corrected variable name
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Using CompareTag for efficiency
        {
            playerInRange = true; // Corrected assignment
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")) // Using CompareTag for efficiency
        {
            playerInRange = false; // Corrected assignment
        }
    }
}