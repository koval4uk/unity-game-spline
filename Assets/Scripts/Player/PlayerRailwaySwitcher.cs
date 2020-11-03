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
        Debug.Log($"<color=red>currentPercent = {splineProjector.result.percent} </color>");
        currentPercent = splineProjector.result.percent;
        if (!RailwaysManager.Instance.IsSwitchValid(currentPercent))
        {
            newRailwayIndex = activeRailwayIndex;
            return;
        }
        activeRailwayIndex = newRailwayIndex;
        currentPosition = splineProjector.spline.EvaluatePosition(currentPercent);
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = currentPosition;
        cube.transform.rotation = Quaternion.identity;

        splineFollower.spline = null;
        transform.DOMoveX(currentPosition.x, GameConstants.SwitchRailwayTime);

        StartCoroutine(Switch());
    }

    private IEnumerator Switch()
    {
        yield return new WaitForSeconds(0.01f);
        currentPercent = splineProjector.result.percent;

        splineFollower.motion.applyPosition = false;
        splineFollower.spline = newRailway;
        splineFollower.SetPercent(currentPercent);
        splineFollower.motion.applyPosition = true;
    }
}
