using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;

public class PlayerRailwaySwitcher : MonoBehaviour
{
    private SplineProjector splineProjector;
    private SplineFollower splineFollower;
    private SplineComputer newRailway;

    private int activeRailwayIndex = (int)Railways.Middle;
    private int newRailwayIndex = (int)Railways.Middle;
    private double currentPercent;
    private Vector3 currentPosition;

    private void Awake()
    {
        CacheComponents();
    }

    private void CacheComponents()
    {
        splineFollower = GetComponent<SplineFollower>();
        splineProjector = GetComponent<SplineProjector>();
    }

    private void OnEnable()
    {
        SwipeDetector.Instance.OnSwipe += SwitchRailway;
    }    

    private void SwitchRailway(SwipeData swipeData)
    {
        newRailway = RailwaysManager.Instance.GetNewRailway(swipeData, ref newRailwayIndex);

        splineProjector.spline = newRailway;
        currentPercent = splineProjector.result.percent;
        if (!RailwaysManager.Instance.IsSwitchValid(currentPercent))
        {
            newRailwayIndex = activeRailwayIndex;
            return;
        }
        activeRailwayIndex = newRailwayIndex;
        currentPosition = splineProjector.spline.EvaluatePosition(currentPercent);

        transform.DOMoveX(currentPosition.x, GameConstants.SwitchRailwayTime).OnComplete(Switch);
    }

    private void Switch()
    {
        currentPercent = splineProjector.result.percent;

        splineFollower.motion.applyPosition = false;
        splineFollower.spline = newRailway;
        splineFollower.SetPercent(currentPercent);
        splineFollower.motion.applyPosition = true;
    }
}
