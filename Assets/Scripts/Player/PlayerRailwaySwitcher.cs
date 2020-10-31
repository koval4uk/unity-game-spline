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
    private SplineComputer activeRailway;

    private double currentPercent;
    private Vector3 currentPosition;
    private bool needSwitch;

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
        activeRailway = RailwaysManager.Instance.GetActiveRailway(swipeData);

        splineProjector.spline = activeRailway;
        currentPercent = splineProjector.result.percent;
        currentPosition = splineProjector.spline.EvaluatePosition(currentPercent);

        transform.DOMoveX(currentPosition.x, GameConstants.SwitchRailwayTime).OnComplete(Switch);
    }

    private void Switch()
    {
        currentPercent = splineProjector.result.percent;

        splineFollower.motion.applyPosition = false;

        splineFollower.spline = activeRailway;
        splineFollower.SetPercent(currentPercent);

        splineFollower.motion.applyPosition = true;
    }
}
