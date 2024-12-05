using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 5;
    private GameManager gameManager;
    private float leftBound = -15f;
    private static MoveRight _instance;
    public static MoveRight Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    void Start()
    {
        gameManager = GameManager.Instance;
     
    }
    
    void FixedUpdate()
    {
        if (gameManager.GameRunning())
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
        
        if(transform.position.x < leftBound && (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Collectable")))
        {
            Destroy(gameObject);
        }
        
    }
}