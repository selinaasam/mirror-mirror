using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.SceneManagement; // Import Scene Management

public class DialogueManager : MonoBehaviour
{
    [Header("UI dialogue")]
    [SerializeField] private GameObject dialogueField;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private string currentInkFileName; // Store the name of the ink file

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
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
        currentInkFileName = inkJSON.name; // Store the name of the ink file
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
            dialogueIsPlaying = false;
            dialogueField.SetActive(false);
            dialogueText.text = "";

            // Load the next scene
            SceneManager.LoadScene("continued");

        }
        else
        {
            ExitDialogueMode();
        }
    }
}
