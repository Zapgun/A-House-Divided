using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Camera cam; 	            // The main game camera

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the "pickup" layer (8) to get a bit mask
        int layerMask = 1 << 9;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if(Input.GetButtonDown("Pick Up")){
                
            }

            print("I'm looking at " + hit.transform.name);
        }
        else
        {
            print("I'm looking at nothing!");
        }
    }
}
