using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// This code can be integrated into a broader GameManager class at a later stage.

public class ColourManager : MonoBehaviour
{
    // temporary variables to allow simulation of colour filters in prototype
    public GameObject redLight;
    public GameObject greenLight;
    public GameObject blueLight;

    public bool lampOn=false;
    
    public Colouration.Colours sceneColour = Colouration.Colours.W;

    List<GameObject> colouredObjects;

    // If the torch is on, the colour is the current wheel colour, otherwise it's the scene colour.
    public Colouration.Colours GetCurrentColour() { return lampOn ? colourWheel[currentColourIndex] : sceneColour; }
    // ChangeColour for what the colour should now be
    void ApplyCurrentColour () { ChangeColour (GetCurrentColour()); }

    public Colouration.Colours[] colourWheel;
    public int currentColourIndex=0;

    // Start is called before the first frame update
    void Start()
    {
        // FindGameObjectsWithTag seems only to find active GameObjects
        // so this cannot be done in Start *before* deactivating objects 
        colouredObjects = GameObject.FindGameObjectsWithTag("coloured").ToList();

        colourWheel = new Colouration.Colours[3];
        colourWheel[0] = Colouration.Colours.R;
        colourWheel[1] = Colouration.Colours.G;
        colourWheel[2] = Colouration.Colours.B;

        // Now deactivate all objects that should not be seen at the start of the game.
        ApplyCurrentColour();
    }

    // Update is called once per frame
    // Delete this code once the controls have been added to controller.
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.R)) ChangeColour (Colouration.Colours.R);
        else if (Input.GetKeyDown(KeyCode.G)) ChangeColour (Colouration.Colours.G);
        else if (Input.GetKeyDown(KeyCode.B)) ChangeColour (Colouration.Colours.B);*/
        if (Input.GetKeyDown(KeyCode.R)) AddLens (Colouration.Colours.R);
        else if (Input.GetKeyDown(KeyCode.G)) AddLens (Colouration.Colours.G);
        else if (Input.GetKeyDown(KeyCode.B)) AddLens (Colouration.Colours.B);
        else if (Input.GetKeyDown(KeyCode.Delete)) RemoveLenses ();

        if (Input.GetKeyDown(KeyCode.Q)) CycleColourWheelAntiClockwise();
        if (Input.GetKeyDown(KeyCode.E)) CycleColourWheelClockwise();
        if (Input.GetKeyDown(KeyCode.Z)) TorchToggle();
        
    }
    public void ChangeColour (Colouration.Colours colour) {
        // TODO: Call ChangeObjectColour(itemheld[if not null])

        // Activate/deactivate colourised GameObject instances
        foreach (var g in colouredObjects) {
            g.GetComponent<Colouration>().ReactToLight(colour);
        }
        // Change scene lighting -- stub code using GameObjects (UI panels pretending to be filters)
        redLight.SetActive(colour==Colouration.Colours.R);
        greenLight.SetActive(colour==Colouration.Colours.G);
        blueLight.SetActive(colour==Colouration.Colours.B);
        
    }
    // Direction should be -1 or 1
    void CycleColourWheel(int direction) {
        //currentColourIndex += direction;
        //currentColourIndex %= colourWheel.Length;
        currentColourIndex = (currentColourIndex + direction) % colourWheel.Length;
        if (currentColourIndex < 0) currentColourIndex += colourWheel.Length;
        print(currentColourIndex);
        ApplyCurrentColour();
        // Add sound effect for wheel turning
        // Animate UI colourwheel
    }
    public void CycleColourWheelClockwise() {CycleColourWheel(-1);}
    public void CycleColourWheelAntiClockwise() {CycleColourWheel(1);}
    

    public void RemoveLenses () {
        for (int i=0; i<colourWheel.Length; i++) colourWheel[i] = Colouration.Colours.W;
        ApplyCurrentColour();
    }
    public void AddLens (Colouration.Colours colour) {
        int insertionIndex=0;
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
        ApplyCurrentColour(); // In case the lens is added to the currently active slot.
    }
    public void TorchOn () {
        lampOn=true;
        // Animate raising torch
        ApplyCurrentColour();
    }
    public void TorchOff () {
        lampOn = false;
        // Animate lowering torch
        ApplyCurrentColour();
    }
    public void TorchToggle () {
        if (lampOn) TorchOff();
        else TorchOn();
    }
    public void ChangeObjectColour (Colouration col) {
        col.SetColour(GetCurrentColour());
    }
}
