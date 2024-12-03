using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;
    [SerializeField]
    private float startDelay = 0.5f;
    [SerializeField]
    private float repeatRate = 1f;
    [SerializeField]
    private Vector3 spawnPos;    
    private float leftBound = -10;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        if(gameManager.GameRunning() == true)
        {
            Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPos, quaternion.identity, this.transform);
        }

  
    }


}
