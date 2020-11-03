using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour, IModificator
{
    //[SerializeField] private GameObject model;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
