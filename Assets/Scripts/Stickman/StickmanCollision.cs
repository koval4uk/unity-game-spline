using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanCollision : MonoBehaviour
{
    private StickmanEvents stickmanEvents;

    private void Awake()
    {
        CacheComponents();
    }

    private void CacheComponents()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collision with {other.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger with {other.gameObject.name}");
        if (other.CompareTag(GameConstants.TagObstacle))
        {
            other.GetComponent<IObstacle>().Initiate(stickmanEvents);
        }

        if(other.CompareTag(GameConstants.TagRailModificator))
        {
            other.GetComponent<IRailModificator>().Play(stickmanEvents);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(GameConstants.TagRailModificator))
        {
            other.GetComponent<IRailModificator>().Stop(stickmanEvents);
        }
    }
}
