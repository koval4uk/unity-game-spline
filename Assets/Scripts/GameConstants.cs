using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour
{
    public const string PrefsCurrentLevel = "currentLevel";
    public const string TagObstacle = "Obstacle";
    public const string TagRailModificator = "RailModificator";

    public const float PlayerStartMovementSpeed = 2.0f;
    public const float PlayerLimitMovementSpeed = 28.0f;
    public const float PlayerIncreaseSpeedStep = .45f;

    public const float nitroMultiplier = 1.5f;
    public const float nitroTime = 2.5f;
}