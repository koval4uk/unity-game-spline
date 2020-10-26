using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, IModificator
{
    [SerializeField] private ParticleSystem warpEffect;
    [SerializeField] private GameObject model;

    public void Trigger(StickmanEvents stickmanEvents)
    {
        StartCoroutine(Effect(stickmanEvents));
        DestroyAnimation();
    }
    
    private IEnumerator Effect(StickmanEvents stickmanEvents)
    {
        stickmanEvents.OnMultiplySpeed(GameConstants.nitroMultiplier);
        stickmanEvents.OnNitroAnimation();
        if (stickmanEvents.IsPlayer)
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
