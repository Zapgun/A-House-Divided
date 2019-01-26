using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colouration : MonoBehaviour
{
    // ENUM designed for bitwise AND of colours: true indicates some shared component
    public enum Colours {
        W = 8,
        R = 4,
        G = 2,
        B = 1,

        RG = 6,  // RED  + GREEN
        RB = 5, // RED  + BLUE
        GB = 3,    // GREEN + BLUE

        RGB = 7,    // RED + GREEN + BLUE 

        RW = 12,
        GW = 10,
        BW = 9,

        RGW = 14,
        RBW = 13,
        GBW = 11,
        
        RGBW = 15
    }

    public Colours objectColour;

    // Start is called before the first frame update
    void Start()
    {
        // Check starting colour on spawn
        // OR 
        // Have GameController call ChangeColour in its first frame
    }

    public void SetColour (Colours newColor) { objectColour = newColor; }

    public void ReactToLight (Colours newColor){
        // A single object may be visible in multiple light-worlds.
        // It is active iff one of its bits matches the single bit of the colour
        gameObject.SetActive( (newColor & this.objectColour)!=0 );
/* Logic equivalent to:
        if ((newColor & this.objectColour)!=0) { gameObject.SetActive(true); }
        else { gameObject.SetActive(false); }*/
    }

    // Update is called once per frame
/*     void Update()
    {
        
    }*/
}
