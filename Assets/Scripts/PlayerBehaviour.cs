using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    public GameObject PlayerCloud;
    public GameObject RainFX;
    public GameObject StormFX1;
    public GameObject StormFX2;
    public GameObject StormFX3;
    public GameObject RainBox;
    public float MaxY = 9.7f;
    public float MinY = -5.0f;

    public bool Absorbing = false;
    public bool Raining = false;
    private float PlayerRainSize = 2;
    private float PlayerMinSize = 0.44f;
    private Vector2 Direction;
    private Vector2 Position;

    void Start()
    {
        RainFX.SetActive(false);
        StormFX1.SetActive(false);
        StormFX2.SetActive(false);
        StormFX3.SetActive(false);
    }

    void Update()
    {
        //Direction = Vector2.zero;                                          //Zeroes the cameras direction
        //if (Input.GetKey(KeyCode.W))                                             //Checks if W is being pressed
        //{

        //    if (transform.position.y < MaxY)          //Checks if the cameras have reached the roof of the map
        //    {
        //        Direction += Vector2.up;                                   //Sets direction to up if W is being pressed
        //    }
        //}
        //if (Input.GetKey(KeyCode.A))                                             //Checks if A is being pressed
        //{
        //    Direction += Vector2.left;                                     //Sets direction to left if A is being pressed
        //}
        //if (Input.GetKey(KeyCode.S))                                             //Checks if S is being pressed
        //{
        //    if (transform.position.y > MinY)          //Checks if the cameras have reached the floor of the map
        //    {
        //        Direction += Vector2.down;                                 //Sets direction to down if S is being pressed
        //    }
        //}
        //if (Input.GetKey(KeyCode.D))                                             //Checks if D is being pressed
        //{
        //    Direction += Vector2.right;                                    //Sets direction to right if D is being pressed
        //}



        if (Absorbing)
            PlayerCloud.transform.localScale += new Vector3(0.6f, 0.6f, 0) * Time.deltaTime;

        if (PlayerCloud.transform.localScale.x > PlayerRainSize)
        {
            RainFX.SetActive(true);
            Raining = true;
        }

        if (Raining == true)
        {
            RainBox.SetActive(true);


            if (PlayerCloud.transform.localScale.x >  PlayerMinSize)
            {
                PlayerCloud.transform.localScale -= new Vector3(0.2f, 0.2f, 0) * Time.deltaTime;
            }
            else
            {
                Raining = false;
                RainFX.SetActive(false);
                RainBox.SetActive(false);
            }
        }
    }

}
