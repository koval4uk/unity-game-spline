using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using System.Linq;

public class MainProjector : MonoBehaviour
{
    private SplineProjector splineProjector;

    private void Awake()
    {
        Debug.Log($"<color=red>Awake Main Projector in gameobject {gameObject.name}</color>");
        RailwaysManager.Instance.CalculateMainRailway();
        splineProjector = GetComponent<SplineProjector>();
        splineProjector.spline = FindObjectsOfType<SplineComputer>()
            .First(c => c.name.Equals("Middle"));
    }
}
