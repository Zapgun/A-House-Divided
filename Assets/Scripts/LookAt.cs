﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Camera cam; 	            // The main game camera

    public GameObject player;

    public GameObject heldObj = null;
    public GameObject heldObjPos; // this is where the held object will be placed

    private bool pickupHeld;


    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the "pickup" layer (9) to get a bit mask
        int layerMask = 1 << 9;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Input.GetButtonDown("Activate") && heldObj != null)
        {
            print("dropped");
            heldObj.transform.parent = null;
        }


        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            print("I'm looking at " + hit.transform.name);

            

            if (Input.GetButtonDown("Activate") && heldObj == null){
                //if(hit.transform.gameObject.CompareTag("Red")){
                    // if heldObj == null and hit object is tagged 'pickupable' do stuff
                    heldObj = hit.transform.gameObject;
                    heldObj.transform.parent = this.transform.parent.transform;
                    heldObj.transform.localPosition = heldObjPos.transform.localPosition;
                    //heldObj.transform.gameObject.SetActive(false);


                    //pickupHeld = true;
                //}
            }
           


            if (Input.GetButtonDown("Cancel")){
                
            }
        }
        else
        {
            print("I'm looking at nothing!");
        }
    }
}
