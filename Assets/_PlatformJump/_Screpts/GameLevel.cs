using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] private PlayerInstance _player;
    [SerializeField] private Transform _gameAndPoint;
    [SerializeField] private List<ColectedItem> _items;

    public void SetCounter(CollectionCounter collectionCounter)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].SetColectionCounter(collectionCounter);
        }
    }

    public Transform GameEndPoint => _gameAndPoint;
    public PlayerInstance Player => _player;
}