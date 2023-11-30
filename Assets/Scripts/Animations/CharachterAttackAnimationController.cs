using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharachterAttackAnimationController : MonoBehaviour
{

    private Animator animator;
    public GameObject currentPlayer;
    public bool blocking = false;

    private void endPunch()
    {
        animator.SetBool("punch1", false);
    }

    private void endKick()
    {
        animator.SetBool("kick1", false);
    }

    private void endBlock()
    {
        animator.SetBool("block1", false);
        blocking = false;
    }


    private void punch()
    {
        animator.SetBool("punch1", true);
        Invoke("endPunch", 0.8f);
    }

    private void kick()
    {
        animator.SetBool("kick1", true);
        Invoke("endKick", 0.8f);
    }

    private void block()
    {
        blocking = true;
        animator.SetBool("block1", true);
        Invoke("endBlock", 0.8f);
    }

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null && Gamepad.current.buttonWest.wasPressedThisFrame && currentPlayer.name == "Player2")
        {
            punch();
        }

        if (Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame && currentPlayer.name == "Player2")
        {
            kick();
        }

        if (Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame && currentPlayer.name == "Player2")
        {
            block();
        }


        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame && currentPlayer.name == "Player1")
        {
            punch();
        }

        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame && currentPlayer.name == "Player1")
        {
            kick();
        }

        if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame && currentPlayer.name == "Player1")
        {
            block();
        }
    }
}
