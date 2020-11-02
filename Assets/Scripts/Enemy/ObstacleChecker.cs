using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    private StickmanEvents stickmanEvents;
    private EnemyAnimationEvents enemyAnimationEvents;
    
    private void Awake()
    {
        stickmanEvents = GetComponentInParent<StickmanEvents>();
        enemyAnimationEvents = GetComponentInParent<EnemyAnimationEvents>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GameConstants.TagObstacle))
        {
            stickmanEvents.OnObstacleDetected();
        }
        
        if (other.gameObject.CompareTag(GameConstants.TagEdge))
        {
            enemyAnimationEvents.FallDown();
        }
    }
}
