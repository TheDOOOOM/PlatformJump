using _PlatformJump._Screpts;
using _PlatformJump._Screpts.Screens;
using _PlatformJump._Screpts.Screens.Settings;
using Screens;
using Services;
using UnityEngine;

public class DialogLauncher : MonoBehaviour, IService
{
    [SerializeField] private LoadingWindow _loaderScreen;
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private SelectLevelScreen _selectLevelScreen;
    [SerializeField] private AchigmentsScreen _achigmentsScreen;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private CameraFollow _cameraFollow;


    private BaseScreen _activeScreen;

    private void Awake()
    {
        ServiceLocator.Init();
        ServiceLocator.Instance.AddService(this);
        ServiceLocator.Instance.AddService(_audioManager);
        ServiceLocator.Instance.AddService(_cameraFollow);
    }

    private void Start() => ShowScreen(_loaderScreen);

    public void ShowMenuScreen() => ShowScreen(_menuScreen);

    public void ShowSelectLevel() => ShowScreen(_selectLevelScreen);

    public void ShowSettingsScreen() => ShowScreen(_settingsScreen);

    public void ShowAchigmentsScreen() => ShowScreen(_achigmentsScreen);
    public void ShowGameScreen() => ShowScreen(_gameScreen);


    private void ShowScreen(BaseScreen screen)
    {
        _activeScreen?.Сlose();
        var instanceScreen = Instantiate(screen, transform);
        instanceScreen.Init();
        _activeScreen = instanceScreen;
    }
}