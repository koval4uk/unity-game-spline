using Dreamteck.Splines;
using TMPro;
using UnityEngine;

public class PositionSystem : MonoBehaviour
{
    private const string FirstPlace = "1";
    private const string SecondPlace = "2";
    
    [SerializeField] private SplineFollower player;
    [SerializeField] private TextMeshPro playerPositionBoard;

    [SerializeField] private SplineFollower enemy;
    [SerializeField] private TextMeshPro enemyPositionBoard;


    private void Update()
    {
        if (player.result.percent > enemy.result.percent)
        {
            playerPositionBoard.SetText(FirstPlace);
            enemyPositionBoard.SetText(SecondPlace);
        }
        else
        {
            playerPositionBoard.SetText(SecondPlace);
            enemyPositionBoard.SetText(FirstPlace);
        }
    }
}