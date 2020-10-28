using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Splines;

public class ProgressBarManager : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private SplineFollower follower;

    private void Start()
    {
        follower = FindObjectsOfType<SplineFollower>()
            .First(c => c.name.Equals("Player"));
    }
    
    private void Update()
    {
        bar.fillAmount = Convert.ToSingle(follower.result.percent);        
    }
}
