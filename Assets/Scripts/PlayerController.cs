using System;
using UnityEngine;
// Local *Variables:* *`playerHealth`*.
// *Public Variables:* *`public int PlayerScore`
// *Private Variables:* _currentHealth
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground"); // Make sure to set the ground layer in Unity.
    }

    private void Update()
    {
        // Check for ground contact (you may need to adjust the detection method).
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, groundLayer);

        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        // Player jumping
        if (isGrounded && Input.GetButtonDown("Spacebar"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}

