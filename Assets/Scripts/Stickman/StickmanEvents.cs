using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanEvents : MonoBehaviour
{
    public Action OnMove = delegate { Debug.Log("OnMove Triggered!"); };
    public Action<float> OnChangeSpeed = delegate { Debug.Log("OnChangeSpeed Triggered!"); };
    public Action<float> OnMultiplySpeed = delegate { Debug.Log("OnMultiplySpeed Triggered!"); };
    public Action OnSetInitialSpeed = delegate { Debug.Log("OnSetInitialSpeed Triggered!"); };

    private void OnEnable()
    {
        Observer.Instance.OnStartGame += OnMove;
    }
}
