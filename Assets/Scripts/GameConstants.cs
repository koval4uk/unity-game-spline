using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour
{
    public const string PrefsCurrentLevel = "currentLevel";
    public const string TagObstacle = "Obstacle";
    public const string TagRailModificator = "RailModificator";
    public const string TagModificator = "Modificator";
    public const string TagPlayer = "Player";
    public const string TagFinish = "Finish";
    public const string TagMainProjector = "MainProjector";
    public const string TagEdge = "Edge";
    public const string TagTeeterSwitcher = "TeeterSwitcher";

    public const float PlayerStartMovementSpeed = 2.0f;
    public const float PlayerLimitMovementSpeed = 28.0f;
    public const float PlayerIncreaseSpeed = 1.5f;
    public const float PlayerDecreaseSpeed = -2.2f;
    public const float PlayerMinSpeed = 9.0f;

    public const float nitroMultiplier = 1.5f;
    public const float nitroTime = 2.5f;
    
    public const int ChanceToDodge = 100;
    public const float DodgeCooldown = .1f;
    public const float SwitchRailwayTime = 0.15f;
}