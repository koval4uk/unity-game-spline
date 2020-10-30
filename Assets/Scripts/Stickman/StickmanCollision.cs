using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanCollision : MonoBehaviour
{
    private StickmanEvents stickmanEvents;
    private EnemyAnimationEvents enemyAnimationEvents;

    private void Awake()
    {
        CacheComponents();
    }

    private void CacheComponents()
    {
        stickmanEvents = GetComponentInParent<StickmanEvents>();
        enemyAnimationEvents = GetComponentInParent<EnemyAnimationEvents>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collision with {other.gameObject.name}");
        if (other.gameObject.CompareTag(GameConstants.TagPlayer))
        {
            if(other.contacts[0].normal == Vector3.forward)
            {
                enemyAnimationEvents.OnKickFromBehind();
                stickmanEvents.OnHitFromBehind();
            }
            else if(other.contacts[0].normal == Vector3.right)
            {
                enemyAnimationEvents.OnKickRight();
                stickmanEvents.OnHitFromSide();
            }
            else if(other.contacts[0].normal == Vector3.left)
            {
                enemyAnimationEvents.OnKickLeft();
                stickmanEvents.OnHitFromSide();
            }            
            Debug.Log($"{other.contacts[0].normal}");            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger with {other.gameObject.name}");
        if (other.CompareTag(GameConstants.TagObstacle))
        {
            Debug.Log("stickmanEvents = " + stickmanEvents);
            other.GetComponent<IObstacle>().Initiate(stickmanEvents);
        }
        
        if(other.CompareTag(GameConstants.TagModificator))
        {
            other.GetComponent<IModificator>().Trigger(stickmanEvents);
        }

        if(other.CompareTag(GameConstants.TagRailModificator))
        {
            other.GetComponent<IRailModificator>().Play(stickmanEvents);
        }
        
        if(other.CompareTag(GameConstants.TagFinish))
        {
            stickmanEvents.OnFinish();
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
