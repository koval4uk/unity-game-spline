using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerEvents playerEvents;

    private void Awake()
    {
        CacheComponents();
    }

    private void CacheComponents()
    {
        playerEvents = GetComponent<PlayerEvents>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collision with {other.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger with {other.gameObject.name}");
        if (other.gameObject.CompareTag(GameConstants.TagObstacle))
        {
            other.GetComponent<IObstacle>().Initiate(playerEvents);
        }
    }
}
