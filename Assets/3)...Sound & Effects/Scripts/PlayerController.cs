using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public bool gameOver = false;
    private bool isGrounded = true;
    private Animator anime;
    void Awake()
    {
        controls = new PlayerControls();
        rb = this.GetComponent<Rigidbody>(); 
        controls.Player.Jump.started += _ => Jump();
        anime =  GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            dirtParticle.Stop();
            gameOver = true;
            anime.SetBool("Death_b", true);
            anime.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f); 
        }
        
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isGrounded = true;
            dirtParticle.Play();
        }
     
    }

    private void Jump()
    {
        if (isGrounded & !gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f); 
            dirtParticle.Stop();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
            anime.SetTrigger("Jump_trig");
        }
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
}
