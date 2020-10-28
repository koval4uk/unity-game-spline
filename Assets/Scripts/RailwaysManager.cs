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
    public int ActiveRailwayIndex => activeRailwayIndex;
    private SplineComputer mainRailway;
    public SplineComputer MainRailway => mainRailway;

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

    public SplineComputer CalculateMainRailway()
    {
        mainRailway = allRailways[0];
        foreach(var railway in allRailways)
        {
            if (railway.CalculateLength() > mainRailway.CalculateLength())
                mainRailway = railway;
        }

        return mainRailway;
    }
}
