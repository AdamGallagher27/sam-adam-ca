using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsOnTop : MonoBehaviour
{

    // create an event for when the player is on top of the hill
    public delegate void PlayerOnHill(string playerName);

    public event PlayerOnHill OnTopOfHill;

    // when the player stands on top of the hill send out the
    // event
    void OnTriggerStay(Collider collider)
    {
        string playerName = collider.gameObject.name;

        if (OnTopOfHill != null)
        {
            OnTopOfHill(playerName);
        }
    }
}
