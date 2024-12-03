using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    private Animator _animator;

    private static GameManager _instance;

    
    public static GameManager Instance { get { return _instance; } }
    
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _animator = GameObject.Find("Player").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
         //_animator.SetBool("Death_b", false);
        playerController.Restart();
        _animator.SetBool("Revive", true);
        StartCoroutine(Revival());



    }

    private IEnumerator Revival()
    {
        yield return new WaitForSeconds(1);
        _animator.SetBool("Revive", false);

    }
}
