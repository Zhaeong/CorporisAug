using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

    public bool isTouchingAnother;
    public GameObject objTouched;
    private GameObject objToDrag;
    private Vector3 screenPoint, offset;
    private bool MouseDragging;

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
            if (GUI.Button(new Rect(10, 10, 150, 100), "Connect") || Input.GetKeyDown("r") || Input.GetKeyDown("space"))
            {
                objTouched.transform.parent = objToDrag.transform;
            }
            
        }

    }
}
