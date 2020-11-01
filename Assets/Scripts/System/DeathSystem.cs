using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Dreamteck.Splines;
using TMPro;
using UnityEngine;

public class DeathSystem : MonoBehaviour
{
    private SplineFollower[] _splineFollowers;
    
    private void Start()
    {
        _splineFollowers = FindObjectsOfType<SplineFollower>();
    }
    
    private void Update()
    {
        var sortedSplineFollowers = SortPlayersByProgress();

        if (sortedSplineFollowers.Length != 0)
        {
            DeathPlayer(sortedSplineFollowers);
        }
    }

    private SplineFollower[] SortPlayersByProgress()
    {
        return _splineFollowers.Where(player => player.result.percent - 1 >= 0)
            .ToArray();
    }

    private static void DeathPlayer(SplineFollower[] sortedSplineFollowers)
    {
        foreach (SplineFollower splineFollower in sortedSplineFollowers)
        {
            if (splineFollower.name.Equals(GameConstants.TagPlayer))
            {
                Observer.Instance.CallOnLoseLevel(); 
            }
            else
            {
                splineFollower.gameObject.SetActive(false);
            }

        }
        
    }
    
}