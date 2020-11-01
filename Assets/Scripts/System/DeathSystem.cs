using System.Linq;
using Dreamteck.Splines;
using UnityEngine;

public class DeathSystem : MonoBehaviour
{
    private SplineFollower[] _splineFollowers;

    private void Start()
    {
        _splineFollowers = FindObjectsOfType<SplineFollower>();
    }

    private void Update()
    {
        var sortedSplineFollowers = FindFinishSplinePlayers();

        if (sortedSplineFollowers.Length != 0) DeathPlayer(sortedSplineFollowers);
    }

    private SplineFollower[] FindFinishSplinePlayers()
    {
        return _splineFollowers.Where(player => player.result.percent - 1 >= 0)
            .ToArray();
    }

    private static void DeathPlayer(SplineFollower[] sortedSplineFollowers)
    {
        foreach (var splineFollower in sortedSplineFollowers)
            if (splineFollower.name.Equals(GameConstants.TagPlayer))
                Observer.Instance.CallOnLoseLevel();
            else
                splineFollower.gameObject.SetActive(false);
    }
}