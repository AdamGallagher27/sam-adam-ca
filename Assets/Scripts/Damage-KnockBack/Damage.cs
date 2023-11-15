using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player1" ^ collision.gameObject.name == "Player2")
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            // Debug.Log("Collision position: " + collisionPoint);

            // Get the GameObject that collided with it
            GameObject player = collision.gameObject;
            Vector3 playerPosition = player.transform.position;
            // Debug.Log("Collided with: " + player.name + " at: " + playerPosition);

            Vector3 direction = -(collisionPoint - player.transform.position).normalized;
            // Debug.Log("direction from collision: " + direction);

            HandleKnockBack knockBackController = player.GetComponent<HandleKnockBack>();
            knockBackController.addKnockBack(direction);
        }
    }
}
