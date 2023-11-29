using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharachterAnimationController : MonoBehaviour
{

    private Animator animator;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
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

            if(Keyboard.current.aKey.wasReleasedThisFrame || Keyboard.current.dKey.wasReleasedThisFrame)
            {
                animator.SetBool("isRunning", false);
            }

            if(Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", true);
            }

            // if(Keyboard.current.spaceKey.wasReleasedThisFrame)
            // {
            //     animator.SetBool("isJumping", false);
            // }

        }

        // // Check for the E key on the keyboard
        // if (Keyboard.current != null && Keyboard.current.dKey.wasPressedThisFrame && currentPlayer == "Player1")
        // {
        //    Debug.Log("d");
        // }
    }
}
