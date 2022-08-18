using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody rb;
    
    public bool gameOver = false;
    private bool isGrounded;
    void Awake()
    {
        controls = new PlayerControls();
        rb = this.GetComponent<Rigidbody>(); 
        controls.Player.Jump.started += _ => Jump();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
}
