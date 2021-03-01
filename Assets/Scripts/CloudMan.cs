using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMan : MonoBehaviour
{
    public GameObject Cloud;
    public GameObject Tree;
    private Vector3 SpawnLocation;
    private Vector3 TreeSpawnLocation;
    private float SpawnDelay;
    public int CloudIndex = 0;
    public int TreeIndex = 0;


    void Update()
    {
        SpawnDelay -= 1 * Time.deltaTime;
        if (SpawnDelay <= 0 && TreeIndex < 30 )
        {
            SpawnTree();
        }
        else
        {
            if (SpawnDelay <= 0 && CloudIndex < 15)
                SpawnCloud();
        }
    }

    void SpawnCloud()
    {
        SpawnLocation.Set(Random.Range(-30, 30), Random.Range(4, 15.2f), 0);
        Instantiate(Cloud, SpawnLocation, Quaternion.identity);
        SpawnDelay = 0.1f;
        CloudIndex++;
    }

    void SpawnTree()
    {
        TreeSpawnLocation.Set(Random.Range(-30, 30), Random.Range(-1.27f, -1.4f), 0);
        Instantiate(Tree, TreeSpawnLocation, Quaternion.identity);
        SpawnDelay = 0.01f;
        TreeIndex++;
    }
}
