using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerAnimationEvents animationEvents;
    private SplineFollower follower;

    private void Awake()
    {
        animationEvents = GetComponent<PlayerAnimationEvents>();
        follower = GetComponent<SplineFollower>();
    }

    private void OnEnable()
    {
        animationEvents.OnRailwayEnd += FallDown;
    }

    private void FallDown()
    {
        follower.follow = false;
        transform.DOMoveY(-5f, 0.5f);
        transform.DORotate(new Vector3(90f, 0f, 0f), 0.5f);
    }
}
