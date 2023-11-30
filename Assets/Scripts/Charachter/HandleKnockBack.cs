using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharachterMovement))]
[RequireComponent(typeof(Rigidbody))]
public class HandleKnockBack : MonoBehaviour
{
    // create variable for the charachter movement script / rigid body
    private CharachterMovement charachterMovement;
    private Rigidbody playerRigidBody;

    // vairables for the knock back
    private int StartingKnockBack = 1;
    private ForceMode forceMode = ForceMode.Impulse;
    public int KnockBackMultiplier = 1;

    // get the rigid body and the charachter movement script
    private void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        charachterMovement = gameObject.GetComponent<CharachterMovement>();
    }

    // add 5 to the knock back value
    public void incrementKnockBack()
    {
        KnockBackMultiplier += 5;
    }

    // reset the knock back to the starting knock back value
    public void resetKnockBack()
    {
        KnockBackMultiplier = StartingKnockBack;
    }

    // enable / disable player controls
    private void enablePlayerControls()
    {
        charachterMovement.canMove = true;
    }

    private void disablePlayerControls()
    {
        charachterMovement.canMove = false;
    }

    // add knock back to the player and disable their controls then enable them
    public void addKnockBack(Vector3 knockbackDirection)
    {
        incrementKnockBack();
        disablePlayerControls();
        playerRigidBody.AddForce(knockbackDirection * KnockBackMultiplier, forceMode);
        Invoke("enablePlayerControls", 2.0f);
    }

}
