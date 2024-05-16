using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyGameSceneStart : MonoBehaviour
{
    public static Action onLevelStart;


    public void Start()
    {
        Debug.Log("ok ca commencer a jouer");
       NotifyGameSceneStart.onLevelStart?.Invoke();
    }
}
