using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, IObstacle
{
    [SerializeField] private ParticleSystem warpEffect;
    [SerializeField] private GameObject model;

    public void Initiate(StickmanEvents stickmanEvents)
    {
        StartCoroutine(Effect(stickmanEvents));
        DestroyAnimation();
    }

    private IEnumerator Effect(StickmanEvents stickmanEvents)
    {
        stickmanEvents.OnMultiplySpeed(GameConstants.nitroMultiplier);
        stickmanEvents.OnNitroAnimation();
        warpEffect.Play();
        yield return new WaitForSeconds(GameConstants.nitroTime);
        stickmanEvents.OnMultiplySpeed(1f);
        warpEffect.Stop();
    }

    private void DestroyAnimation()
    {
        model.SetActive(false);
    }
}
