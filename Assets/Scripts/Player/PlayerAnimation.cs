using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines;

public class PlayerAnimation : MonoBehaviour
{
    private StickmanEvents stickmanEvents;
    private Animator animator;
    private Rigidbody rigidbody;
    private ParticleSystem warpEffect;
    private int teeterHash = Animator.StringToHash("isTeeter");
    private int raiseHandsHash = Animator.StringToHash("isRaiseHands");
    private int dieHash = Animator.StringToHash("Die");
    private bool isHighSpeed, isRaiseHands, isTeeter;
    private float pushForce = 15.0f;

    private void Awake()
    {
        CacheComponents();
    }

    private void OnEnable()
    {
        stickmanEvents.OnRailwayEnd += FallDown;
        stickmanEvents.OnTeeterSwitch += SwitchTeeter;
        stickmanEvents.OnHighSpeedReached += ActivateHighSpeed;
        stickmanEvents.OnSlowSpeed += DeactivateHighSpeed;
        stickmanEvents.OnNitroAnimation += RaiseHands;
    }

    private void Update()
    {
        CheckWarpEffect();
    }

    private void CacheComponents()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
        animator = GetComponentInChildren<Animator>();
        warpEffect = EffectsHolder.Instance.warpVFX.GetComponent<ParticleSystem>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void SwitchTeeter()
    {
        Debug.Log("<color=blue>SwitchTeeter</color>");
        isTeeter = !isTeeter;
        animator.SetBool(teeterHash, isTeeter);
    }

    private void ActivateHighSpeed()
    {
        if(isRaiseHands)
            return;
        
        isHighSpeed = true;
        animator.SetBool(raiseHandsHash, isHighSpeed);
    }
    
    private void DeactivateHighSpeed()
    {
        if(isRaiseHands)
            return;
        
        isHighSpeed = false;
        animator.SetBool(raiseHandsHash, isHighSpeed);
    }

    private void RaiseHands()
    {
        animator.SetBool(raiseHandsHash, true);
        StartCoroutine(RaiseHandsDelay());
    }

    private IEnumerator RaiseHandsDelay()
    {
        isRaiseHands = true;
        yield return new WaitForSeconds(1.5f);
        isRaiseHands = false;
    }

    private void CheckWarpEffect()
    {
        if (isHighSpeed && !warpEffect.isPlaying)
        {
            warpEffect.Play();
            
            Debug.Log("<color=red>Play Warp Effect!</color>");
        }
        else if(!isHighSpeed && warpEffect.isPlaying)
        {
            Debug.Log("<color=red>Stop Warp Effect!</color>");
            warpEffect.Stop();
        }
    }
    
    private void FallDown()
    {
        Observer.Instance.CallOnLoseLevel();
        animator.SetTrigger(dieHash);
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.useGravity = true;
        rigidbody.AddRelativeForce(Vector3.forward * pushForce, ForceMode.Impulse);
    }
}
