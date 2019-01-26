using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colouration : MonoBehaviour
{
    // Bitwise AND of colours: true indicates some shared component
    public enum Colours {
        RED = 4,
        GREEN = 2,
        BLUE = 1,

        YELLOW = 6,  // RED  + GREEN
        MAGENTA = 5, // RED  + BLUE
        CYAN = 3,    // BLUE + GREEN 

        WHITE = 7    // RED + GREEN + BLUE 
    }

    public Colours objectColour;

    // Start is called before the first frame update
    void Start()
    {
        // Check starting colour on spawn
        // OR 
        // Have GameController call ChangeColour in its first frame
    }

    public void ReactToLight (Colours newColor){
        // keep open possibility of bichromatic puzzles
        if ((newColor & this.objectColour)!=0) { gameObject.SetActive(true); }
        else { gameObject.SetActive(false); }
    }

    // Update is called once per frame
/*     void Update()
    {
        
    }*/
}
