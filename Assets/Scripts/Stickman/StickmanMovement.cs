using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class StickmanMovement : MonoBehaviour
{
    [SerializeField] private float startMovementSpeed;
    [SerializeField] private float limitMovementSpeed;
    [SerializeField] private float increaseSpeedStep;
    
    private StickmanEvents events;
    private SplineFollower follower;

    private void Awake()
    {
        CacheComponents();
        Init();
    }

    private void OnEnable()
    {
        Debug.Log($"Enable Stickman Movement on {gameObject.name}");
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
        follower.followSpeed = startMovementSpeed;
    }

    private void StartMove()
    {
        Debug.Log($"Stickman {gameObject.name} start moving");
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
