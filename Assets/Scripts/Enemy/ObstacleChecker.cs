using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    private StickmanEvents stickmanEvents;

    private void Awake()
    {
        stickmanEvents = GetComponentInParent<StickmanEvents>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GameConstants.TagObstacle))
        {
            stickmanEvents.OnObstacleDetected();
        }
    }
}
