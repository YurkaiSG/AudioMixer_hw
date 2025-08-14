using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(VolumeChanger))]
public class SoundMuter : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private VolumeSlider _slider;
    private VolumeChanger _volumeChanger;
    private bool _isMuted = false;

    private void Awake()
    {
        _volumeChanger = GetComponent<VolumeChanger>();
    }

    public void MuteSound()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
            _volumeChanger.ChangeVolume(_mixerGroup, _slider.MinValue);
        else
            _volumeChanger.ChangeVolume(_mixerGroup, _slider.Value);
    }
}
