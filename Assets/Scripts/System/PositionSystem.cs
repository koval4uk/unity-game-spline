using System;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using Singleton;
using UnityEngine;

public class PositionSystem : Singleton<PositionSystem>
{
    private List<SplineProjector> splineProjectors;
    
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
    
    public int GetPlayerPosition()
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
        
        return ++indexPlayerAmongAllProjectors;
    }
    
}