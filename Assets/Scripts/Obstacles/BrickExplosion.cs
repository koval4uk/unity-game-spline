using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExplosion : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float explodePower = 10.0f;
    private float explodeRadius = 5.0f;
    private float explodeUpForce = 2.0f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Explode(Vector3 explodePosition)
    {
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(explodePower, explodePosition, explodeRadius, explodeUpForce, ForceMode.Impulse);
    }
}
