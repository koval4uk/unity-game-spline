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
        if (other.gameObject.CompareTag(GameConstants.TagPlayer))
        {
            Vector3 del_point = other.contacts[0].normal;
            if (Mathf.Sqrt(del_point.y * del_point.y + del_point.z * del_point.z) > Mathf.Abs(del_point.x))
            {
                enemyAnimationEvents.OnKickFromBehind();
                stickmanEvents.OnHitFromBehind();
            }
            else if (del_point.x > 0)
            {
                enemyAnimationEvents.OnKickRight();
                stickmanEvents.OnHitFromSide();
            }
            else if (del_point.x < 0)
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
            Debug.Log("Trigger with Wall!");
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
        
        if(other.CompareTag(GameConstants.TagEdge))
        {
            stickmanEvents.OnRailwayEnd();
        }

        if (other.CompareTag(GameConstants.TagTeeterSwitcher))
        {
            stickmanEvents.OnTeeterSwitch();
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
