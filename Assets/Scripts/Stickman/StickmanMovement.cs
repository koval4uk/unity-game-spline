using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class StickmanMovement : MonoBehaviour
{
    private StickmanEvents events;
    private SplineFollower follower;
    private float movementSpeed = 2.0f;
    private float limitMovementSpeed = 28.0f;
    private float increaseSpeedStep = 0.45f;

    private void Awake()
    {
        CacheComponents();
        Init();
    }

    private void OnEnable()
    {
        events.OnMove += StartMove;
        events.OnChangeSpeed += UpdateSpeed;
    }

    private void CacheComponents()
    {
        events = GetComponent<StickmanEvents>();
        follower = GetComponent<SplineFollower>();
    }

    private void Init()
    {
        follower.followSpeed = movementSpeed;
    }

    private void StartMove()
    {
        follower.follow = true;
        StartCoroutine(IncreaseSpeed());
    }

    private IEnumerator IncreaseSpeed()
    {
        Debug.Log("Increase Speed Start!");
        while (movementSpeed < limitMovementSpeed)
        {
            yield return new WaitForSeconds(0.1f);
            UpdateSpeed();
        }
    }

    private void UpdateSpeed()
    {
        movementSpeed += increaseSpeedStep;
        follower.followSpeed = movementSpeed;
    }

    private void UpdateSpeed(float speed)
    {
        movementSpeed = speed;
        follower.followSpeed = movementSpeed;
    }
}
