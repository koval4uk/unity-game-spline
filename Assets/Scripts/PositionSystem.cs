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
        var sortedSplineFollowers = sortPlayersByProgress();
        updatePositionForPlayer(sortedSplineFollowers);
    }

    private SplineFollower[] sortPlayersByProgress()
    {
        return _splineFollowers.OrderBy(player => -player.result.percent)
            .ToArray();
    }

    private void updatePositionForPlayer(SplineFollower[] sortedSplineFollowers)
    {
        BigInteger initNumberInRace = 1;
        
        sortedSplineFollowers.Select(player =>
            {
                TextMeshPro textMeshPro = player.gameObject.GetComponentInChildren<TextMeshPro>();
                textMeshPro.SetText(initNumberInRace++.ToString());
                return true;
            })
            .ToArray();
    }
    
}