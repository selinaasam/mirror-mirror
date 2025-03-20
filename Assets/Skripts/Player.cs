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

    public AudioSource footstepAudio; // Reference to AudioSource
    public AudioClip footstepClip; // Footstep sound clip

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        footstepAudio = GetComponent<AudioSource>();

        if (footstepClip != null)
        {
            footstepAudio.clip = footstepClip;
            footstepAudio.loop = true; // Enable looping
        }
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
}