using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class PlayerRailwaySwitcher : MonoBehaviour
{
    private SplineFollower splineFollower;

    private void Awake()
    {
        CacheComponents();
    }

    private void CacheComponents()
    {
        splineFollower = GetComponent<SplineFollower>();
    }

    private void OnEnable()
    {
        SwipeDetector.Instance.OnSwipe += SwitchRailway;
    }

    private void SwitchRailway(SwipeData swipeData)
    {
        splineFollower.spline = RailwaysManager.Instance.GetActiveRailway(swipeData);
    }
    
}
