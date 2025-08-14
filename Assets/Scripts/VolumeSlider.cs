using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider), typeof(VolumeChanger))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    private Slider _slider;
    private VolumeChanger _volumeChanger;

    public Action<AudioMixerGroup, float> Changed;

    public float MinValue => _slider.minValue;
    public float MaxValue => _slider.maxValue;
    public float Value => _slider.value;

    private void Awake()
    {
        _volumeChanger = GetComponent<VolumeChanger>();
        _slider = GetComponent<Slider>();
        _slider.minValue = 0.0001f;
        _slider.maxValue = 1f;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        _volumeChanger.ChangeVolume(_mixerGroup, volume);
    }
}
