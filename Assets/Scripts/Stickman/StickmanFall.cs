using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanFall : MonoBehaviour
{
    private StickmanEvents stickmanEvents;
    private Rigidbody rigidbody;
    private float pushForce = 5.0f;

    private void Awake()
    {
        CacheComponents();
    }
    
    private void OnEnable()
    {
        stickmanEvents.OnRailwayEnd += ActivatePhysics;
    }
    
    private void CacheComponents()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void ActivatePhysics()
    {
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.useGravity = true;
        //rigidbody.AddRelativeForce(Vector3.forward * pushForce, ForceMode.Impulse);
    }
}
