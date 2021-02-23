using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    public GameObject PlayerCloud;
    public bool Absorbing = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Absorbing)
            PlayerCloud.transform.localScale += new Vector3(0.003f, 0.003f, 0);
    }

}
