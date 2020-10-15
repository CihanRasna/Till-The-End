﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] roadPrefabs;
    [SerializeField] private List<GameObject> activeRoads = new List<GameObject>();
    
    [SerializeField] private float startSpawnPos = 15f;
    [SerializeField] private float roadLength = 1.5f;
    
    [SerializeField] private int numberOfRoad = 10;
    [SerializeField] private int emptyRoad = 3;
    
    [SerializeField] private Transform playerTransform;
    
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        for (int i = 0; i < numberOfRoad; i++)
        {
            for (int j = 0; j < emptyRoad; j++)
            {
                spawnRoad(0);
            }
            spawnRoad(Random.Range(0,roadPrefabs.Length));
        }
    }

    
    void Update()
    {
        if (playerTransform.position.z > startSpawnPos - (numberOfRoad * roadLength))
        {
            spawnRoad(0);
            spawnRoad(0);
            spawnRoad(0);
            spawnRoad(Random.Range(0,roadPrefabs.Length));
            DeleteRoad();
        }
    }

    void spawnRoad(int roadIndex)
    {
        GameObject go = Instantiate(roadPrefabs[roadIndex], transform.forward * startSpawnPos, transform.rotation);
        activeRoads.Add(go);
        startSpawnPos += roadLength;
    }

    void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}
