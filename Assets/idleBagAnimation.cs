using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class idleBagAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
        transform.DORotate(new Vector3(0, 10, 0), 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).From(new Vector3(0, -10, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
