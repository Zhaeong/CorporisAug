using UnityEngine;
using System.Collections;

public class BillboardBehaviour : MonoBehaviour {

    GameObject MainCam;
    // Use this for initialization
    void Start () {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera");

    }
	
	// Update is called once per frame
	void Update () {
        //Should use look at because multiple objects would be weird, will be at angles to camera
        //transform.LookAt(Camera.main.transform.position, -Vector3.up);
        

    }

    void LateUpdate()
    {
        transform.forward = MainCam.transform.forward;
    }
}
