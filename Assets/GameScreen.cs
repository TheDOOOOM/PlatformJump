using Screens;
using Services;
using UnityEngine;
using UnityEngine.UI;


public class GameScreen : BaseScreen
{
    [SerializeField] private GameLevel _gameLevel;
    [SerializeField] private DistanceCounter _distanceCounter;
    [SerializeField] private GravityImage _gravityImage;
    [SerializeField] private MoveButton _moveLeft;
    [SerializeField] private MoveButton _moveRight;
    [SerializeField] private Button _gravitySwitch;
    [SerializeField] private Button _jumpButton;
    [SerializeField] private CollectionCounter _collectionCounter;

    private GameLevel _gameLevelinstance;
    private PlayerMove _playerMove;

    public override void Init()
    {
        ServiceLocator.Instance.AddService(_collectionCounter);
        _gameLevelinstance = Instantiate(_gameLevel);
        _playerMove = _gameLevelinstance.Player.InitStabncePlayer();
        Debug.Log(_playerMove);
        _moveLeft.SetPlayerMove(_playerMove);
        _moveRight.SetPlayerMove(_playerMove);
        _gravitySwitch.onClick.AddListener(_playerMove.GravityController.SwitchGravity);
        _jumpButton.onClick.AddListener(_playerMove.Jump);
        _playerMove.GravityController.GravitySwitch += _gravityImage.SetImage;
        Debug.Log(_gameLevelinstance.Player.transform);
        _distanceCounter.SetData(_gameLevelinstance.GameEndPoint, _playerMove.transform);
        base.Init();
    }

    public override void Сlose()
    {
        _gravitySwitch.onClick.RemoveListener(_playerMove.GravityController.SwitchGravity);
        _playerMove.GravityController.GravitySwitch -= _gravityImage.SetImage;
        base.Сlose();
    }
}