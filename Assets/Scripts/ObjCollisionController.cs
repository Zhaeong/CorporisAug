using UnityEngine;
using System.Collections;

public class ObjCollisionController : MonoBehaviour {

	// Use this for initialization
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
        MouseControllerScript.objTouched = other.gameObject;
        //Debug.Log("Collldlfdlff");
    }
}
