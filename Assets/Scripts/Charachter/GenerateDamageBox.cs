using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GenerateDamageBox : MonoBehaviour
{
    public GameObject temporaryObjectPrefab; 
    public float spawnDistance = 2f; 
    public float displayTime = 1f;

    private string direciton;
    private string currentPlayer;

    // setter function for dirirection variable
    private void setDirection(string dir)
    {
        // Debug.Log(dir);
        direciton = dir;
    }

    // listen for the direction change event
    private void listenDirectionChange()
    {
        CharachterMovement charachterMovement = gameObject.GetComponent<CharachterMovement>();
        charachterMovement.OnChangedDirection += setDirection;
    }

    // instantiate event listener for direction change
    void Start()
    {
        currentPlayer = gameObject.name;
        listenDirectionChange();
    }

    void Update()
    {
        // Check for the E key on the keyboard
        // if true generate damage box
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame && currentPlayer == "Player1")
        {
            SpawnAndDestroyObject();
            // Debug.Log("E");
        }

        // Check for the X button on the controller
        // if true generate damage box
        if (Gamepad.current != null && Gamepad.current.xButton.wasPressedThisFrame && currentPlayer == "Player2")
        {
            SpawnAndDestroyObject();
            // Debug.Log("X");
        }
    }

    // calculate the location for the damage box to spawn
    private Vector3 calcLocationForDamageBox(string direciton)
    {
        if(direciton == "left")
        {
            // there is no transfrom left
            // left = -transform.right
            return -transform.right * spawnDistance;
        }
        else if(direciton == "right")
        {
            return transform.right * spawnDistance;
        }
        else
        {
            return Vector3.zero;
        }
    }

    // generate damage box infront of the player
    private void SpawnAndDestroyObject()
    {
        Vector3 spawnDirection = calcLocationForDamageBox(direciton);

        // Calculate the position in front of the character
        Vector3 spawnPosition = transform.position + spawnDirection;

        // Instantiate the temporary object
        GameObject temporaryObject = Instantiate(temporaryObjectPrefab, spawnPosition, Quaternion.identity);

        // Schedule the object for destruction after the display time
        Destroy(temporaryObject, displayTime);
    }
}
