using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAnimationEvents : MonoBehaviour
{
    public Action OnKickRight = delegate { Debug.Log("OnKickRight Triggered!"); };
    public Action OnKickLeft = delegate { Debug.Log("OnKickLeft Triggered!"); };
    public Action OnKickFromBehind = delegate { Debug.Log("OnKickFromBehind Triggered!"); };

    public Action OnTurnRight = delegate { Debug.Log("OnTurnRight Triggered!"); };
    public Action OnTurnLeft = delegate { Debug.Log("OnTurnLeft Triggered!"); };
    
    public Action FallDown = delegate { Debug.Log("FallDown Triggered!"); };
}
