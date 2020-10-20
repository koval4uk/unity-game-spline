using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public Action OnMove = delegate { Debug.Log("OnMove Triggered!"); };

    private void OnEnable()
    {
        Observer.Instance.OnStartGame += OnMove;
    }
}
