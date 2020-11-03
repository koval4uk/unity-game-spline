using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, IModificator
{
<<<<<<< HEAD
    //[SerializeField] private GameObject model;
    private Animator animator;
    private ParticleSystem warpEffect;

    private void Start()
    {
        animator = GetComponent<Animator>();
        warpEffect = EffectsHolder.Instance.warpVFX.GetComponent<ParticleSystem>();
=======
    [SerializeField] private GameObject model;

    private void Start()
    {
>>>>>>> 0984237fe4b90ca255aebb3eda32a8fc8bd344ad
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

        yield return new WaitForSeconds(GameConstants.nitroTime);
        stickmanEvents.OnMultiplySpeed(1f);
    }

    private void DestroyAnimation()
    {
        //model.SetActive(false);
        animator.SetTrigger("OnDestroy");
    }
}
