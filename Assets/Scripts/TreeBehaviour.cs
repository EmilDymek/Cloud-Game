using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool RainedOn = false;
    public Transform Stage1;
    public Transform Stage2;
    public GameObject _Stage1;
    public GameObject _Stage2;

    private void Start()
    {
    }

    void Update()
    {
        if (RainedOn)
        {
            if (_Stage1.activeSelf == true)
            {
                if (Stage1.transform.localScale.x < 2.5)
                {
                    Stage1.transform.localScale += new Vector3(0.002f, 0.002f, 0);
                }
                else
                {
                    _Stage1.SetActive(false);
                    _Stage2.SetActive(true);
                }
            }
            else
            {
                if (Stage2.transform.localScale.x < 2.5)
                {
                    Stage2.transform.localScale += new Vector3(0.001f, 0.001f, 0);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rain")
        {
            Debug.Log("rainy rain");
            RainedOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rain")
        {
            Debug.Log("No rain, very sad");
            RainedOn = false;
        }
    }
}
