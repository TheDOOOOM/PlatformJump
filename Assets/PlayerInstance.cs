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
        var playerMove = Instantiate(_playerPrefab);
        _cameraFollow = ServiceLocator.Instance.GetService<CameraFollow>();
        playerMove.transform.position = _instancePoint.position;
        _cameraFollow.SetTarget(playerMove.transform);
        return playerMove;
    }
}