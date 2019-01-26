using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseStartingPosition : MonoBehaviour
{

    // The key used to retrieve the starting position from the playerSaveData
    public const string startingPositionKey = "starting position";

    public SaveData playerSaveData;             // Reference to the save data asset containing the player's starting position.

    // Start is called before the first frame update
    void Start()
    {
    
        // Load the starting position from the save data and find the transform from the starting position's name.
        string startingPositionName = "";
        playerSaveData.Load(startingPositionKey, ref startingPositionName);
        Transform startingPosition = StartingPosition.FindStartingPosition(startingPositionName);

        if (startingPosition) {
            // Set the player's position and rotation based on the starting position.
            transform.position = startingPosition.position;
            transform.rotation = startingPosition.rotation;

            Debug.Log(startingPosition.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
