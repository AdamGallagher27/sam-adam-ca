using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsOnTop : MonoBehaviour
{

    public delegate void PlayerOnHill(string playerName);

    public event PlayerOnHill OnTopOfHill;

    void OnTriggerStay(Collider collider)
    {
        string PlayerName = collider.gameObject.name;

        if (OnTopOfHill != null)
        {
            OnTopOfHill(PlayerName);
        }
    }
}
