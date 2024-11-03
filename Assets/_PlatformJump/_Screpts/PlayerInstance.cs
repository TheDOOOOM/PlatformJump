using Services;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerPrefab;
    [SerializeField] private Transform _instancePoint;

    private CameraFollow _cameraFollow;
    private PlayerMove _playerMove;

    public PlayerMove InitStabncePlayer()
    {
        _playerMove = Instantiate(_playerPrefab);
        _cameraFollow = ServiceLocator.Instance.GetService<CameraFollow>();
        _playerMove.transform.position = _instancePoint.position;
        _cameraFollow.SetTarget(_playerMove.transform);
        return _playerMove;
    }

    public void DelitedPlayer()
    {
        Destroy(_playerMove.gameObject);
    }
}