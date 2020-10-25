using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class EnemyRailwaySwitcher : MonoBehaviour
{
    private StickmanEvents stickmanEvents;
    private EnemyAnimationEvents enemyAnimationEvents;
    private SplineFollower splineFollower;
    private SplineComputer[] allRailways;

    private int activeRailwayIndex = -1;
    private bool canTurnLeft, canTurnRight;

    private void Awake()
    {
        CacheComponents();
    }

    private void OnEnable()
    {
        Observer.Instance.OnStartGame += Init;
    }
    private void CacheComponents()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
        enemyAnimationEvents = GetComponent<EnemyAnimationEvents>();
        splineFollower = GetComponent<SplineFollower>();
    }
    
    private void Init()
    {
        allRailways = RailwaysManager.Instance.AllRailways;
        List<SplineComputer> splineComputers = allRailways.ToList();
        activeRailwayIndex = splineComputers.IndexOf(splineFollower.spline);
        Debug.Log($"activeRailwayIndex = {activeRailwayIndex}");
    }

    public void SwitchRailway()
    {
        CheckAvailableRailways();
        if (canTurnLeft && canTurnRight)
        {
            int roll = Random.Range(0, 2);
            if (roll == 0)
            {
                TurnLeft();
            }
            else if (roll == 1)
            {
                TurnRight();
            }
        }
        else
        {
            if (canTurnLeft)
            {
                TurnLeft();                
            }
            else if (canTurnRight)
            {
                TurnRight();
            }
        }

        StartCoroutine(ChangeRailway());
    }

    IEnumerator ChangeRailway()
    {
        yield return new WaitForSeconds(0.1f);

        splineFollower.spline = allRailways[activeRailwayIndex];
        stickmanEvents.OnSwitchRailway(activeRailwayIndex);
    }

    private void TurnLeft()
    {
        activeRailwayIndex--;
        transform.DOMoveX(transform.position.x - 4f, GameConstants.SwitchRailwayTime);
    }

    private void TurnRight()
    {
        activeRailwayIndex++;
        transform.DOMoveX(transform.position.x + 4f, GameConstants.SwitchRailwayTime);
    }

    private void CheckAvailableRailways()
    {
        if (activeRailwayIndex == (int) Railways.Left)
        {
            canTurnLeft = false;
            canTurnRight = true;
        }
        else if (activeRailwayIndex == (int) Railways.Middle)
        {
            canTurnLeft = true;
            canTurnRight = true;
        }
        else if (activeRailwayIndex == (int) Railways.Right)
        {
            canTurnLeft = true;
            canTurnRight = false;
        }
    }
}
