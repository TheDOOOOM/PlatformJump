using Screens;
using Services;
using UnityEngine;
using UnityEngine.UI;


public class GameScreen : BaseScreen
{
    [SerializeField] private LevelsData _levelsData;
    [SerializeField] private DistanceCounter _distanceCounter;
    [SerializeField] private GravityImage _gravityImage;
    [SerializeField] private MoveButton _moveLeft;
    [SerializeField] private MoveButton _moveRight;
    [SerializeField] private Button _gravitySwitch;
    [SerializeField] private Button _jumpButton;
    [SerializeField] private CollectionCounter _collectionCounter;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private AchigmentManager _achigmentManager;
    private GameLevel _gameLevelinstance;
    private PlayerMove _playerMove;
    private LevelStats _levelStats;

    public override void Init()
    {
        _achigmentManager = ServiceLocator.Instance.GetService<AchigmentManager>();
        _gameLevelinstance = Instantiate(_levelsData.GetLevelConfig().GetLevelPrefab());
        _gameLevelinstance.SetCounter(_collectionCounter);
        _playerMove = _gameLevelinstance.Player.InitStabncePlayer();
        _distanceCounter.SetData(_gameLevelinstance.GameEndPoint, _playerMove.transform);
        CreateStats();
        SetMovementButtonPlauer();
        AddSubscription();
        base.Init();
        AudioManager.PlayGame();
    }

    private void CreateStats()
    {
        _levelStats = new LevelStats();
        _levelStats.StartScoreAdd();
    }

    private void SetMovementButtonPlauer()
    {
        _moveLeft.SetPlayerMove(_playerMove);
        _moveRight.SetPlayerMove(_playerMove);
    }

    private void AddSubscription()
    {
        _gravitySwitch.onClick.AddListener(_playerMove.GravityController.SwitchGravity);
        _gravitySwitch.onClick.AddListener(_levelStats.AddGravitySwitch);
        _jumpButton.onClick.AddListener(_playerMove.Jump);
        _jumpButton.onClick.AddListener(_levelStats.AddJumps);
        _playerMove.GravityController.GravitySwitch += _gravityImage.SetImage;
        _distanceCounter.GameEnd += GameOverScreenOpen;
    }

    private void GameOverScreenOpen()
    {
        _levelsData.GetLevelConfig().SetStars(_levelStats.Jumps, _levelStats.GrawvitySwitch, _levelStats.Score);
        var gameOverInstance = Instantiate(_gameOverScreen, transform);
        gameOverInstance.Init(_levelsData, _levelStats);
        _gameLevelinstance.Player.DelitedPlayer();
        _gameLevelinstance.Destroy();
        CheckCompliteAchigment();
        AudioManager.PlayMenuMusick();
    }

    private void CheckCompliteAchigment()
    {
        if (_levelsData.LevelConfig.LevelIndex == 0)
        {
            _achigmentManager.FirsLevelComplite();
        }

        if (_levelStats.GrawvitySwitch > 5)
        {
            _achigmentManager.GravityMasterComplited();
        }

        if (_levelStats.GrawvitySwitch == 0)
        {
            _achigmentManager.TopGunComplited();
        }

        if (_levelStats.Jumps <= 5)
        {
            _achigmentManager.PerfectPathComplited();
        }
    }

    public override void Сlose()
    {
        _gravitySwitch.onClick.RemoveListener(_playerMove.GravityController.SwitchGravity);
        _playerMove.GravityController.GravitySwitch -= _gravityImage.SetImage;
        _distanceCounter.GameEnd -= GameOverScreenOpen;
        _levelStats.Close();
        _levelStats = null;
        base.Сlose();
    }
}