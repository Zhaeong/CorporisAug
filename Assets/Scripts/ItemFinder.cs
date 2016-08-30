using UnityEngine;
using System.Collections;

public class ItemFinder : MonoBehaviour {

    public float DistanceToFind = 3;
    public string sObject;
    GameObject MainCam;
    RaycastHit hitInfo;

    UIController UIC;
    // Use this for initialization
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera");
        UIC = gameObject.GetComponent<UIController>();

    }
	
	// Update is called once per frame
	void Update () {
        Ray rayTosend = new Ray(MainCam.transform.position, MainCam.transform.forward);
        Debug.DrawRay(MainCam.transform.position, MainCam.transform.forward * DistanceToFind, Color.red);

        if(Physics.Raycast(rayTosend, out hitInfo, DistanceToFind))
        {
            GameObject HitObj = hitInfo.transform.gameObject;
            sObject = HitObj.name;
            if(HitObj.tag == "Limb")
            {
                UIC.ShowPickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    UIC.GameObjectList.Add(HitObj);
                    HitObj.SetActive(false);
                }
            }
            else
            {
                UIC.ShowPickup = false;
            }
        }
        else
        {
            sObject = null;
            UIC.ShowPickup = false;
        }

    }


}
