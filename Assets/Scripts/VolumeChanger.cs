using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string EffectsVolume = nameof(EffectsVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const float VolumeMultiplierValue = 20f;

    [SerializeField] private AudioMixerGroup _mixer;
    private bool _isMuted = false;
    private float _minVolumeValue = 0.0001f;
    private float _maxVolumeValue = 1f;

    public void ChangeMasterVolume(float volume)
    {
        ChangeVolume(MasterVolume, volume);
    }

    public void ChangeEffectsVolume(float volume)
    {
        ChangeVolume(EffectsVolume, volume);
    }

    public void ChangeMusicVolume(float volume)
    {
        ChangeVolume(MusicVolume, volume);
    }

    public void MuteSound()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
            ChangeVolume(MasterVolume, _minVolumeValue);
        else
            ChangeVolume(MasterVolume, _maxVolumeValue);
    }

    private void ChangeVolume(string mixerGroupName, float volume)
    {
        _mixer.audioMixer.SetFloat(mixerGroupName, Mathf.Log10(volume) * VolumeMultiplierValue);
    }
}
