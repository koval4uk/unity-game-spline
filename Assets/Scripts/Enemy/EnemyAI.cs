using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private StickmanEvents stickmanEvents;

    private void Awake()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
    }

    private void OnEnable()
    {
        stickmanEvents.OnObstacleDetected += Dodge;
    }

    private void Dodge()
    {
        
    }
}
