using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("UI dialogue")]
    [SerializeField] private GameObject dialogueField;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private string currentInkFileName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            InitializeDialogueManager(); // Initialize the dialogue manager
        }
        else
        {
            gameObject.SetActive(false); // Disable this instance if another exists
        }
    }

    private void InitializeDialogueManager()
    {
        // Find or instantiate dialogueField and dialogueText
        if (dialogueField == null)
        {
            dialogueField = GameObject.Find("DialogueField"); // Ensure you have a GameObject named "DialogueField"
        }

        if (dialogueText == null)
        {
            dialogueText = dialogueField.GetComponentInChildren<TextMeshProUGUI>(); // Ensure the TextMeshProUGUI component is found
        }

        dialogueIsPlaying = false;
        dialogueField.SetActive(false);
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (InputManager.GetInstance().GetSubmitPressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        currentInkFileName = inkJSON.name;
        dialogueIsPlaying = true;
        dialogueField.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialogueField.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory != null && currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else if (currentInkFileName == "irene-city-1")
        {
            SceneManager.LoadScene("continued");
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    // Optional: Method to reset the dialogue manager if needed
    public void ResetDialogue()
    {
        currentStory = null;
        currentInkFileName = string.Empty;
        dialogueIsPlaying = false;
        dialogueField.SetActive(false);
        dialogueText.text = "";
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

}
