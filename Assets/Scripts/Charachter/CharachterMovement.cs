using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CharachterMovement : MonoBehaviour
{

    private Rigidbody rigidBody;
    public float playerSpeed;
    public float jumpForce;
    private bool jumped = false;
    public bool canMove = true;
    private Vector2 movementInput = Vector2.zero;
    public LayerMask groundLayerMask;
    private float groundCheckDistance = 1.9f;
    private int numJumps = 1;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    private bool IsGrounded()
    {
        // Debug.Log(Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayerMask));
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayerMask);
    }


    void Update()
    {
        // Debug.DrawRay(transform.position, -transform.up * 2f, Color.red);

        if (canMove)
        {
            Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
            Vector3 moveDirection = transform.TransformDirection(move);

            rigidBody.velocity = new Vector3(moveDirection.x * playerSpeed, rigidBody.velocity.y, 0);

            if (jumped && IsGrounded() && numJumps > 0)
            {
                numJumps -= 1;
                Debug.Log(Vector3.up * jumpForce);
                rigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }

            if(IsGrounded())
            {
                numJumps = 1;
            }
        }
    }

}

