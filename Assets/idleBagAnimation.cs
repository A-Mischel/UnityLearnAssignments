using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class idleBagAnimation : MonoBehaviour
{
    void Start()
    {
      
        transform.DORotate(new Vector3(0, 20, 0), 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).From(new Vector3(0, -20, 0));
    }

}
