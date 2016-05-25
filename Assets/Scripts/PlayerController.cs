using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Animator Anim;
    private bool isfacingleft, wasfacingleft;
    string currentDirection, previousDirection;
	// Use this for initialization
	void Start () {
        isfacingleft = true;
        wasfacingleft = true;
        Anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");
        bool isWalking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;


        Anim.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            Anim.SetFloat("x", input_x);
            Anim.SetFloat("y", input_y);
            transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime;
        }
    }

    void flip()
    {
        foreach (Transform child in transform)
        {
            Vector3 theScale = child.transform.localScale;
            theScale.x *= -1;
            child.transform.localScale = theScale;
        }
    }
}
