using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Singleton;
using UnityEngine;

public class RailwaysManager : Singleton<RailwaysManager>
{
    [SerializeField] private SplineComputer[] allRailways;
    private int activeRailwayIndex = 1;

    public SplineComputer GetActiveRailway(SwipeData swipeData)
    {
        switch (swipeData.Direction)
        {
            case SwipeDirection.Left:
                if (activeRailwayIndex > 0)
                    activeRailwayIndex--;
                break;
            case SwipeDirection.Right:
                if (activeRailwayIndex < 2)
                    activeRailwayIndex++;
                break;
        }
        return allRailways[activeRailwayIndex];
    }
}
