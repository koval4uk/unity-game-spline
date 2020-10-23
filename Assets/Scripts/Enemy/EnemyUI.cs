using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private TextMesh textMesh;

    private StickmanEvents stickmanEvents;

    private void Awake()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
    }

    private void ChangePlace()
    {
        // Change Placement Text
    }
    
}
