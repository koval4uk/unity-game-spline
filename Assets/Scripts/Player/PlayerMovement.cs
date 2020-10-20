using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerEvents events;
    private SplineFollower follower;
    private float movementSpeed = 2.0f;

    private void Awake()
    {
        CacheComponents();
        Init();
    }

    private void OnEnable()
    {
        events.OnMove += StartMove;
    }

    private void CacheComponents()
    {
        events = GetComponent<PlayerEvents>();
        follower = GetComponent<SplineFollower>();
    }

    private void Init()
    {
        follower.followSpeed = movementSpeed;
    }

    private void StartMove()
    {
        follower.follow = true;
    }
}
