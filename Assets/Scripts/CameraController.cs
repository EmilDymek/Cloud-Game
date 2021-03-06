﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{                                                                                //:::::Here be variables:::::
    private Vector2 CameraPosition;                                              //Keeps track of camera's position
    private Vector2 CameraDirection;                                             //Keeps track of the camera's direction
    public readonly float MaxX = 35f;                                        //This is the eastern border of the map
    public readonly float MinX = -35f;                                       //This is the western border of the map
    private readonly float MaxY = 20;                                         //This is the "roof" of the map
    private readonly float MinY = -3.7f;                                        //This is the "floor" of the map 
    private readonly float Wrap = 112.65f;                                       //This is one camera's space away from a border plus a camera's space off the border on the opposite side //57.601f
    private readonly float FarMaxX = 77.5f;                                     //This is one camera's space away from the eastern border //37.69f 46.08
    private readonly float FarMinX = -77.5f;                                    //This is one camera's space away from the western border //-37.69f
    private readonly float CameraVelocity;
    [SerializeField] private float CameraSpeed = 10.0f;                          //Change this variable to change camera movement speed
    private Vector3 StartPos;
    private Vector3 TargetPos;
    public Transform FollowTarget;

    public Rigidbody rb;

    Transform Camera1;                                                           //This variable stores the position of Camera 1
    Transform Camera2;                                                           //This variable stores the position of Camera 2

    void Awake()                                                                 //This happens once the object the script is attached to is instansiated
    {
        StartPos = transform.position;
        rb = GetComponent<Rigidbody>();
        Camera1 = transform.Find("Camera 1");                                    //This associates the variable to the game object Camera 1
        Camera2 = transform.Find("Camera 2");                                    //This associates the variable to the game object Camera 2
    }

    void Update()                                                                //This function is called once per frame
    {
        GetInput();                                                              //Calls input function once per frame
        CameraCheck();                                                           //Calls the camera loop function once per frame
    }

    //void FixedUpdate()
    //{
    //    TargetPos = new Vector3(FollowTarget.position.x, FollowTarget.position.y, transform.position.z);                //Updates target position to the FollowTarget's position
    //    Vector3 Velocity = (TargetPos - transform.position) * GM.CameraFollowSpeed;                                     //Stores the distance between the current possition and the target position
    //    transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, 1.0f, Time.deltaTime);     //Moves the Camera to the target position using Smoothdamp function
    //}

    void GetInput()                                                              //This function checks for player input and moves the camera accordingly
    {                                                                            //Camera direction is not exclusive to either up, down, left or right.
        //if (Input.GetAxis("Mouse X") != 0)
        //{
        //    transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * CameraSpeed,
        //                                       Input.GetAxisRaw("Mouse Y") * Time.deltaTime * CameraSpeed, 0.0f);
        //}
        transform.position = new Vector3(

            transform.position.x,
            Mathf.Clamp(transform.position.y, MinY, MaxY),                       //Makes sure Y isn't outside MinY or MaxY
            0
        );

        CameraDirection = Vector2.zero;                                          //Zeroes the cameras direction
        if (Input.GetKey(KeyCode.W))                                             //Checks if W is being pressed
        {

            if (Camera1.position.y < MaxY && Camera2.position.y < MaxY)          //Checks if the cameras have reached the roof of the map
            {
                CameraDirection += Vector2.up;                                   //Sets direction to up if W is being pressed
            }
        }
        if (Input.GetKey(KeyCode.A))                                             //Checks if A is being pressed
        {
            CameraDirection += Vector2.left;                                     //Sets direction to left if A is being pressed
        }
        if (Input.GetKey(KeyCode.S))                                             //Checks if S is being pressed
        {
            if (Camera1.position.y > MinY && Camera2.position.y > MinY)          //Checks if the cameras have reached the floor of the map
            {
                CameraDirection += Vector2.down;                                 //Sets direction to down if S is being pressed
            }
        }
        if (Input.GetKey(KeyCode.D))                                             //Checks if D is being pressed
        {
            CameraDirection += Vector2.right;                                    //Sets direction to right if D is being pressed
        }

        transform.Translate(CameraDirection * CameraSpeed * Time.deltaTime);     //Moves the camera according to direction and speed times time in seconds
    }

    void CameraCheck()                                                           //This Function moves the individual cameras to wrap around the map.
    {
        if (Camera1.position.x > MaxX)                                                                                                                   //If the main camera is over the right border
        {
            if (Camera1.position.x == Camera2.position.x)                                                                                                //If the main and secondary camera has the same position
            {
                Camera2.transform.SetPositionAndRotation(new Vector3(Camera1.position.x - Wrap, Camera1.position.y, -10), new Quaternion(0, 0, 0, 0));   //Move the secondary camera one "wrap distance" to the left
            }
            if (Camera1.position.x >= FarMaxX)                                                                                                           //If the main camera is off the right side of the map
            {
                Camera1.transform.SetPositionAndRotation(new Vector3(Camera2.position.x, Camera1.position.y, -10), new Quaternion(0, 0, 0, 0));          //Move the main camera to the secondary cameras position
            }
        }

        if (Camera1.position.x < MinX)                                                                                                                   //If the main camera is over the left border
        {
            if (Camera1.position.x == Camera2.position.x)                                                                                                //If the main and secondary camera has the same position
            {
                Camera2.transform.SetPositionAndRotation(new Vector3(Camera1.position.x + Wrap, Camera1.position.y, -10), new Quaternion(0, 0, 0, 0));   //Move the secondary camera one "wrap distance" to the right
            }
            if (Camera1.position.x <= FarMinX)                                                                                                           //If the main camera is off the left side of the border
            {
                Camera1.transform.SetPositionAndRotation(new Vector3(Camera2.position.x, Camera1.position.y, -10), new Quaternion(0, 0, 0, 0));          //Move the main camera to the secondary cameras position
            }
        }

        if (Camera2.position.x < FarMinX || Camera2.position.x > FarMaxX)                                                                                //If the secondary camera is off the screen on any side
        {
            Camera2.transform.SetPositionAndRotation(new Vector3(Camera1.position.x, Camera1.position.y, -10), new Quaternion(0, 0, 0, 0));              //Move the secondary camera to the main cameras position
        }
    }
}
