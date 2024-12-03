using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BaggySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;
    [SerializeField]
    private float startDelay = 0.5f;
    [SerializeField]
    private float repeatRate = 1f;
    [SerializeField]
    private Vector3 spawnPos;    
    private GameManager gameManager;
    private float leftBound = -10;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        gameManager = GameManager.Instance;
    }

    void SpawnObstacle()
    {
        if(gameManager.GameRunning())
        {
            Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], new Vector3(spawnPos.x, Random.Range(2, 8), 0), quaternion.identity, this.transform);
        }

  
    }


}