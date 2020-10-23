using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private StickmanEvents stickmanEvents;
    private EnemyRailwaySwitcher enemyRailwaySwitcher;
    private float dodgeTimer = GameConstants.DodgeCooldown;

    private void Awake()
    {
        CacheComponents();
    }

    private void OnEnable()
    {
        stickmanEvents.OnObstacleDetected += SwitchSpline;
    }

    private void CacheComponents()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
        enemyRailwaySwitcher = GetComponent<EnemyRailwaySwitcher>();
    }

    private void Update()
    {
        dodgeTimer += Time.deltaTime;
    }

    private void SwitchSpline()
    {
        Debug.Log("Roll dodge!");
        int roll = Random.Range(0, 100);
        if (roll < GameConstants.ChanceToDodge && CanDodge())
        {
            Debug.Log("Success dodge!");
            enemyRailwaySwitcher.SwitchRailway();
            ResetTimer();
        }
    }

    private bool CanDodge()
    {
        return dodgeTimer >= GameConstants.DodgeCooldown;
    }

    private void ResetTimer()
    {
        dodgeTimer = 0;
    }
}
