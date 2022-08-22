using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;
    [SerializeField]
    private float startDelay = 0.5f;
    [SerializeField]
    private float repeatRate = 1f;
    [SerializeField]
    private Vector3 spawnPos;    
    private PlayerController playerController;
    private float leftBound = -10;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if(playerController.gameOver == false)
        {
            Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], new Vector3(spawnPos.x, Random.Range(2, 4), 0), quaternion.identity, this.transform);
        }

  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}