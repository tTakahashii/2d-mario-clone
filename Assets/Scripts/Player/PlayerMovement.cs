using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private BoxCollider2D playerBox;
    [SerializeField] private LayerMask collisionLayer;
    private Vector2 velocity;
    private bool inAir = true, shouldJump = false;

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerRenderer;

    [SerializeField] private float movementSpeed = 5f, jumpForce = 7f, colliderOffset = 0.05f;
    [SerializeField] private int maxJump = 2;
    private int currentJump = 0;

    private enum MovementState { idle, running, jumping, falling }

    // Update is called once per frame
    void Update()
    {
        if (GroundCheck())
        {
            inAir = false;
        }
        else
        {
            inAir = true;
        }

        MovePlayer();
        UpdateAnimation();
    }

    private void MovePlayer()
    {
        velocity = playerRb.velocity;

        velocity.x = Input.GetAxis("Horizontal") * movementSpeed;

        shouldJump = Input.GetKeyDown("space") ? true : shouldJump;

        currentJump = !inAir ? 0 : Mathf.Clamp(currentJump, 1, maxJump);

        if (shouldJump)
        {
            if ((!inAir || (inAir && playerRb.velocity.y < 3f)) && currentJump < maxJump)
            {
                velocity.y = jumpForce;
                shouldJump = false;
                currentJump += 1;
            }
        }

        playerRb.velocity = velocity;
    }

    private void UpdateAnimation()
    {
        
        MovementState state;

        if (playerRb.velocity.x != 0f)
        {
            state = MovementState.running;

            if (velocity.x < 0f) playerRenderer.flipX = true;
            else if (velocity.x > 0f) playerRenderer.flipX = false;
        }
        
        else
        {
            state = MovementState.idle;
        }

        if (playerRb.velocity.y > 0.05f)
        {
            state = MovementState.jumping;
        }
        else if (playerRb.velocity.y < -0.05f)
        {
            state = MovementState.falling;
        }

        playerAnimator.SetInteger("state", (int)state);
    }

    private bool GroundCheck()
    {
        return Physics2D.BoxCast(playerBox.bounds.center, playerBox.bounds.size, 0f, Vector2.down, colliderOffset, collisionLayer);
    }
}
