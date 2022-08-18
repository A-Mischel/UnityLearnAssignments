using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    private int Count = 0;
    public Numbers Numbers;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {

        other.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Count += 1;
        Numbers.input = Count.ToString();
        Numbers.spawnnumbers();
        
    }
}
