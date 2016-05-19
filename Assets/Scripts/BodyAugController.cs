using UnityEngine;
using System.Collections;

public class BodyAugController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LeftArm")
        {
            
            Debug.Log("Sucesss");
            foreach (Transform child in transform)
            {
                if (child.tag == "PlayerLeftArm")
                {
                    other.transform.parent = child.transform;
                    other.transform.localPosition = new Vector3(-0.1f, -0.15f, 0);
                    child.GetComponent<SpriteRenderer>().enabled = false;
                }
            }

        }
    }
}
