using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines;

public class EnemyAnimation : MonoBehaviour
{
    private EnemyAnimationEvents enemyAnimationEvents;
    private SplineFollower follower;
    private Rigidbody rigidbody;

    private void Awake()
    {
        CacheComponents();
    }

    private void OnEnable()
    {
        enemyAnimationEvents.OnKickFromBehind += GetKickedFromBehind;
        enemyAnimationEvents.OnKickLeft += GetKickedFromLeft;
        enemyAnimationEvents.OnKickRight += GetKickedFromRight;
        enemyAnimationEvents.FallDown += FallDown;
    }

    private void CacheComponents()
    {
        rigidbody = GetComponent<Rigidbody>();
        enemyAnimationEvents = GetComponent<EnemyAnimationEvents>();
        follower = GetComponent<SplineFollower>();
    }

    private void GetKickedFromBehind()
    {
        follower.follow = false;
        transform.DOMoveY(8f, 0.5f);
    }

    private void GetKickedFromLeft()
    {
        follower.follow = false;
        transform.DOMoveX(-8f, 0.5f);
        transform.DORotate(new Vector3(0f, 0f, 90f), 0.5f);
    }

    private void GetKickedFromRight()
    {
        follower.follow = false;
        transform.DOMoveX(8f, 0.5f);
        transform.DORotate(new Vector3(0f, 0f, -90f), 0.5f);
    }
    
    private void FallDown()
    {
        Debug.Log("<color=red>Fall Down!</color>");
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.useGravity = true;
    } 
    
    private void HideFollower()
    {
        follower.gameObject.SetActive(false);
    }
}
