using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody trolleyRigidbody;
    [SerializeField] private Rigidbody stickmanRigidbody;
    
    private EnemyAnimationEvents enemyAnimationEvents;
    private SplineFollower follower;
    private Animator animator;
    private Vector3 trolleyPushDirection = new Vector3(0.0f, -.5f, 1.0f);
    private Vector3 stickmanPushDirection = new Vector3(0.0f, -.1f, .5f);
    private float trolleyPushForce = 10.0f;
    private float stickmanPushForce = 3.0f;
    private int dieHash = Animator.StringToHash("Die");

    private void Awake()
    {
        CacheComponents();
    }

    private void OnEnable()
    {
        enemyAnimationEvents.OnKickFromBehind += GetKickedFromBehind;
        enemyAnimationEvents.OnKickLeft += GetKickedFromLeft;
        enemyAnimationEvents.OnKickRight += GetKickedFromRight;
        enemyAnimationEvents.FallDown += FallDown;
        enemyAnimationEvents.FallDown += delegate { StartCoroutine(Deactivate()); };
    }

    private void CacheComponents()
    {
        enemyAnimationEvents = GetComponent<EnemyAnimationEvents>();
        follower = GetComponent<SplineFollower>();
        animator = GetComponentInChildren<Animator>();
    }

    private void GetKickedFromBehind()
    {
        follower.follow = false;
        transform.DOMove(transform.position + transform.up * 8, 0.5f);
    }

    private void GetKickedFromLeft()
    {
        follower.follow = false;
        transform.DOMove(transform.position - transform.right * 8, 0.5f);
        transform.DORotateQuaternion(Quaternion.LookRotation(transform.forward, -transform.right), 0.5f);
    }

    private void GetKickedFromRight()
    {
        follower.follow = false;
        transform.DOMove(transform.position + transform.right * 8, 0.5f);
        transform.DORotateQuaternion(Quaternion.LookRotation(transform.forward, transform.right), 0.5f);
    }

    private void FallDown()
    {
        animator.SetTrigger(dieHash);
        AnimateTrolley();
        AnimateStickman();
    }

    private void AnimateTrolley()
    {
        trolleyRigidbody.useGravity = true;
        trolleyRigidbody.isKinematic = false;
        trolleyRigidbody.AddForce(trolleyPushDirection * trolleyPushForce, ForceMode.Impulse);
    }

    private void AnimateStickman()
    {
        stickmanRigidbody.useGravity = true;
        stickmanRigidbody.isKinematic = false;
        stickmanRigidbody.AddForce(stickmanPushDirection * stickmanPushForce, ForceMode.Impulse);
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(4.0f);
    }

}
