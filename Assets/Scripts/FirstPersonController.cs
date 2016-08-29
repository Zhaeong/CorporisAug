using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
    public Camera mainCamera;
    public float MovementSpeed = 10.0f;
    public float Gravity = 20.0f;
    public float JumpHeight = 10.0f;

    public float HorizRotationSpeed, VerticalRotationSpeed;
    private float yaw, pitch;
    CharacterController CC;


	// Use this for initialization
	void Start () {
        CC = gameObject.GetComponent<CharacterController>();
        yaw = 0.0f;
        pitch = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        yaw += HorizRotationSpeed * Input.GetAxis("Mouse X");
        pitch -= VerticalRotationSpeed * Input.GetAxis("Mouse Y");

        mainCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        Vector3 MoveDirectionForward;
        Vector3 Movement = Vector3.zero;

        if (CC.isGrounded)
        {
            MoveDirectionForward = mainCamera.transform.forward;
            MoveDirectionForward.y -= Gravity * Time.deltaTime;
            MoveDirectionForward = new Vector3(MoveDirectionForward.x, 0, MoveDirectionForward.z);

            

            Vector3 MoveRight = Vector3.Cross(MoveDirectionForward, Vector3.up);
            Vector3 MoveLeft = -MoveRight;

            

            if (z != 0.0f)
            {
                Movement = z * MoveDirectionForward * MovementSpeed * Time.deltaTime;
                //CC.Move(z * MoveDirectionForward * MovementSpeed * Time.deltaTime);


            }
            if (x != 0.0f)
            {
                Movement = x * MoveLeft * MovementSpeed * Time.deltaTime;                
                //CC.Move(x * MoveLeft * MovementSpeed * Time.deltaTime);

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Movement.y = JumpHeight;
            }
        }
        Movement.y -= Gravity * Time.deltaTime;
        CC.Move(Movement);



    }
}
