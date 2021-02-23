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

    public bool Absorbing = false;
    public bool Raining = false;
    private float PlayerRainSize = 2;
    private float PlayerMinSize = 0.44f;

    void Start()
    {
        RainFX.SetActive(false);
        StormFX1.SetActive(false);
        StormFX2.SetActive(false);
        StormFX3.SetActive(false);
    }

    void Update()
    {
        if (Absorbing)
            PlayerCloud.transform.localScale += new Vector3(0.003f, 0.003f, 0);

        if (PlayerCloud.transform.localScale.x > PlayerRainSize)
        {
            RainFX.SetActive(true);
            Raining = true;
        }

        if (Raining == true)
        {
            if (PlayerCloud.transform.localScale.x >  PlayerMinSize)
            {
                PlayerCloud.transform.localScale -= new Vector3(0.0005f, 0.0005f, 0);
            }
            else
            {
                Raining = false;
                RainFX.SetActive(false);
            }
        }
            

    }

}
