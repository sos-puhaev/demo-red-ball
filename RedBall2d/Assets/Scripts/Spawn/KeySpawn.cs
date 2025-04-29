using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    [SerializeField] Transform[] keySpawnPoints; 
    [SerializeField] GameObject keyPrefab;

    void Start()
    {
        SpawnKey();
    }

    void SpawnKey()
    {
        for(int i = 0; i < keySpawnPoints.Length; i++)
        {
           Instantiate(keyPrefab, keySpawnPoints[i].position, Quaternion.identity);
        }
    }
}
