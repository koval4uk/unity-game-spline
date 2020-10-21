using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IObstacle
{
    public void Initiate(PlayerEvents playerEvents)
    {
        playerEvents.OnChangeSpeed(2.0f);
        DestroyAnimation();
    }

    private void DestroyAnimation()
    {
        // Beatiful animation
        gameObject.SetActive(false);
    }
}
