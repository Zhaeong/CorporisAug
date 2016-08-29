using UnityEngine;
using System.Collections;

public class InventoryController : MonoBehaviour {

    SpriteRenderer SR;
    public bool InventoryOn;
	// Use this for initialization
	void Start () {
        SR = gameObject.GetComponent<SpriteRenderer>();
        SR.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.I))
        {
            if (SR.enabled)
                SR.enabled = false;
            else
                SR.enabled = true;
        }
	    
	}


}
