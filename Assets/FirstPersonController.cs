using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

    CharacterController CC;
	// Use this for initialization
	void Start () {
        CC = gameObject.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 vMovement = new Vector3(x, 0, z);
        CC.Move(vMovement);
    }
}
