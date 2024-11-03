using _PlatformJump._Screpts.Screens.Settings;
using Services;
using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    [SerializeField] private SettingsScreen _settingsScreen;

    private AchigmentManager _achigmentManager;
    private AudioManager _audioManager;

    private void Start()
    {
        _achigmentManager = ServiceLocator.Instance.GetService<AchigmentManager>();
        _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
    }

    public void Reset()
    {
        _audioManager.PlayButtonClick();
        _achigmentManager.ResetAll();
        _settingsScreen.ShowSettingsContent();
    }

    public void Back()
    {
        _audioManager.PlayButtonClick();
        _settingsScreen.ShowSettingsContent();
    }
}