using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float Position;
    public float Scale;
    private bool black;
    private Material mat;
    private Color startColor;
    private Color endColor;

    void Start()
    {
        startColor = Random.ColorHSV();
        endColor = Random.ColorHSV();
    }
    
    void Update()
    {
       
       Color color = Renderer.material.color;
       color.a = Mathf.Lerp(0, 1, Mathf.PingPong(Time.time, 2));
       color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 1));
       Renderer.material.color = color;

    }
}
