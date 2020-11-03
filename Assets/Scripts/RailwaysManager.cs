using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Singleton;
using UnityEngine;

public enum Railways
{
    Left,
    Middle,
    Right
}
public class RailwaysManager : Singleton<RailwaysManager>
{
    [SerializeField] private SplineComputer[] allRailways;
    public SplineComputer[] AllRailways => allRailways;

    private SplineComputer mainRailway;
    public SplineComputer MainRailway => mainRailway;

    public SplineComputer GetNewRailway(SwipeData swipeData, ref int activeIndex)
    {
        switch (swipeData.Direction)
        {
            case SwipeDirection.Left:
                if (activeIndex > 0)
                    activeIndex--;
                break;
            case SwipeDirection.Right:
                if (activeIndex < 2)
                    activeIndex++;
                break;
        }
        return allRailways[activeIndex];
    }

    public SplineComputer CalculateMainRailway()
    {
        Debug.Log("<color=red>CalculateMainRailway</color>");
        mainRailway = allRailways[0];
        foreach(var railway in allRailways)
        {
            if (railway.CalculateLength() > mainRailway.CalculateLength())
                mainRailway = railway;
        }

        return mainRailway;
    }

    public bool IsSwitchValid(double newPercent)
    {
        return (newPercent > 0 && newPercent < 1);
    }
}
