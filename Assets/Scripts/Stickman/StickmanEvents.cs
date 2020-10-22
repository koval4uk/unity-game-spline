using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanEvents : MonoBehaviour
{
    public Action OnMove = delegate { Debug.Log("OnMove on Triggered!" ); };
    public Action<float> OnChangeSpeed = delegate { Debug.Log("OnChangeSpeed Triggered!"); };

    private void OnEnable()
    {
        Debug.Log($"Enable events {gameObject.name}");
        Observer.Instance.OnStartGame += OnMove;
        Observer.Instance.OnStartGame += delegate { StartCoroutine(LogListeners()); };
    }

    private IEnumerator LogListeners()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
