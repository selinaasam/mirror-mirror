using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce = 10f;

    private float Move;
    public Rigidbody2D rb;
    public Animator animator;

    public bool isJumping;

    private SpriteRenderer spriteRenderer;

    public AudioSource footstepAudio;
    public AudioClip footstepClip;

    private float defaultSpeed; // Store original speed

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        footstepAudio = GetComponent<AudioSource>();

        if (footstepClip != null)
        {
            footstepAudio.clip = footstepClip;
            footstepAudio.loop = true;
        }

        defaultSpeed = speed; // Store the default speed
        GamePauseManager.RegisterPlayer(this); // Register player to pause manager
    }

    void Update()
    {
        // Check if DialogueManager is available
        if (DialogueManager.GetInstance() != null && DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Move = 0;
            animator.SetFloat("Speed", 0);
            footstepAudio.Stop();
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        if (GamePauseManager.IsGamePaused())
        {
            Move = 0;
            animator.SetFloat("Speed", 0);
            footstepAudio.Stop();
            rb.velocity = new Vector2(0, rb.velocity.y);
            return; // Skip movement while paused
        }

        // Player movement controls
        Move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Move));

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        // Flip the sprite when changing direction
        spriteRenderer.flipX = Move > 0;

        // Play footstep sound when moving & not jumping
        if (Mathf.Abs(rb.velocity.x) > 0.01f && !isJumping)
        {
            if (!footstepAudio.isPlaying)
            {
                footstepAudio.Play();
            }
        }
        else
        {
            footstepAudio.Stop();
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void ResetSpeed()
    {
        speed = defaultSpeed;
    }
}
