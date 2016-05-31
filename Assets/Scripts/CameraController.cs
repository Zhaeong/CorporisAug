using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Camera gameCamera;


    // Use this for initialization
    void Start () {
        Vector3 startingPos = new Vector3(transform.position.x, transform.position.y, -2);

        gameCamera.transform.position = startingPos;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 startingPos = new Vector3(transform.position.x, transform.position.y, -2);

        gameCamera.transform.position = startingPos;

    }
}
