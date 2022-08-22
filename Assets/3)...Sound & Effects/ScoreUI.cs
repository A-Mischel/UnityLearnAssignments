using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text text;
    public Score score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.score.ToString();
    }
}
