//using System.Collections;
//using System.Diagnostics;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//{
//    private CanvasGroup canvasGroup;
//    private RectTransform rectTransform;
//    private Canvas canvas;
//    private Vector2 originalPosition;
//    private bool isDraggable = true;

//    [Header("Audio Settings")]
//    public AudioClip dragSound; // Sound when dragging starts
//    public AudioClip snapSound; // Sound when snapping into place

//    private void Awake()
//    {
//        rectTransform = GetComponent<RectTransform>();
//        canvasGroup = GetComponent<CanvasGroup>();
//        canvas = GetComponentInParent<Canvas>();
//        originalPosition = rectTransform.anchoredPosition;
//    }

//    void Update()
//    {
//        // Check for mouse button click
//        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
//        {
//            PlaySound(dragSound);
//        }
//    }

//    public void OnBeginDrag(PointerEventData eventData)
//    {
//        if (!isDraggable) return;

//        canvasGroup.alpha = 0.6f;
//        canvasGroup.blocksRaycasts = false;
//    }

//    public void OnDrag(PointerEventData eventData)
//    {
//        if (!isDraggable) return;

//        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
//    }

//    private IEnumerator ReturnToOriginalPosition()
//    {
//        float duration = 0.3f;
//        float elapsed = 0f;
//        Vector2 startPos = rectTransform.anchoredPosition;

//        while (elapsed < duration)
//        {
//            rectTransform.anchoredPosition = Vector2.Lerp(startPos, originalPosition, elapsed / duration);
//            elapsed += Time.deltaTime;
//            yield return null;
//        }

//        rectTransform.anchoredPosition = originalPosition;
//    }

//    public void OnEndDrag(PointerEventData eventData)
//    {
//        canvasGroup.alpha = 1f;
//        canvasGroup.blocksRaycasts = true;

//        GameObject dropTarget = eventData.pointerCurrentRaycast.gameObject;

//        if (dropTarget != null && IsValidDropTarget(dropTarget.name))
//        {
//            rectTransform.SetParent(dropTarget.transform, true);
//            rectTransform.anchoredPosition = Vector2.zero;

//            // Play snap sound
//            PlaySound(snapSound);

//            DisableDragging();
//        }
//        else
//        {
//            StartCoroutine(ReturnToOriginalPosition());
//        }
//    }

//    private bool IsValidDropTarget(string targetName)
//    {
//        if (name.StartsWith("Left") && targetName.StartsWith("Left"))
//        {
//            return true;
//        }
//        else if (name.StartsWith("Right") && targetName.StartsWith("Right"))
//        {
//            return true;
//        }
//        return false;
//    }

//    public void DisableDragging()
//    {
//        isDraggable = false;
//        canvasGroup.interactable = false;
//        canvasGroup.blocksRaycasts = false;
//    }

//    private void PlaySound(AudioClip clip)
//    {
//        if (clip != null)
//        {
//            AudioSource audioSource = GetComponent<AudioSource>();
//            if (audioSource != null)
//            {
//                audioSource.volume = 0.4f; // Adjust this value to increase or decrease the volume
//                audioSource.PlayOneShot(clip);
//            }
//        }
//    }
//}