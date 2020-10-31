using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Object = System.Object;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera camera;

    private void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        Observer.Instance.OnWinLevel += StopFollow;
    }

    private void StopFollow()
    {
        camera.Follow = null;
    }
}
