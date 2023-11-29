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

    private void setDirection(string dir)
    {
        Debug.Log(dir);
        direciton = dir;
    }

    private void listenDirectionChange()
    {
        CharachterMovement charachterMovement = gameObject.GetComponent<CharachterMovement>();
        charachterMovement.OnChangedDirection += setDirection;
    }

    void Start()
    {
        currentPlayer = gameObject.name;
        listenDirectionChange();
    }


    void Update()
    {
        // Check for the E key on the keyboard
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame && currentPlayer == "Player1")
        {
            SpawnAndDestroyObject();
            // Debug.Log("E");
        }

        // Check for the X button on the controller
        if (Gamepad.current != null && Gamepad.current.xButton.wasPressedThisFrame && currentPlayer == "Player2")
        {
            SpawnAndDestroyObject();
            // Debug.Log("X");
        }
    }

    void SpawnAndDestroyObject()
    {
        Vector3 spawnDirection;

        if(direciton == "left")
        {
            // there is no transfrom left
            // left = -transform.right
            spawnDirection = -transform.right * spawnDistance;
            
        }
        else if(direciton == "right")
        {
            spawnDirection = transform.right * spawnDistance;
        }
        else
        {
            spawnDirection = Vector3.zero;
        }

        // Calculate the position in front of the character
        Vector3 spawnPosition = transform.position + spawnDirection;

        // Instantiate the temporary object
        GameObject temporaryObject = Instantiate(temporaryObjectPrefab, spawnPosition, Quaternion.identity);

        // Schedule the object for destruction after the display time
        Destroy(temporaryObject, displayTime);
    }
}
