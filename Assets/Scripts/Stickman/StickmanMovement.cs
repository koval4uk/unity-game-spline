using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class StickmanMovement : MonoBehaviour
{
    private StickmanEvents events;
    private SplineFollower follower;
    private float startMovementSpeed;
    private float limitMovementSpeed;
    private float increaseSpeedStep;

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
        startMovementSpeed = GameConstants.PlayerStartMovementSpeed;
        limitMovementSpeed = GameConstants.PlayerLimitMovementSpeed;
        increaseSpeedStep = GameConstants.PlayerIncreaseSpeedStep;
        follower.followSpeed = startMovementSpeed;
    }

    private void StartMove()
    {
        follower.follow = true;
        StartCoroutine(IncreaseSpeed());
    }

    private IEnumerator IncreaseSpeed()
    {
        Debug.Log("Increase Speed Start!");
        while (startMovementSpeed < limitMovementSpeed)
        {
            yield return new WaitForSeconds(0.1f);
            UpdateSpeed();
        }
    }

    private void UpdateSpeed()
    {
        startMovementSpeed += increaseSpeedStep;
        follower.followSpeed = startMovementSpeed;
    }

    private void UpdateSpeed(float speed)
    {
        startMovementSpeed = speed;
        follower.followSpeed = startMovementSpeed;
    }
}
