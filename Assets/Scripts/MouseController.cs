﻿using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

    public bool isTouchingAnother;
    public GameObject objTouched;
    public GameObject objToDrag;
    private Vector3 screenPoint, offset;
    private bool MouseDragging;
    private Color objColor;

    // Use this for initialization
    void Start () {
        isTouchingAnother = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                MouseDragging = true;
                //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                objToDrag = hitInfo.transform.gameObject;
                objColor = objToDrag.GetComponent<Renderer>().material.color;
                HighlightObj(objToDrag, Color.yellow);


                if (hitInfo.transform.gameObject.tag == "Construction")
                {
                    Debug.Log("It's working!");
                }
                
            }
            else {
                Debug.Log("No hit");
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            HighlightObj(objToDrag, objColor);
            
            MouseDragging = false;
        }

        
    }

    void FixedUpdate()
    {

        if (objToDrag != null)
        {
            if (MouseDragging)
            {
                screenPoint = Camera.main.WorldToScreenPoint(objToDrag.transform.position);
                float distance_to_screen = Camera.main.WorldToScreenPoint(objToDrag.transform.position).z;
                objToDrag.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            }
            
            
        }

    }


    void OnGUI()
    {
        if (isTouchingAnother)
        {
            //The commented out code displays a button, kinda clunky and not necessary
            if (GUI.Button(new Rect(10, 10, 150, 100), "Connect"))
            {
                ObjCollisionController ObjCC = objToDrag.GetComponent<ObjCollisionController>();
                objToDrag.transform.parent = ObjCC.touchedObj.transform;
            }
            
        }

    }

    void HighlightObj(GameObject obj, Color col)
    {
        obj.GetComponent<Renderer>().material.color = col;
        Transform[] listOfChilds = obj.GetComponentsInChildren<Transform>();
        foreach (Transform child in listOfChilds)
        {
            child.GetComponent<Renderer>().material.color = col;
        }
    }
}
