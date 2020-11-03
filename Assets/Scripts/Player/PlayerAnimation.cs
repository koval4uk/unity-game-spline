using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines;

public class PlayerAnimation : MonoBehaviour
{
    private StickmanEvents stickmanEvents;
    private SplineFollower follower;

    private void Awake()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
        follower = GetComponent<SplineFollower>();
    }

    private void OnEnable()
    {
        stickmanEvents.OnRailwayEnd += delegate
        {
            FallDown();
            Invoke(nameof(CallOnLoseLevel), 1f);
        };
    }

    private void FallDown()
    {
        follower.follow = false;
        transform.DOMoveY(-5f, 0.5f);
        transform.DORotate(new Vector3(90f, 0f, 0f), 0.5f);
    }

    private void CallOnLoseLevel()
    {
        Observer.Instance.CallOnLoseLevel();
    }
}
