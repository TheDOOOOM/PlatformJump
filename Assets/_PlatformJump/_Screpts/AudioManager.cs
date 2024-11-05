using System;
using _PlatformJump._Screpts.SO;
using UnityEngine;

public class AudioManager : MonoBehaviour, IService
{
    [SerializeField] private AudioSource _gameSource;
    [SerializeField] private AudioSource _menuSource;
    [SerializeField] private SounConfig _sounConfig;
    [SerializeField] private AudioSource _buttonSound;

    public float SoundValue => _sounConfig.ValueSound;
    public float MusickValue => _sounConfig.ValueMusick;

    private void Start()
    {
        SetSoundValue();
        SetSound();
    }

    public void SetMusick(float value)
    {
        _sounConfig.SetMuscikValue(value);
        _gameSource.volume = value;
        _menuSource.volume = value;
    }

    public void SetSound(float value)
    {
        _sounConfig.SetMuscikValue(value);
        _buttonSound.volume = value;
    }

    public void PlayButtonClick()
    {
        _buttonSound.Play();
    }

    public void PlayMenuMusick()
    {
        _menuSource.Play();
        _gameSource.Stop();
    }

    public void PlayGame()
    {
        _menuSource.Stop();
        _gameSource.Play();
    }

    private void SetSoundValue()
    {
        _gameSource.volume = _sounConfig.ValueMusick;
        _menuSource.volume = _sounConfig.ValueMusick;
    }

    private void SetSound()
    {
        _buttonSound.volume = _sounConfig.ValueSound;
    }
}