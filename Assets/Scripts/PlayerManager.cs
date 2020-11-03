using System;
using System.Collections;
using System.Collections.Generic;
using Singleton;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    private StickmanEvents stickmanEvents;

    private void Awake()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
    }

    private void OnEnable()
    {
        stickmanEvents.OnFinish += Finish;
    }

    private void Finish()
    {
        Observer.Instance.CallOnWinLevel();
    }
}
