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
    private float repeatRateMax;
    [SerializeField]
    private float repeatRateMin;
    
    [SerializeField]
    private Vector3 spawnPos;    
    private float leftBound = -10;
    private GameManager gameManager;
    private static SpawnManager _instance;
    public List<GameObject> obstacles = new List<GameObject>();
    private Coroutine spawnObstaclesCoroutine;
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


    public void StopSpawningObstacles()
    {
        if (spawnObstaclesCoroutine != null)
        {
            StopCoroutine(spawnObstaclesCoroutine);
            spawnObstaclesCoroutine = null;
        }
    }

    void SpawnObstacle()
    {
        if(gameManager.GameRunning())
        {
            GameObject newObstacle = Instantiate(
                obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
                spawnPos,
                Quaternion.identity,
                this.transform);
            obstacles.Add(newObstacle);
        }

  
    }
    
    [ContextMenu("destroy obstacles")]
    public void RemoveObstacles()
    {
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
        obstacles.Clear();
    }
    
    public void StartSpawningObstacles()
    {
        spawnObstaclesCoroutine = StartCoroutine(SpawnObstaclesWithRandomDelay());
    }
    
    private IEnumerator SpawnObstaclesWithRandomDelay()
    {
        
        yield return new WaitForSeconds(startDelay);
        while (gameManager.GameRunning())
        {
            SpawnObstacle();
            yield return new WaitForSeconds(Random.Range(repeatRateMin, repeatRateMax)); // Adjust the range as needed
        }
    }


}
