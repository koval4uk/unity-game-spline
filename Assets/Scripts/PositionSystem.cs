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
        //  FindObjectsOfType<SplineFollower>()[1].gameObject.GetComponentInChildren<TextMeshPro>()
    }
    
    private void Update()
    {
        BigInteger numberInRace = 1;
        var sortedSplineFollowers = sortPlayersByProgress();
        updatePositionForPlayer(sortedSplineFollowers, numberInRace);
    }

    private void updatePositionForPlayer(SplineFollower[] sortedSplineFollowers, BigInteger numberInRace)
    {
        sortedSplineFollowers
            .Select(player =>
            {
                TextMeshPro textMeshPro = player.gameObject.GetComponentInChildren<TextMeshPro>();
                textMeshPro.SetText(numberInRace++.ToString());
                return true;
            })
            .ToArray();
    }

    private SplineFollower[] sortPlayersByProgress()
    {
        return _splineFollowers.OrderBy(splineFollower => -splineFollower.result.percent)
                .ToArray();
    }
}