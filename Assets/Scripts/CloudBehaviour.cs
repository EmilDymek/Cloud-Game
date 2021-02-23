using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    bool Absorbing = false;
    public Transform tf;
    public GameObject PlayerCloud;
    

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
                Destroy(gameObject);
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
