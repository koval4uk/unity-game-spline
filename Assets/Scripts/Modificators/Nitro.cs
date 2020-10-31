using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, IModificator
{
    [SerializeField] private GameObject model;
    private ParticleSystem warpEffect;

    private void Start()
    {
        warpEffect = EffectsHolder.Instance.warpVFX.GetComponent<ParticleSystem>();
    }

    public void Trigger(StickmanEvents stickmanEvents)
    {
        StartCoroutine(Effect(stickmanEvents));
        DestroyAnimation();
    }
    
    private IEnumerator Effect(StickmanEvents stickmanEvents)
    {
        stickmanEvents.OnMultiplySpeed(GameConstants.nitroMultiplier);
        stickmanEvents.OnNitroAnimation();
        warpEffect.Stop();

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
