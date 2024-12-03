using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocaine : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sniffing;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(sniffing);
    }
}
