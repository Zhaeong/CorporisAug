using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIController: MonoBehaviour {

    public Texture InventoryImg;
    public Texture CharTemplate;
    public Texture2D crosshairImage;    
    public List<GameObject> GameObjectList;
    public bool ShowPickup;
    public int row = 4;
    public int col = 5;

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

        if(InventoryOn)
        {
            int[] xDim = new int[row*col];
            int[] yDim = new int[row * col];

            float xInv = (Screen.width / 2) - (InventoryImg.width / 2) + 200;
            float yInv = (Screen.height / 2) - (InventoryImg.height / 2);
            //Debug.Log("Width: " + InventoryImg.width + "Height:" + InventoryImg.height);

            //ItemStorage
            GUI.Box(new Rect(xInv, yInv, InventoryImg.width, InventoryImg.height), InventoryImg);

            //DraggingStuff
            GUI.Box(new Rect(xInv - 400, yInv, CharTemplate.width, CharTemplate.height), CharTemplate);

            int x_box = (int)xInv + 10;
            int y_box = (int)yInv + 10;

            for (int i = 0; i < row*col; i++)
            {
                GUI.Box(new Rect(x_box, y_box, 50, 50), "");
                xDim[i] = x_box;
                yDim[i] = y_box;
                if (x_box < (int)xInv + 250)
                {
                    x_box += 60;
                }
                else
                {
                    y_box += 60;
                    x_box = (int)xInv + 10;
                }
            }



            foreach (GameObject ga in GameObjectList)
            {
                SpriteRenderer ObjSR = ga.GetComponent<SpriteRenderer>();
                Sprite GameObjSprite = ObjSR.sprite;

                GUI.Button(new Rect(xDim[0], yDim[0], 50, 50), GameObjSprite.texture);
                
            }

            for(int j = 0; j < GameObjectList.Count; j++)
            {
                GameObject GamObj = GameObjectList[j];

                SpriteRenderer ObjSR = GamObj.GetComponent<SpriteRenderer>();
                Sprite GameObjSprite = ObjSR.sprite;

                GUI.Button(new Rect(xDim[j], yDim[j], 50, 50), GameObjSprite.texture);

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
