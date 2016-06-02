using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public GameObject textBox;
    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerController player;

    public bool isActive;

	// Use this for initialization
	void Start () {

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }


        player = FindObjectOfType<PlayerController>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
	
	}

    // Update is called once per frame
    void Update()
    {

        if (!isActive)
        {
            DisableTextBox();
            return;
        }
        else
        {
            EnableTextBox();

            theText.text = textLines[currentLine];
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentLine += 1;
            }

            if (currentLine > endAtLine)
            {
                DisableTextBox();
            }
        }
	
	}

    public void EnableTextBox()
    {
        textBox.SetActive(true);
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
    }

    public void LoadText(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = theText.text.Split('\n');
            currentLine = 0;
            isActive = true;
        }
    }

}
