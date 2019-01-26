using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code can be integrated into a broader GameManager class at a later stage.

public class ColourManager : MonoBehaviour
{
    // temporary variables to allow simulation of colour filters in prototype
    public GameObject redLight;
    public GameObject greenLight;
    public GameObject blueLight;
    
    public Colouration.Colours sceneColour = Colouration.Colours.WHITE;

    GameObject [] colouredObjects;
    // Start is called before the first frame update
    void Start()
    {
        // FindGameObjectsWithTag seems only to find active GameObjects
        // so this cannot be done in Start *before* deactivating objects 
        colouredObjects = GameObject.FindGameObjectsWithTag("coloured");

        // Now deactivate all objects that should not be seen at the start of the game.
        ChangeColour (sceneColour);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) ChangeColour (Colouration.Colours.RED);
        else if (Input.GetKeyDown(KeyCode.G)) ChangeColour (Colouration.Colours.GREEN);
        else if (Input.GetKeyDown(KeyCode.B)) ChangeColour (Colouration.Colours.BLUE);
    }
    public void ChangeColour (Colouration.Colours colour) {
        // Activate/deactivate colourised GameObject instances
        foreach (var g in colouredObjects) {
            g.GetComponent<Colouration>().ReactToLight(colour);
        }
        // Change scene lighting -- stub code using GameObjects (UI panels pretending to be filters)
        redLight.SetActive((colour & Colouration.Colours.RED)==Colouration.Colours.RED);
        greenLight.SetActive((colour & Colouration.Colours.GREEN)==Colouration.Colours.GREEN);
        blueLight.SetActive((colour & Colouration.Colours.BLUE)==Colouration.Colours.BLUE);
        
    }
}
