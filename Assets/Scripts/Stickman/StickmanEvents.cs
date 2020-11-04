using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanEvents : MonoBehaviour
{
    public Action OnMove = delegate { Debug.Log("OnMove Triggered!" ); };
    public Action<float> OnChangeSpeed = delegate { Debug.Log("OnChangeSpeed Triggered!"); };
    public Action<float> OnMultiplySpeed = delegate { Debug.Log("OnMultiplySpeed Triggered!"); };
    public Action OnSetInitialSpeed = delegate { Debug.Log("OnSetInitialSpeed Triggered!"); };
    public Action OnNitroAnimation = delegate { Debug.Log("OnRocketAnimation Triggered!"); };
    public Action OnFinish = delegate { Debug.Log("OnFinish Triggered!"); };
    public Action OnRailwayEnd = delegate { Debug.Log("<color=red>OnRailwayEnd Triggered!</color>"); };
    public Action OnTeeterSwitch = delegate { Debug.Log("OnRailwayEnd Triggered!"); };
    public Action OnHighSpeedReached = delegate { Debug.Log("OnHighSpeedReached!"); };
    public Action OnSlowSpeed;
    
    // Unique events for enemy
    public Action OnObstacleDetected = delegate { Debug.Log("OnObstacleDetected Triggered!"); };
    public Action<int> OnSwitchRailway = delegate { Debug.Log("OnSwitchRailway triggered with index"); }; // Возвращает индекс дорожки (0, 1, 2)
    public Action OnHitFromBehind = delegate { Debug.Log("OnHitFromBehind Triggered!"); };
    public Action OnHitFromSide = delegate { Debug.Log("OnHitFromSide Triggered!"); };

    public bool IsPlayer => isPlayer;
    private bool isPlayer;

    private void Awake()
    {
        isPlayer = GetComponent<PlayerManager>();
    }

    private void OnEnable()
    {
        Debug.Log($"Enable events {gameObject.name}");
        Observer.Instance.OnLevelManagerLoaded += SubscribeEvents;
    }

    private void SubscribeEvents(int empty)
    {
        Debug.Log("Subscribe Events");
        Observer.Instance.OnStartGame += OnMove;
    }
    
}
