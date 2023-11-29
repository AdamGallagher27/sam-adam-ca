using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// [RequireComponent(typeof(CharachterMovement))]

public class CharachterAnimationController : MonoBehaviour
{

    private Animator animator;
    public GameObject currentPlayer;
    private bool isGrounded;
    private CharachterMovement charachterMovement;

    private void setIsGrounded(bool grounded)
    {
        isGrounded = grounded;
        Debug.Log( "grounded : " + grounded);
    }

    private void listenIsPlayerGrounded()
    {
        charachterMovement.OnGrounded += setIsGrounded;
    }



    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        charachterMovement = currentPlayer.GetComponent<CharachterMovement>();
        listenIsPlayerGrounded();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null)
        {

            if(Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed)
            {
                animator.SetBool("isRunning", true);
            }

            // if(Keyboard.current.aKey.wasReleasedThisFrame || Keyboard.current.dKey.wasReleasedThisFrame)
            // {
            //     animator.SetBool("isRunning", false);
            // }

            // if(Keyboard.current.spaceKey.wasPressedThisFrame)
            // {
            //     animator.SetBool("isJumping", true);
            // }


            //     animator.SetBool("isFalling", true);
            //     animator.SetBool("isJumping", false);

            //     if(isGrounded){
            //         animator.SetBool("isGrounded", true);
            //     }

        }

        if (Gamepad.current != null)
        {
           
        }
    }
}
