using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfBounds : MonoBehaviour
{

    public Vector3 spawnPoint;

    // https://gamedevbeginner.com/events-and-delegates-in-unity/
    // create a delegate with playername as param
    public delegate void PlayerResetAfterPoint(string playerName);
    
    // Create an event with delegate ttype when the player position is reset
    public event PlayerResetAfterPoint OnResetPosition;

    private void OnTriggerExit(Collider player)
    {
        string playerName = player.name;

        if(playerName == "Player1" ^ playerName == "Player2")
        {   
            // player.gameObject.transform.position = spawnPoint;
            player.GetComponent<Rigidbody>().position = spawnPoint;

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
