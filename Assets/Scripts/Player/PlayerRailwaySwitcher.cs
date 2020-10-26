using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;

public class PlayerRailwaySwitcher : MonoBehaviour
{
    private SplineFollower splineFollower;
    private SplineComputer activeRailway;

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
        activeRailway = RailwaysManager.Instance.GetActiveRailway(swipeData);
        transform.DOMoveX(activeRailway.transform.position.x, GameConstants.SwitchRailwayTime);

        StartCoroutine(WaitAndSwitch());
    }

    private IEnumerator WaitAndSwitch()
    {
        yield return new WaitForSeconds(0.1f);

        splineFollower.spline = activeRailway;
    }
}
