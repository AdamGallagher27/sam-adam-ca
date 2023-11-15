using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfBounds : MonoBehaviour
{

    // locatoin to respawn the player after falling of arena
    public Vector3 spawnPoint;

    // https://gamedevbeginner.com/events-and-delegates-in-unity/
    // create a delegate with playername as param
    public delegate void PlayerResetAfterPoint(string playerName);
    
    // Create an event with delegate ttype when the player position is reset
    public event PlayerResetAfterPoint OnResetPosition;

    // called when player falls off arena
    private void OnTriggerExit(Collider player)
    {
        string playerName = player.name;

        if(playerName == "Player1" ^ playerName == "Player2")
        {   
            // reset the players position
            // player.gameObject.transform.position = spawnPoint;
            player.GetComponent<Rigidbody>().position = spawnPoint;

            // reset the players knock back variable
            HandleKnockBack knockBackController = player.GetComponent<HandleKnockBack>();
            knockBackController.resetKnockBack();

            // send out the event
            if(OnResetPosition != null)
            {
                OnResetPosition(playerName);
            }
        }

    }
}
