using UnityEngine;
using System.Collections;

public class DialogController : MonoBehaviour {

    public TextAsset theText;
    public TextController textController;

	// Use this for initialization
	void Start () {
        textController = FindObjectOfType<TextController>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("withing");
        if (other.tag == "Player")
        {
            textController.LoadText(theText);

           
        }
    }
}
