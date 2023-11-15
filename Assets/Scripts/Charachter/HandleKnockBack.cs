using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharachterMovement))]
[RequireComponent(typeof(Rigidbody))]
public class HandleKnockBack : MonoBehaviour
{
    private CharachterMovement charachterMovement;
    private Rigidbody playerRigidBody;
    private int StartingKnockBack = 1;
    public int KnockBackMultiplier = 1;
    private ForceMode forceMode = ForceMode.Impulse;

    private void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        charachterMovement = gameObject.GetComponent<CharachterMovement>();
    }

    public void incrementKnockBack()
    {
        KnockBackMultiplier += 5;
    }

    public void resetKnockBack()
    {
        KnockBackMultiplier = StartingKnockBack;
    }

    private void enablePlayerControls()
    {
        charachterMovement.canMove = true;
    }

    private void disablePlayerControls()
    {
        charachterMovement.canMove = false;
    }

    public void addKnockBack(Vector3 knockbackDirection)
    {
        incrementKnockBack();
        disablePlayerControls();
        playerRigidBody.AddForce(knockbackDirection * KnockBackMultiplier, forceMode);
        Invoke("enablePlayerControls", 2.0f);
    }

}
