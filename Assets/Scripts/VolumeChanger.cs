using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    private const float VolumeMultiplierValue = 20f;

    public void ChangeVolume(AudioMixerGroup mixerGroup, float volume)
    {
        mixerGroup.audioMixer.SetFloat(mixerGroup.name, Mathf.Log10(volume) * VolumeMultiplierValue);
    }
}
