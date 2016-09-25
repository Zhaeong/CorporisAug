using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BillboardBehaviour))]
public class ModularBody : MonoBehaviour {

    public BodyTemplate Template;
    public Sprite[] Sprites;

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < Sprites.Length && i < Template.BodyParts.Length; ++i)
        {
            GameObject obj = new GameObject();
            obj.transform.SetParent(transform);
            var renderer = obj.AddComponent<SpriteRenderer>();
            renderer.sprite = Sprites[i];
            obj.transform.localPosition = Template.BodyParts[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
