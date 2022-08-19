using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    private PlayerControls controls;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls(); 
        playerRb = GetComponent<Rigidbody>();
        controls.Player.Jump.started += _ => Jump();
    }

    void Jump()
    {
        if(gameOver == false)
        {
            Debug.Log("Jumped");
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }
    
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

       

    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }
    
    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

}
