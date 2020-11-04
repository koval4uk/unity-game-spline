using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class StickmanMovement : MonoBehaviour
{
    [SerializeField] private float startMovementSpeed;
    private float currentMovementSpeed;
    [SerializeField] private float limitMovementSpeed;
    [SerializeField] private float forwardSpeedStep;
    
    private StickmanEvents stickmanEvents;
    private SplineFollower follower;
    private float speedMultiplier = 1f;
    private float lastHeight;
    private float speedIncrease = GameConstants.PlayerIncreaseSpeed;
    private float speedDecrease = GameConstants.PlayerDecreaseSpeed;
    private float threshold = 0.1f;
    private Coroutine increaseSpeedCoroutine;

    private void Awake()
    {
        CacheComponents();
        Init();
    }

    private void OnEnable()
    {
        stickmanEvents.OnMove += StartMove;
        stickmanEvents.OnChangeSpeed += SetSpeed;
        stickmanEvents.OnMultiplySpeed += SetSpeedMultiplier;
        stickmanEvents.OnRailwayEnd += StopMove;
    }

    private void Update()
    {
        if (!GameStarter.IsGameStarted)
            return;
        
        CheckSpeed();
    }

    private void CacheComponents()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
        follower = GetComponent<SplineFollower>();
    }

    private void Init()
    {
        follower.follow = false;
        follower.followSpeed = startMovementSpeed;
        currentMovementSpeed = startMovementSpeed;
        lastHeight = transform.position.y;
    }

    private void StartMove()
    {
        Debug.Log($"Stickman {gameObject.name} start moving");
        follower.follow = true;
        increaseSpeedCoroutine = StartCoroutine(IncreaseSpeed());
    }
    
    private void StopMove()
    {
        currentMovementSpeed = 0.0f;
        follower.followSpeed = currentMovementSpeed;
        follower.follow = false;
        StopCoroutine(increaseSpeedCoroutine);
    }
    
    private IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(0.1f);
        while (GameStarter.IsGameStarted)
        {
            yield return new WaitForSeconds(0.1f);
            float extraSpeed = forwardSpeedStep + GetHeightSpeed();
            currentMovementSpeed += extraSpeed;
            if (currentMovementSpeed > limitMovementSpeed)
            {
                currentMovementSpeed = limitMovementSpeed;
            }
            else if (currentMovementSpeed < GameConstants.PlayerMinSpeed)
            {
                currentMovementSpeed = GameConstants.PlayerMinSpeed;
            }
            UpdateSpeed();
        }
    }    

    private void SetSpeed(float speed)
    {
        currentMovementSpeed = speed;
        UpdateSpeed();
    }

    private void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        follower.followSpeed = currentMovementSpeed * speedMultiplier;
    }

    private float GetHeightSpeed()
    {
        if (Mathf.Abs(lastHeight - transform.position.y) < threshold)
            return 0;
        
        if (lastHeight > transform.position.y)
        {
            Debug.Log("Increase Speed!");
            lastHeight = transform.position.y;
            return speedIncrease;
        }

        Debug.Log("Decrease Speed!");
        lastHeight = transform.position.y;
        return speedDecrease;
    }

    private void CheckSpeed()
    {
        if (currentMovementSpeed >= limitMovementSpeed - 5.0f)
        {
            stickmanEvents.OnHighSpeedReached();
        }
        else
        {
            stickmanEvents.OnSlowSpeed();
        }
    }

}
