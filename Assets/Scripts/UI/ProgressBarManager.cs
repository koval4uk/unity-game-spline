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
    [SerializeField] private SplineProjector projector;

    private void Start()
    {
        RailwaysManager.Instance.CalculateMainRailway();
        projector = FindObjectsOfType<SplineProjector>()
            .First(c => c.name.Equals("Player"));
    }
    
    private void Update()
    {
        projector.spline = RailwaysManager.Instance.MainRailway;
        bar.fillAmount = Convert.ToSingle(projector.result.percent);        
    }
}
