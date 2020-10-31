using System;
using System.Linq;
using Dreamteck.Splines;
using TMPro;
using UnityEngine;

public class PositionSystem : MonoBehaviour
{

    private SplineProjector[] _splineProjectors;
    
    private void Start()
    {
        _splineProjectors = FindObjectsOfType<SplineProjector>()
            .Where(c => c.CompareTag(GameConstants.TagMainProjector))
            .ToArray();
    }
    
    private void Update()
    {
        var sortedSplineProjectors = SortPlayersByProgress();
        UpdatePositionForPlayer(sortedSplineProjectors);
    }

    private SplineProjector[] SortPlayersByProgress()
    {
        Array.ForEach(_splineProjectors, splineProjector =>
            {
                splineProjector.spline = RailwaysManager.Instance.MainRailway;
            });
        return _splineProjectors
            .OrderBy(player => -player.result.percent)
            .ToArray();
    }

    private static void UpdatePositionForPlayer(SplineProjector[] sortedSplineProjectors)
    {
        int initNumberInRace = 1;
        
        Array.ForEach(sortedSplineProjectors, splineProjector =>
            {
                var textMeshPro = splineProjector.gameObject.GetComponentInChildren<TextMeshPro>();
                textMeshPro.SetText(initNumberInRace++.ToString());
            });
    }
    
}