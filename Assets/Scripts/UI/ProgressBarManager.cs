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
    private SplineProjector projector;

    private void Start()
    {
        projector = PlayerManager.Instance.GetComponent<SplineProjector>();
    }
    
    private void Update()
    {
        projector.spline = RailwaysManager.Instance.MainRailway;
        bar.fillAmount = Convert.ToSingle(projector.result.percent);        
    }
}
