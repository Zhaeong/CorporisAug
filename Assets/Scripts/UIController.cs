using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIController: MonoBehaviour {

    public Texture InventoryImg;
    public Texture2D crosshairImage;    
    public List<GameObject> GameObjectList;
    public bool ShowPickup;

    private ItemFinder IF;
    private bool InventoryOn;

    // Use this for initialization
    void Start () {
        IF = gameObject.GetComponent<ItemFinder>();
        GameObjectList = new List<GameObject>();
        ShowPickup = false;
        InventoryOn = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.I))
        {
            InventoryOn = ToggleBoolean(InventoryOn);
        }

    }

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 2);

        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
        GUI.Label(new Rect(10, 10, 100, 20), IF.sObject);

        GUIStyle GS = new GUIStyle();
        GS.normal.textColor = Color.black;

        if(ShowPickup)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100, 20), "PickUp", GS);
        }

        //for(int i = 0; i < GameObjectList.Count; i++)
        //{
        //    GUI.Button(new Rect(200, 200, 100, 100), );

        //}
        if(InventoryOn)
        {
            float xInv = (Screen.width / 2) - (InventoryImg.width / 2);
            float yInv = (Screen.height / 2) - (InventoryImg.height / 2);
            Debug.Log("Width: " + InventoryImg.width + "Height:" + InventoryImg.height);

            GUI.Box(new Rect(xInv, yInv, InventoryImg.width, InventoryImg.height), InventoryImg);

            foreach (GameObject ga in GameObjectList)
            {
                SpriteRenderer ObjSR = ga.GetComponent<SpriteRenderer>();
                Sprite GameObjSprite = ObjSR.sprite;

                GUI.Button(new Rect(200, 200, 50, 50), GameObjSprite.texture);
                
            }

        }
        
    }

    bool ToggleBoolean(bool theBoolean)
    {
        if (theBoolean)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
