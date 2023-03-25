using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private float movementSpeed = 5f, jumpForce = 7f;
    [SerializeField] private int maxJump = 2;
    private Vector2 velocity;
    private int currentJump = 0;
    private bool inAir = true, shouldJump = false;

    // Update is called once per frame
    void Update()
    {
        velocity = playerRb.velocity;
        //Debug.Log(inAir);
        //Debug.Log(currentJump);

        if (velocity.x < 0f) playerRenderer.flipX = true;
        else if (velocity.x > 0f) playerRenderer.flipX = false;

        playerAnimator.SetBool("isRunning", velocity.x != 0f ? true : false);
        playerAnimator.SetBool("isFalling", velocity.y < 0f ? true : false);
        playerAnimator.SetBool("isJumping", velocity.y > 0f ? true : false);

        velocity.x = Input.GetAxis("Horizontal") * movementSpeed;

        if (Input.GetKeyDown("space"))
        {
            if (currentJump < maxJump)
            {
                shouldJump = true;
            }
        }

        if (shouldJump)
        {
            if (!inAir)
            {
                velocity.y = jumpForce;
                currentJump += 1;
                shouldJump = false;

                //Debug.Log("Jumped while grounded");
            }

            else
            {
                if (playerRb.velocity.y < 3f)
                {
                    velocity.y = jumpForce;
                    currentJump += 1;
                    shouldJump = false;
                }

                //Debug.Log("Jumped while in air");
            }
        }

        playerRb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
        currentJump = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        inAir = true;
    }
}
