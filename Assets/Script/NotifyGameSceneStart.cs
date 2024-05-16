using System;
using UnityEngine;

public class NotifyGameSceneStart : MonoBehaviour
{
    public static Action onLevelStart;


    public void Start()
    {
       NotifyGameSceneStart.onLevelStart?.Invoke();
    }
}
