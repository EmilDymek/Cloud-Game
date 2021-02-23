using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMan : MonoBehaviour
{
    public GameObject Cloud;
    private Vector3 SpawnLocation;
    private float SpawnDelay;
    public int CloudIndex = 0;


    void Start()
    {
        
    }


    void Update()
    {
        SpawnDelay -= 1 * Time.deltaTime;
        if (SpawnDelay <= 0 && CloudIndex < 20)
            SpawnCloud();
    }

    void SpawnCloud()
    {
        SpawnLocation.Set(Random.Range(-37, 37), Random.Range(0, 15.2f), 0);
        Instantiate(Cloud, SpawnLocation, Quaternion.identity);
        SpawnDelay = 0.1f;
        CloudIndex++;
    }
}
