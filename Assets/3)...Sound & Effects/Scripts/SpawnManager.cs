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
    private static SpawnManager _instance;
    public static SpawnManager Instance { get { return _instance; } }
    
    void Start() {
    if (_instance != null && _instance != this)
    {
        Destroy(this.gameObject);
    }
    else
    {
        _instance = this;
    }

    gameManager = GameManager.Instance;
    }

    public void StartSpawningObstacles()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }
    
    public void StopSpawningObstacles()
    {
        CancelInvoke("SpawnObstacle");
    }

    void SpawnObstacle()
    {
        if(gameManager.GameRunning())
        {
            Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPos, quaternion.identity, this.transform);
        }

  
    }


}
