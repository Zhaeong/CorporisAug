using UnityEngine;
using System.Collections;

public class ItemFinder : MonoBehaviour {

    public float DistanceToFind = 3;
    public string sObject;
    GameObject MainCam;
    RaycastHit hitInfo;
    // Use this for initialization
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera");

    }
	
	// Update is called once per frame
	void Update () {
        Ray rayTosend = new Ray(MainCam.transform.position, MainCam.transform.forward);
        Debug.DrawRay(MainCam.transform.position, MainCam.transform.forward * DistanceToFind, Color.red);

        //RaycastHit hitInfo;

        if(Physics.Raycast(rayTosend, out hitInfo, DistanceToFind))
        {
            Debug.Log(hitInfo.transform.gameObject.name);
            sObject = hitInfo.transform.gameObject.name;
        }
        else
        {
            sObject = null;
        }

    }


}
