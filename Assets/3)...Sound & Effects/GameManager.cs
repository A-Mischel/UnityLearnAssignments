using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance { get { return _instance; } }
    
    private bool playing = false;
    private bool gamePaused = false;

    
    
    private int _score = 0;
    private static GameManager _instance; 
    private UIManager uiManager;
    private PlayerController playerController;
    
    
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
        uiManager.StartGame();
        _score = 0;
        //uiManager.UpdateScore(_score);
        playing = true;
        playerController.Restart();
       
    }
    
    
    
    // public void PauseGame()
    // {
    //     if (playing)
    //     {
    //         playing = false;
    //         gamePaused = true;
    //     }
    //     //uiManager.EndGame();
    // }
    //
    // public void ResumeGame()
    // {
    //     if (gamePaused)
    //     {
    //         gamePaused = false; 
    //         playing = true;
    //     }
    // }
    
    public void togglePause()
    {
        if (gamePaused && !playing)
        {
            gamePaused = false;
            playing = true;
            uiManager.play();
            
        } else if (playing && !gamePaused)
        {
            playing = false;
            gamePaused = true;
            uiManager.Pause();
        }
    }
    
    
    public void endGame()
    {
        playing = false;
        uiManager.EndGame();
        Debug.Log("Game Over");

    }


}
