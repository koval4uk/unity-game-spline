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

    private int activeRailwayIndex = (int) Railways.Middle; //Start railway
    public int ActimeRailwayIndex => activeRailwayIndex;

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
