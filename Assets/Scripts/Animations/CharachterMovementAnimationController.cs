using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// [RequireComponent(typeof(CharachterMovement))]

public class CharachterMovementAnimationController : MonoBehaviour
{

    private Animator animator;
    public GameObject currentPlayer;
    private bool isGrounded;

    private bool controllerJumpButton = false;
    private bool keyboardJumpButton = true;

    private CharachterMovement charachterMovement;
    private Rigidbody rigidBody;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        charachterMovement = currentPlayer.GetComponent<CharachterMovement>();
        rigidBody = currentPlayer.GetComponent<Rigidbody>();
    }

    private void cancleJump()
    {
        animator.SetBool("isJumping", false);
    }

    // KEYBOARD ANIMATIONS
    // --------------------------------------------------------------
    private void handleKeyboardMovement()
    {
        if (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void handleKeyboardJump(bool grounded)
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (rigidBody.velocity.y > -0.1f && grounded)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isGrounded", false);

                Invoke("cancleJump", 1.0f);
                keyboardJumpButton = true;
            }
        }

        else if (grounded && rigidBody.velocity.y < -0.5f && keyboardJumpButton)
        {
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJumping", false);
            keyboardJumpButton = false;
        }
    }

    // CONTROLLER ANIMATIONS
    // -------------------------------------------------------------
    private void handleControllerMovement(bool grounded)
    {
        Vector2 leftStickInput = Gamepad.current.leftStick.ReadValue();

        if (leftStickInput.x < -0.1f || leftStickInput.x > 0.1f)
        {
            animator.SetBool("isRunning", true);
        }
        else if (leftStickInput.x == 0 && grounded)
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void handleControllerJump(bool grounded)
    {
        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            if (rigidBody.velocity.y > -0.1f && grounded)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isGrounded", false);

                Invoke("cancleJump", 1.0f);
                controllerJumpButton = true;
            }
        }

        else if (grounded && rigidBody.velocity.y < -0.5f && controllerJumpButton)
        {
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJumping", false);
            controllerJumpButton = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = charachterMovement.IsGrounded();

        if (Keyboard.current != null && currentPlayer.name == "Player1")
        {
            handleKeyboardMovement();
            handleKeyboardJump(isGrounded);
        }

        if (Gamepad.current != null && currentPlayer.name == "Player2")
        {
            handleControllerMovement(isGrounded);
            handleControllerJump(isGrounded);
        }
    }
}
