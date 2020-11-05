using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivationTrigger : MonoBehaviour
{
    [SerializeField] private StickmanEvents stickmanEvents;
    private bool isActive;

    private void OnEnable()
    {
        stickmanEvents.OnActivateTrigger += Activate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstants.TagPlayer) && isActive)
        {
            stickmanEvents.OnActivate();
        }
    }

    private void Activate()
    {
        isActive = true;
    }
}
