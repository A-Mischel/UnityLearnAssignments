using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] NumberPrefabs;
    public string input = "123";
    private float distance = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("spawnnumbers")]
    public void spawnnumbers()
    {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        distance = 1;
        foreach (char i in input)
        {
            //Debug.Log(i);
            Instantiate(NumberPrefabs[int.Parse(i.ToString())], new Vector3(transform.position.x , transform.position.y, transform.position.z + distance), NumberPrefabs[int.Parse(i.ToString())].transform.rotation, this.transform);
            distance += 2.5f;
        }
        
    }
}
