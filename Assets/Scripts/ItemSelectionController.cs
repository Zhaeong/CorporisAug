using UnityEngine;
using System.Collections;

public class ItemSelectionController : MonoBehaviour {

    public GameObject[] itemlist; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        itemlist = GameObject.FindGameObjectsWithTag("Limb");
	
	}
}
