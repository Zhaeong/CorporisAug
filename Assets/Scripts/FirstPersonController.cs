using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
    public Camera mainCamera;
    public float MovementSpeed = 10.0f;
    public float Gravity = 20.0f;
    public float JumpHeight = 5.0f;
    public float JumpSpeed = 10.0f;

    public float HorizRotationSpeed, VerticalRotationSpeed;
    private float yaw, pitch;

    private float curHeight, tarHeight;

    private bool isJumping;
    CharacterController CC;


	// Use this for initialization
	void Start () {
        CC = gameObject.GetComponent<CharacterController>();
        yaw = 0.0f;
        pitch = 0.0f;
        isJumping = false;
    }
	
	// Update is called once per frame
	void Update () {

        curHeight = transform.position.y;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        yaw += HorizRotationSpeed * Input.GetAxis("Mouse X");
        pitch -= VerticalRotationSpeed * Input.GetAxis("Mouse Y");

        mainCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        Vector3 MoveDirectionForward;
        Vector3 Movement = Vector3.zero;


        MoveDirectionForward = mainCamera.transform.forward;
        MoveDirectionForward = new Vector3(MoveDirectionForward.x, 0, MoveDirectionForward.z);

        Vector3 MoveRight = Vector3.Cross(MoveDirectionForward, Vector3.up);
        Vector3 MoveLeft = -MoveRight;


            if (z != 0.0f)
            {
                CC.Move(z * MoveDirectionForward * MovementSpeed * Time.deltaTime);
            }
            if (x != 0.0f)
            {
                CC.Move(x * MoveLeft * MovementSpeed * Time.deltaTime);
            }

            if (Input.GetButton("Jump") && CC.isGrounded)
            {

                    tarHeight = curHeight + JumpHeight;
                    isJumping = true;
                
            }




        if (isJumping)
        {
            if (curHeight >= tarHeight)
            {
                isJumping = false;
            }
            else
            {
                CC.Move(Vector3.up * Time.deltaTime * JumpSpeed);
            }
        }

        if (!isJumping)
        {
            CC.Move(Vector3.down * Time.deltaTime * Gravity);
        }



    }
}
