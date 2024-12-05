using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance { get { return _instance; } }
    
    private bool playing = false;
    private bool gamePaused = false;
    private bool playerHasJumped = false;
    private bool isFirstRun = true;
    
    
    private int _score = 0;
    private static GameManager _instance; 
    private UIManager uiManager;
    private SpawnManager obstacleSpawnManager;
    private PlayerController playerController;
    private BaggySpawner baggySpawner;
    private MoveRight backgroundMovingScript;
    
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    
    void Start()
    {
        uiManager = UIManager.Instance;
        playerController = PlayerController.Instance;
        obstacleSpawnManager = SpawnManager.Instance;
        baggySpawner = BaggySpawner.Instance;
        backgroundMovingScript = MoveRight.Instance;
    }

    public bool GameRunning()
    {
        return playing;
    }

    
    public void IncrementScore()
    {
        _score++;
        uiManager.UpdateScore(_score);
      
    }
    

    public void Reset()
    {
     
        obstacleSpawnManager.RemoveObstacles();
        uiManager.StartGame();
        _score = 0;
        //uiManager.UpdateScore(_score);
        playing = true;
        playerController.Restart();
        if (isFirstRun)
        {
            uiManager.showInstructions();
            isFirstRun = false;
            playerController.startWalking();
        }
        else
        {
            obstacleSpawnManager.StartSpawningObstacles();

        }
       
    }

    public void onFirstInput()
    {
        DOTween.To(() => backgroundMovingScript.speed, x => backgroundMovingScript.speed = x, 20f, 1.0f).SetDelay(1.0f);
        obstacleSpawnManager.StartSpawningObstacles();
        baggySpawner.StartSpawningBags();
        uiManager.removeInstructions();
    }
    
    
    
    public void togglePause()
    {
        if (gamePaused && !playing)
        {
            gamePaused = false;
            playing = true;
            obstacleSpawnManager.StartSpawningObstacles();
            uiManager.play();
            
        } else if (playing && !gamePaused)
        {
            playing = false;
            gamePaused = true;
            obstacleSpawnManager.StopSpawningObstacles();
            uiManager.Pause();
        }
    }
    
    
    public void endGame()
    {
        playing = false;
        uiManager.EndGame();

    }


}
