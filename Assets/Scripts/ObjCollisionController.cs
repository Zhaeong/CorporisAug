using UnityEngine;
using System.Collections;

public class ObjCollisionController : MonoBehaviour {

    // Use this for initialization
    public GameObject touchedObj;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        GameObject MouseControls = GameObject.Find("MouseControllerObj");
        MouseController MouseControllerScript = MouseControls.GetComponent<MouseController>();
        MouseControllerScript.isTouchingAnother = true;
        touchedObj = other.gameObject;
        MouseControllerScript.objTouched = other.gameObject;
        //Debug.Log("Collldlfdlff");
    }
}
