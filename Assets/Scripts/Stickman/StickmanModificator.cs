using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class StickmanModificator : MonoBehaviour
{
    [SerializeField] private GameObject nitro;
    private CinemachineVirtualCamera camera;
    
    private StickmanEvents stickmanEvents;

    private void Awake()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
        camera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        stickmanEvents.OnNitroAnimation += NitroAnimation;
    }

    private void NitroAnimation()
    {
        nitro.SetActive(true);
        camera.m_Lens.FieldOfView = 60;
    }

}
