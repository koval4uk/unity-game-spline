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
    private int originCameraFOV = 40;
    private int destCameraFOV = 60;
    private float pastTime = 0;

    private void Awake()
    {
        stickmanEvents = GetComponent<StickmanEvents>();
        camera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        stickmanEvents.OnNitroAnimation += delegate { StartCoroutine(NitroAnimation()); };
    }

    private IEnumerator NitroAnimation()
    {
        nitro.SetActive(true);
        if (stickmanEvents.IsPlayer)
        {
            while (camera.m_Lens.FieldOfView < destCameraFOV)
            {
                yield return new WaitForFixedUpdate();
                float step = Time.fixedDeltaTime * 24;
                pastTime += Time.fixedDeltaTime;
                camera.m_Lens.FieldOfView += step;
            }
            float difference = GameConstants.nitroTime - pastTime;
            yield return new WaitForSeconds(difference);
            while (camera.m_Lens.FieldOfView > originCameraFOV)
            {
                yield return new WaitForFixedUpdate();
                float step = Time.fixedDeltaTime * 24;
                camera.m_Lens.FieldOfView -= step;
            }
            nitro.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(GameConstants.nitroTime);
            nitro.SetActive(false);
        }
    }

}
