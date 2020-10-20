using System;
using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    private SwipeDetector swipeDetector;
    
    private void Awake()
    {
        swipeDetector = GetComponent<SwipeDetector>();
    }

    private void OnEnable()
    {
        swipeDetector.OnSwipe += LogSwipe;
    }

    private void LogSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
    }
}