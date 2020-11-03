using System;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using Singleton;
using UnityEngine;

public class PositionSystem : Singleton<PositionSystem>
{
    private string[] allPositionLetters = new string[]
    {
        "st",
        "nd",
        "rd",
        "th",
        "th",
        "th",
        "th",
        "th",
        "th",
        "th"
    };

    private List<SplineProjector> splineProjectors;
    private int currentPositionIndex;
    
    private void Start()
    {
        splineProjectors = FindObjectsOfType<SplineProjector>()
            .ToList()
            .ConvertAll(splineProjector => {
                    splineProjector.spline = RailwaysManager.Instance.MainRailway;
                    return splineProjector;
            })
            .ToList();
    }
    
    public int GetPlayerPositionNumber()
    {
        int indexPlayerAmongAllProjectors = splineProjectors
            .ConvertAll(splineProjector =>
            {
                splineProjector.spline = RailwaysManager.Instance.MainRailway;
                return splineProjector;
            })
            .OrderBy(player => -player.result.percent)
            .ToList()
            .FindIndex(projector => projector.name == GameConstants.TagPlayer);
        currentPositionIndex = indexPlayerAmongAllProjectors;
        return ++indexPlayerAmongAllProjectors;
    }

    public string GetPositionLetter()
    {
        return allPositionLetters[currentPositionIndex];
    }
    
}