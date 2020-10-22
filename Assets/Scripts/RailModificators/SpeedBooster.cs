using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour, IRailModificator
{
    [SerializeField] private float speedBoost;

    public void Play(StickmanEvents stickmanEvents)
    {
        stickmanEvents.OnMultiplySpeed(speedBoost);
    }

    public void Stop(StickmanEvents stickmanEvents)
    {
        stickmanEvents.OnMultiplySpeed(1f);
    }
}
