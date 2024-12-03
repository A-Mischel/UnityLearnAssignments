using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float speed = 25;
    private GameManager gameManager;
    private float leftBound = -15f;
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