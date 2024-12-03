using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }
    public GameObject startButton;
    public TextMeshProUGUI scoreText;
    
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    
    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        startButton.gameObject.SetActive(true);
       
       
    }
    
}