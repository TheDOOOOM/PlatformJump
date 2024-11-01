using _PlatformJump._Screpts;
using _PlatformJump._Screpts.Screens.Settings;
using Screens;
using Services;
using UnityEngine;

public class DialogLauncher : MonoBehaviour, IService
{
    [SerializeField] private LoadingWindow _loaderScreen;
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    // [SerializeField] private GameScreen _gameScreen;

    // [SerializeField] private AudioManager _audioManager;

    private BaseScreen _activeScreen;

    private void Awake()
    {
        ServiceLocator.Init();
        ServiceLocator.Instance.AddService(this);
    }

    private void Start() => ShowScreen(_loaderScreen);

    public void ShowMenuScreen() => ShowScreen(_menuScreen);

    //
    // public void ShowBackgroundScreen() => ShowScreen(_backgroundScreen);
    //
    // public void ShowEnhancementScreen() => ShowScreen(_enhancementScreen);
    //
    public void ShowSettingsScreen() => ShowScreen(_settingsScreen);
    //
    // public void ShowGameScreen() => ShowScreen(_gameScreen);


    private void ShowScreen(BaseScreen screen)
    {
        _activeScreen?.Сlose();
        var instanceScreen = Instantiate(screen, transform);
        instanceScreen.Init();
        _activeScreen = instanceScreen;
    }
}