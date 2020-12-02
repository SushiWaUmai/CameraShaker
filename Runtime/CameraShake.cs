using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Basics;

namespace CameraShaker
{
    public static class CameraShake
    {
        public static void ShakeCamera(this CinemachineVirtualCamera cvc, float time, float amplitude = 1, float frequency = 1)
        {
            CinemachineBasicMultiChannelPerlin perlin = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlin.m_AmplitudeGain = amplitude;
            perlin.m_FrequencyGain = frequency;

            BasicTimeManager.Instance.Wait(time, () =>
            {
                perlin.m_AmplitudeGain = 0;
                perlin.m_FrequencyGain = 0;
            });
        }

        public static void ShakeCamera(this CinemachineVirtualCamera cvc, float time, float intensity) => cvc.ShakeCamera(time, intensity, intensity);
    }
}