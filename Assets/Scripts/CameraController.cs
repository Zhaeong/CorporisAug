using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject cameraAnchor;
    public float rotationSpeed;

    private Vector3 vAnchorPos, startingPos;

    // Use this for initialization
    void Start () {
        vAnchorPos = cameraAnchor.transform.position;
        startingPos = new Vector3(vAnchorPos.x, vAnchorPos.y, vAnchorPos .z - 6);
        transform.position = startingPos;




    }
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawLine(transform.position, cameraAnchor.transform.position, new Color(0, 0, 0));
        //transform.LookAt(cameraAnchor.transform);
        

    }

    void OnGUI()
    {

        if (GUI.RepeatButton(new Rect(Screen.width - 50, Screen.height - 100, 40, 30), "Right"))
        {
            transform.RotateAround(vAnchorPos, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * rotationSpeed);
        }

        if (GUI.RepeatButton(new Rect(Screen.width - 120, Screen.height - 100, 40, 30), "Left"))
        {
            transform.RotateAround(vAnchorPos, new Vector3(0.0f, 1.0f, 0.0f), -20 * Time.deltaTime * rotationSpeed);
        }

        if (GUI.RepeatButton(new Rect(Screen.width - 85, Screen.height - 60, 40, 30), "Down"))
        {
            transform.RotateAround(vAnchorPos, new Vector3(1.0f, 0.0f, 0.0f), -20 * Time.deltaTime * rotationSpeed);
        }

        if (GUI.RepeatButton(new Rect(Screen.width - 85, Screen.height - 140, 40, 30), "Up"))
        {
            transform.RotateAround(vAnchorPos, new Vector3(1.0f, 0.0f, 0.0f), 20 * Time.deltaTime * rotationSpeed);
        }

        if (GUI.RepeatButton(new Rect(Screen.width - 75, Screen.height - 95, 20, 20), "[]"))
        {
            
            transform.position = startingPos;
            transform.LookAt(cameraAnchor.transform);
        }





    }
}
