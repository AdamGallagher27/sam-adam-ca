using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CharachterMovement : MonoBehaviour
{

    // varaible for the charachter rigidbody
    private Rigidbody rigidBody;

    // vector 2 for keyboard / controller input
    private Vector2 movementInput = Vector2.zero;

    // variables for jumping
    private bool jumped = false;
    private float groundCheckDistance = 1.9f;
    private int numJumps = 1;
    public float jumpForce;
    public LayerMask groundLayerMask;

    // variables for movement
    public float playerSpeed;
    public bool canMove = true;

    // instantiate rigid body
    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // called when player moves or jumps
    // called in input action component
    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    // check if the player is on the ground
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayerMask);
    }

    public delegate void PlayerIsGrounded(bool grounded);

    public event PlayerIsGrounded OnGrounded;


    public delegate void PlayerChangeDirection(string direction);

    public event PlayerChangeDirection OnChangedDirection;

    private void addUpwardsForce()
    {
        rigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    void Update()
    {
        if (canMove)
        {
            // create a new vector 3 for the movement from controller / keyboard
            // get the move direction
            Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
            Vector3 moveDirection = transform.TransformDirection(move);

            // assign move direciton to the velocity
            rigidBody.velocity = new Vector3(moveDirection.x * playerSpeed, rigidBody.velocity.y, 0);

            // if the player can jump add for in the y direction
            if (jumped && IsGrounded() && numJumps > 0)
            {
                numJumps -= 1;
                Invoke("addUpwardsForce", 0.4f);
            }

            // reset the number of jumps
            if (IsGrounded())
            {
                numJumps = 1;
                jumped = false;

                if (OnGrounded != null)
                {
                    OnGrounded(true);
                }
            }

            if (!IsGrounded())
            {
                if (OnGrounded != null)
                {
                    OnGrounded(false);
                }
            }

            // Rotate only the visual part by 180 degrees around the Y-axis
            if (movementInput.x < 0)
            {
                transform.GetChild(0).rotation = Quaternion.Euler(0, -90, 0);

                if (OnChangedDirection != null)
                {
                    OnChangedDirection("left");
                }
            }
            else if (movementInput.x > 0)
            {
                transform.GetChild(0).rotation = Quaternion.Euler(0, 90, 0);

                if (OnChangedDirection != null)
                {
                    OnChangedDirection("right");
                }
            }
        }
    }

}

