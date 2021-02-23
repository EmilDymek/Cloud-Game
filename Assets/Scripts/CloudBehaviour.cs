using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    bool Absorbing = false;
    public Transform tf;
    public GameObject PlayerCloud;
    public GameObject CloudController;
    public float CloudSize;

    private void Awake()
    {
        tf.localScale = new Vector3(0, 0, 0);
        CloudSize = Random.Range(0.4f, 1.2f);
    }


    void Update()
    {
        if (Absorbing)
        {
            if (tf.localScale.x > 0)
            {
                tf.localScale -= new Vector3(0.01f, 0.01f, 0);
            }
            else
            {
                PlayerBehaviour Player = PlayerCloud.GetComponent<PlayerBehaviour>();
                Player.Absorbing = false;
                CloudMan cloudController = CloudController.GetComponent<CloudMan>();
                cloudController.CloudIndex--;
                Destroy(gameObject);
            }
        }
        else
        {
            if (tf.localScale.x < CloudSize)
            {
                tf.localScale += new Vector3(0.01f, 0.01f, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D Hitinfo)
    {
        if (Hitinfo.tag == "Player")
        {
            Absorbing = true;
            PlayerBehaviour Player = PlayerCloud.GetComponent<PlayerBehaviour>();
            Player.Absorbing = true;
        }
    }
}
