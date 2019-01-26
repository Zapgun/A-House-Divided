using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public ColourManager colourManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cycle") && colourManager.lampOn) colourManager.CycleColourWheelClockwise();

        if(Input.GetButtonDown("Toggle")) colourManager.TorchToggle();

    }

    void raiseTorch(){
            // to be filled in with some animation/light triggers
    }

    void lowerTorch(){
        // to be filled in later with some animation/light triggers (reverse of raiseTorch)
    }
}
