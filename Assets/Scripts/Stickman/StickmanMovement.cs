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
    private float speedMultiplier = 1f;

    private void Awake()
    {
        Debug.Log("<color=red>Awake Stickman Movement!</color>");
        CacheComponents();
        Init();
    }

    private void OnEnable()
    {
        Debug.Log("<color=red>Enable Stickman Movement</color>");
        Debug.Log("<color=red>events = </color>" + events);
        events.OnMove += StartMove;
        events.OnChangeSpeed += SetSpeed;
        events.OnMultiplySpeed += SetSpeedMultiplier;
    }

    private void CacheComponents()
    {
        events = GetComponent<StickmanEvents>();
        follower = GetComponent<SplineFollower>();
    }

    private void Init()
    {
        follower.follow = false;
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
        //Debug.Log("Increase Speed Start!");
        yield return new WaitForSeconds(0.1f);
        while (GameStarter.IsGameStarted)
        {
            //Debug.Log("<color=red> Increase Speed Loop !</color>");
            yield return new WaitForSeconds(0.1f);
            startMovementSpeed += increaseSpeedStep;
            if (startMovementSpeed > limitMovementSpeed)
            {
                startMovementSpeed = limitMovementSpeed;
            }
            UpdateSpeed();
        }

        //Debug.Log("<color=red>End Increase speed!</color>");
    }    

    private void SetSpeed(float speed)
    {
        startMovementSpeed = speed;
        UpdateSpeed();
    }

    private void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        follower.followSpeed = startMovementSpeed * speedMultiplier;
    }
}
