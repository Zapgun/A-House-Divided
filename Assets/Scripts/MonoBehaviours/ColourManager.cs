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

    public bool lampOn;
    
    public Colouration.Colours sceneColour = Colouration.Colours.W;

    List<GameObject> colouredObjects;

    void ApplyWheelColour () { ChangeColour (colourWheel[currentColourIndex]); }

    public Colouration.Colours[] colourWheel;
    public int currentColourIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        // FindGameObjectsWithTag seems only to find active GameObjects
        // so this cannot be done in Start *before* deactivating objects 
        colouredObjects = GameObject.FindGameObjectsWithTag("coloured");

//        colourWheel = new Colouration.Colours[3];
        colourWheel = [Colouration.Colours.R, Colouration.Colours.G, Colouration.Colours.B]

        // Now deactivate all objects that should not be seen at the start of the game.
        ApplyWheelColour();
    }

    // Update is called once per frame
    // Delete this code once the controls have been added to controller.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) ChangeColour (Colouration.Colours.R);
        else if (Input.GetKeyDown(KeyCode.G)) ChangeColour (Colouration.Colours.G);
        else if (Input.GetKeyDown(KeyCode.B)) ChangeColour (Colouration.Colours.B);
    }
    public void ChangeColour (Colouration.Colours colour) {
        // Activate/deactivate colourised GameObject instances
        foreach (var g in colouredObjects) {
            g.GetComponent<Colouration>().ReactToLight(colour);
        }
        // Change scene lighting -- stub code using GameObjects (UI panels pretending to be filters)
        redLight.SetActive((colour & Colouration.Colours.R)==Colouration.Colours.R);
        greenLight.SetActive((colour & Colouration.Colours.G)==Colouration.Colours.G);
        blueLight.SetActive((colour & Colouration.Colours.B)==Colouration.Colours.B);
        
    }
    // Direction should be -1 or 1
    void CycleColourWheel(int direction) {
        currentColourIndex += direction;
        currentColourIndex %= colourWheel.Length;
        ApplyWheelColour();
        // Add sound effect for wheel turning
        // Animate UI colourwheel
    }
    public void CycleColourWheelClockwise() {CycleColourWheel(-1)};
    public void CycleColourWheelAntiClockwise() {CycleColourWheel(1)};
    

    public void RemoveLenses () {
        colourWheel = [Colouration.Colours.W, Colouration.Colours.W, Colouration.Colours.W];
    }
    public void AddLens (Colouration.Colours colour) {
        int insertionIndex;
        switch (colour) {
        case Colouration.Colours.R :
            insertionIndex = 0;
            break;
        case Colouration.Colours.B :
            insertionIndex = 1;
            break;
        case Colouration.Colours.G :
            insertionIndex = 2;
            break;
        }
        colourWheel[insertionIndex] = colour;
    }
    public void TorchOn () {
        lampOn=true;
        // Animate raising torch
        ApplyWheelColour();
    }
    public void TorchOff () {
        lampOn = false
        // Animate lowering torch
        ChangeColour(sceneColour);
    }
    public void TorchToggle () {
        if (lampOn) TorchOff();
        else TorchOn();
    }
    public Colouration.Colours GetCurrentColour() {
        // If the torch is on, the colour is the current wheel colour, otherwise it's the scene colour.
        return TorchOn ? colourWheel[currentColourIndex] : sceneColour;
    }
    public void ChangeObjectColour (Colourisation col) {
        col.objectColour(GetCurrentColour());
    }
}
