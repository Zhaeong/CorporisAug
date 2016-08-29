using UnityEngine;
using System.Collections;

public class CrosshairController : MonoBehaviour {

    public Texture2D crosshairImage;

    ItemFinder IF;

    // Use this for initialization
    void Start () {
        IF = gameObject.GetComponent<ItemFinder>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);

        GUI.Label(new Rect(10, 10, 100, 20), IF.sObject);
    }
}
