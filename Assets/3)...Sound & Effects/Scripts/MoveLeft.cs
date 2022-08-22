using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 25;
    private PlayerController playerController;
    private float leftBound = -15f;
    void Start()
    {
       playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
        
        if(transform.position.x < leftBound && (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Collectable")))
        {
            Destroy(gameObject);
        }
        
    }
}
