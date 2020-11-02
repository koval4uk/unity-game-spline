using System;
using System.Linq;
using Dreamteck.Splines;
using UnityEngine;

public class PositionSystem : MonoBehaviour
{
    
    private SplineProjector[] splineProjectors;
    
    private void Start()
    {
        splineProjectors = FindObjectsOfType<SplineProjector>()
            .Where(c => c.CompareTag(GameConstants.TagMainProjector))
            .ToList()
            .ConvertAll(splineProjector => {
                    splineProjector.spline = RailwaysManager.Instance.MainRailway;
                    return splineProjector;
            })
            .ToArray();
    }
    
    public int GetPlayerPosition()
    {
        int indexPlayerAmongAllProjectors = splineProjectors
            .OrderBy(player => -player.result.percent)
            .ToList()
            .FindIndex(projector => projector.name == "PlayerPosition");
        
        return ++indexPlayerAmongAllProjectors;
    }

}