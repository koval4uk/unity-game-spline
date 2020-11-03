using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerPositionNumberText;
    [SerializeField] private TextMeshProUGUI playerPositionNumberLetter;

    private void Update()
    {
        if (!GameStarter.IsGameStarted)
            return;
        
        SetPositionText();
    }

    private void SetPositionText()
    {
        playerPositionNumberText.SetText(PositionSystem.Instance.GetPlayerPositionNumber().ToString());
        playerPositionNumberLetter.SetText(PositionSystem.Instance.GetPositionLetter());
    }
}
