using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    private Animator anime;
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        anime = GameObject.Find("Player").GetComponent<Animator>();
       // canvas = GameObject.Find("Canvas");
       // canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
         //anime.SetBool("Death_b", false);
        playerController.Restart();
        anime.SetBool("Revive", true);
        canvas.SetActive(false);
        StartCoroutine(revival());



    }

    IEnumerator revival()
    {
        yield return new WaitForSeconds(1);
        anime.SetBool("Revive", false);

    }
}
