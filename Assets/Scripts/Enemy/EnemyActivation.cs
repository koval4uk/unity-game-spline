using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DelayActivationType
{
    NoDelay,
    DelayByTime,
    DelayByTrigger
}
public class EnemyActivation : MonoBehaviour
{
    public DelayActivationType delayType;
    public float delayTime;
}
