using System;
using System.Linq;
using System.Numerics;
using Dreamteck.Splines;
using TMPro;
using UnityEngine;

public class PositionSystem : MonoBehaviour
{

    private SplineFollower[] _splineFollowers;
    
    private void Start()
    {
        _splineFollowers = FindObjectsOfType<SplineFollower>();
    }
    
    private void Update()
    {
        var sortedSplineFollowers = SortPlayersByProgress();
        UpdatePositionForPlayer(sortedSplineFollowers);
    }

    private SplineFollower[] SortPlayersByProgress()
    {
        return _splineFollowers.OrderBy(player => -player.result.percent)
            .ToArray();
    }

    private static void UpdatePositionForPlayer(SplineFollower[] sortedSplineFollowers)
    {
        BigInteger initNumberInRace = 1;
        
        Array.ForEach(sortedSplineFollowers, splineFollower =>
            {
                var textMeshPro = splineFollower.gameObject.GetComponentInChildren<TextMeshPro>();
                textMeshPro.SetText(initNumberInRace++.ToString());
            });
    }
    
}