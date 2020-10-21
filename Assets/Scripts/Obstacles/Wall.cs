using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IObstacle
{
    public void Initiate(StickmanEvents stickmanEvents)
    {
        stickmanEvents.OnChangeSpeed(2.0f);
        DestroyAnimation();
    }

    private void DestroyAnimation()
    {
        // Beautiful animation
        gameObject.SetActive(false);
    }
}
