using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float verticalVelocity = 0;
    public int MoSpeed = 5;
    public int RoSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        // rotate the player object about the Y axis
        // based on the mouse moving left and right
        float rotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, RoSpeed * rotation, 0);
        // rotate the camera (the player's "head") about its X axis
        // based on the mouse moving up and down
        float updown = Input.GetAxis("Mouse Y");
        Camera.main.transform.Rotate(-(RoSpeed * updown), 0, 0);

        // moving the player object forwards and backwards
        float forwardSpeed = Input.GetAxis("Vertical");
        // moving left to right
        float lateralSpeed = Input.GetAxis("Horizontal");

        // apply gravity – or rather figure out the resultant velocity
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        CharacterController characterController = GetComponent<CharacterController>();

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            verticalVelocity = 5;
        }
        Vector3 speed = new Vector3(MoSpeed * lateralSpeed, verticalVelocity, MoSpeed * forwardSpeed);
        // transform this absolute speed relative to the player's current rotation
        // i.e. we don't want them to move "north", but forwards depending on where
        // they are facing
        speed = transform.rotation * speed;
        // what is deltaTime?
        // move at a different speed to make up for variable framerates
        characterController.Move(speed * Time.deltaTime);
    }
}
