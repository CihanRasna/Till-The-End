using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public CinemachineVirtualCamera secondCam;
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera startCam;

    private float elapsedTime = 0f;
    private void Start()
    {
        startCam.Priority = 11;
        secondCam.Priority = 10;
        mainCam.Priority = 9;
        
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (elapsedTime >= 1.3f)
        {
            secondCam.Priority = 11;
            startCam.Priority = 8;
        }
        if (elapsedTime >= 3.2f)
        {
            mainCam.Priority = 11;
            secondCam.Priority = 9; 
        }
    }
}


//////////////////////////FOR SHAKE///////////////////////////////
///
/// // public float shakeDuration = 1f;
// public float shakeAmplitude = 1f;
// public float shakeFrequency = 1f;
//
// private float shakeElapsedTime = 0f;
//
// //Shake
//
// public CinemachineVirtualCamera cm;
// private CinemachineBasicMultiChannelPerlin noise;
//
// private void Start()
// {
//     if (cm != null)
//     {
//         noise = cm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
//     }
// }
//
// private void Update()
// {
//     if (PlayerManager.isGameLose)
//     {
//         shakeElapsedTime = shakeDuration;
//     }
//     // If Camera Shake effect is still playing
//     if (shakeElapsedTime > 0)
//     {
//         // Set Cinemachine Camera Noise parameters
//         noise.m_AmplitudeGain = shakeAmplitude;
//         noise.m_FrequencyGain = shakeFrequency;
//
//         // Update Shake Timer
//         shakeElapsedTime -= Time.deltaTime;
//     }
//     else
//     {
//         // If Camera Shake effect is over, reset variables
//         noise.m_AmplitudeGain = 0f;
//         shakeElapsedTime = 0f;
//     }
// }
