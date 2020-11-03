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
    private SplineFollower follower;
    private ParticleSystem warpEffect;
    private int teeterHash = Animator.StringToHash("isTeeter");
    private bool isHighSpeed;

    private void Awake()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
        animator = GetComponentInChildren<Animator>();
        follower = GetComponent<SplineFollower>();
        warpEffect = EffectsHolder.Instance.warpVFX.GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        stickmanEvents.OnRailwayEnd += delegate
        {
            FallDown();
            Invoke(nameof(CallOnLoseLevel), 1f);
        };
        stickmanEvents.OnTeeterAnimate += ActivateTeeter;
        stickmanEvents.OnHighSpeedReached += ActivateHighSpeed;
    }

    private void Update()
    {
        CheckWarpEffect();
    }

    private void ActivateTeeter()
    {
        animator.SetBool(teeterHash, true);
    }

    private void ActivateHighSpeed()
    {
        isHighSpeed = true;
    }
    
    private void DeactivateHighSpeed()
    {
        isHighSpeed = false;
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
        follower.follow = false;
        transform.DOMoveY(-5f, 0.5f);
        transform.DORotate(new Vector3(90f, 0f, 0f), 0.5f);
    }

    private void CallOnLoseLevel()
    {
        Observer.Instance.CallOnLoseLevel();
    }
}
