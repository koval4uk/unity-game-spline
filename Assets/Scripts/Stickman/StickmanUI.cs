using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StickmanUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;

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
