using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Splines;

public class ProgressBarManager : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private SplineFollower follower;

    private void Update()
    {
        //bar.fillAmount = (float)follower.result.percent;        
    }
}
