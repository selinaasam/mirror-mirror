using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject VisualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    private bool hasBeenTriggered; // Track if this trigger has been activated

    private void Awake()
    {
        playerInRange = false;
        hasBeenTriggered = false; // Initialize to false
        if (VisualCue != null)
        {
            VisualCue.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !hasBeenTriggered)
        {
            if (VisualCue == null || !VisualCue.activeSelf)
            {
                // Trigger dialogue automatically if no visual cue
                TriggerDialogue();
            }
            else
            {
                VisualCue.SetActive(true);
                if (InputManager.GetInstance().GetInteractPressed())
                {
                    TriggerDialogue();
                }
            }
        }
        else if (VisualCue != null)
        {
            VisualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            if (VisualCue == null || !VisualCue.activeSelf)
            {
                // Trigger dialogue immediately if no visual cue is present
                TriggerDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            if (VisualCue != null)
            {
                VisualCue.SetActive(false);
            }
        }
    }

    private void TriggerDialogue()
    {
        if (!hasBeenTriggered) // Check if the trigger has already been used
        {
            hasBeenTriggered = true; // Mark as triggered
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            if (VisualCue != null)
            {
                VisualCue.SetActive(false); // Optionally hide the visual cue after triggering
            }
        }
    }
}
