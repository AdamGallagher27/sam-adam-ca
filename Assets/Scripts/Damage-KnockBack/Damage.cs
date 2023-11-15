using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // called when player hits the damage collison box
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player1" ^ collision.gameObject.name == "Player2")
        {
            // get the location of the collision
            Vector3 collisionPoint = collision.contacts[0].point;

            // Get the GameObject that collided with it and its position (player)
            GameObject player = collision.gameObject;
            Vector3 playerPosition = player.transform.position;

            // calculate the revearsed direction of the collision and player
            Vector3 direction = -(collisionPoint - player.transform.position).normalized;

            // apply knock back to the player
            HandleKnockBack knockBackController = player.GetComponent<HandleKnockBack>();
            knockBackController.addKnockBack(direction);


            // Debug.Log("Collision position: " + collisionPoint);
            // Debug.Log("Collided with: " + player.name + " at: " + playerPosition);
            // Debug.Log("direction from collision: " + direction);

        }
    }
}
