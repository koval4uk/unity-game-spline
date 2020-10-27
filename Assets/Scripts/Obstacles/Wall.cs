using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Wall : MonoBehaviour, IObstacle
{
    private BrickExplosion[] allBricks;
    
    private void Awake()
    {
        allBricks = GetComponentsInChildren<BrickExplosion>();
    }

    public void Initiate(StickmanEvents stickmanEvents)
    {
        stickmanEvents.OnChangeSpeed(2.0f);
        StartCoroutine(DestroyAnimation(stickmanEvents.transform.position));
    }

    private IEnumerator DestroyAnimation(Vector3 explodePosition)
    {
        Debug.Log("Destroy Animation");
        foreach (var brick in allBricks)
        {
            brick.Explode(explodePosition);
        }
        yield return new WaitForSeconds(4.0f);
        gameObject.SetActive(false);
    }
}
