using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimationEvents : MonoBehaviour
{
    public Action OnRailwayEnd = delegate { Debug.Log("OnRailwayEnd Triggered!"); };
}
