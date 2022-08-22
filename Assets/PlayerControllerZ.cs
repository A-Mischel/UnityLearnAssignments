using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace aryeh
{
public class PlayerControllerZ : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody playerRb;
    public GameObject focalPoint;
    
    void Start() {
        playerRb = GetComponent<Rigidbody> ();
        focalPoint = GameObject.Find ("FocalPoint"); }
    void Update () {
        float forwardInput = Input.GetAxis ("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput, ForceMode.Force);

    }
}
}
