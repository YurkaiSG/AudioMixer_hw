using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(VolumeChanger), typeof(Button))]
public class SoundMuter : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private VolumeSlider _slider;
    private VolumeChanger _volumeChanger;
    private Button _button;
    private bool _isMuted = false;

    private void Awake()
    {
        _volumeChanger = GetComponent<VolumeChanger>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(MuteSound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(MuteSound);
    }

    private void MuteSound()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
            _volumeChanger.ChangeVolume(_mixerGroup, _slider.MinValue);
        else
            _volumeChanger.ChangeVolume(_mixerGroup, _slider.Value);
    }
}
