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
    private SplineProjector splineProjector;
    private SplineComputer[] allRailways;

    private int activeRailwayIndex = -1;
    private int newRailwayIndex;

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
        splineProjector = GetComponent<SplineProjector>();
    }
    
    private void Init()
    {
        allRailways = RailwaysManager.Instance.AllRailways;
        List<SplineComputer> splineComputers = allRailways.ToList();
        activeRailwayIndex = splineComputers.IndexOf(splineFollower.spline);
        newRailwayIndex = activeRailwayIndex;
        splineProjector.spline = allRailways[activeRailwayIndex];
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
    }

    private void CheckAvailableRailways()
    {
        if (activeRailwayIndex == (int)Railways.Left)
        {
            canTurnLeft = false;
            canTurnRight = true;
        }
        else if (activeRailwayIndex == (int)Railways.Middle)
        {
            canTurnLeft = true;
            canTurnRight = true;
        }
        else if (activeRailwayIndex == (int)Railways.Right)
        {
            canTurnLeft = true;
            canTurnRight = false;
        }
    }

    private void TurnLeft()
    {
        Debug.Log("TurnLeft");
        splineProjector.spline = allRailways[--newRailwayIndex];
        double currentPercent = splineProjector.result.percent;
        if (!RailwaysManager.Instance.IsSwitchValid(currentPercent))
        {
            Debug.Log("Can't turn");
            newRailwayIndex = activeRailwayIndex;
            return;
        }

        activeRailwayIndex = newRailwayIndex;
        transform.DOMoveX(transform.position.x - 4f, GameConstants.SwitchRailwayTime).OnComplete(ChangeRailway);
    }

    private void TurnRight()
    {
        Debug.Log("TurnRight");
        splineProjector.spline = allRailways[++newRailwayIndex];
        double currentPercent = splineProjector.result.percent;
        if (!RailwaysManager.Instance.IsSwitchValid(currentPercent))
        {
            Debug.Log("Can't turn");
            newRailwayIndex = activeRailwayIndex;
            return;
        }

        activeRailwayIndex = newRailwayIndex;
        transform.DOMoveX(transform.position.x + 4f, GameConstants.SwitchRailwayTime).OnComplete(ChangeRailway);
    }

    private void ChangeRailway()
    {
        splineProjector.spline = allRailways[newRailwayIndex];
        double currentPercent = splineProjector.result.percent;

        splineFollower.motion.applyPosition = false;
        splineFollower.spline = allRailways[newRailwayIndex];
        splineFollower.SetPercent(currentPercent);
        splineFollower.motion.applyPosition = true;

        stickmanEvents.OnSwitchRailway(newRailwayIndex);
    }
}
