using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerPositionText;

    private void Update()
    {
        if(GameStarter.IsGameStarted)
            playerPositionText.SetText(PositionSystem.Instance.GetPlayerPosition().ToString());
    }
}
