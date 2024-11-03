using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] private PlayerInstance _player;
    [SerializeField] private Transform _gameAndPoint;

    public Transform GameEndPoint => _gameAndPoint;
    public PlayerInstance Player => _player;
}