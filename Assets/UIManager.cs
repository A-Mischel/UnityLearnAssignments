using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }
    public GameObject startButton;
    public TextMeshProUGUI scoreText;
    public GameObject pauseButton;
    private AudioManager audioManager;
    public Material textMeshShader;

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
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(scoreText.transform.DOScale(new Vector3(2f, 2f, 2f), 0.5f));
        mySequence.Append(scoreText.transform.DOScale(Vector3.one, 0.5f));
        mySequence.Play();
        
        textMeshShader.SetColor("_FaceColor", new Color(1f, 1f, 1f, 1f));
        Sequence colorSequence = DOTween.Sequence();
        colorSequence.Append(DOTween.To(() => textMeshShader.GetColor("_FaceColor"), x => textMeshShader.SetColor("_FaceColor", x), new Color(7.3f, 7.3f, 7.3f, 1f), 0.5f));
        colorSequence.Append(DOTween.To(() => textMeshShader.GetColor("_FaceColor"), x => textMeshShader.SetColor("_FaceColor", x), new Color(1f, 1f, 1f, 1f), 0.5f));
        colorSequence.Play();
        
        
    }
    
    public void StartGame()
    {
        
        scoreText.text = "0";
        audioManager = AudioManager.Instance;
        startButton.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        startButton.gameObject.SetActive(true);
       
       
    }
    
    public void toggleMute()
    {
        AudioManager.Instance.toggleMute();
    }


    public void Pause()
    {
        pauseButton.gameObject.SetActive(true);
        
    }
    
    public void play()
    {
        pauseButton.gameObject.SetActive(false);
    }
    
}