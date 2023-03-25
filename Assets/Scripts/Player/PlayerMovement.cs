using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float movementSpeed = 5f, jumpForce = 7f;
    [SerializeField] private int maxJump = 2;
    private Vector2 velocity;
    private float xVel = 0f, yVel = 0f;
    private int currentJump = 0;
    private bool inAir = true, shouldJump = false;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inAir);
        //Debug.Log(currentJump);

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
