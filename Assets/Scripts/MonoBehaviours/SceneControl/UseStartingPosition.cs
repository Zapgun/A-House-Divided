using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseStartingPosition : MonoBehaviour
{

    private SceneController sceneController;    // Reference to the SceneController so that this can subscribe to events that happen before and after scene loads.

    // The key used to retrieve the starting position from the playerSaveData
    public const string startingPositionKey = "starting position";

    public SaveData playerSaveData;             // Reference to the save data asset containing the player's starting position.

    private void Awake()
    {
        // Find the SceneController and store a reference to it.
        sceneController = FindObjectOfType<SceneController>();

        // If the SceneController couldn't be found throw an exception so it can be added.
        if(!sceneController)
            throw new UnityException("Scene Controller could not be found, ensure that it exists in the Persistent scene.");
    }

   private void OnEnable()
    {
        // Subscribe the Load function to the AfterSceneLoad event.
        sceneController.AfterSceneLoad += Load;
    }


    private void OnDisable()
    {
        // Unsubscribe the Load function from the AfterSceneLoad event.
        sceneController.AfterSceneLoad -= Load;
    }


    // This function will be called just after a scene is finished loading.
    // It must call saveData.Load with a ref parameter to get the data out.
    protected void Load () {
        // Load the starting position from the save data and find the transform from the starting position's name.
        string startingPositionName = "00StartPosition";
        playerSaveData.Load(startingPositionKey, ref startingPositionName);
        Transform startingPosition = StartingPosition.FindStartingPosition(startingPositionName);

        if (startingPosition) {
            // Set the player's position and rotation based on the starting position.
            transform.position = startingPosition.position;
            transform.rotation = startingPosition.rotation;

            Debug.Log(startingPosition.position);
        }
    }
}
