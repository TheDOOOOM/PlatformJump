using System;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Transform _endPoint;
    private Transform _playerTransform;

    private float _totalDistance;
    public event Action GameEnd;

    public void SetData(Transform endPont, Transform playerTransform)
    {
        _endPoint = endPont;
        _playerTransform = playerTransform;
        _totalDistance = Vector3.Distance(_playerTransform.position, _endPoint.position);
        _slider.maxValue = _totalDistance;
    }

    private void Update()
    {
        if (_playerTransform == null)
            return;
        GameOver();
        float remainingDistance = Vector3.Distance(_playerTransform.position, _endPoint.position);
        _slider.value = _totalDistance - remainingDistance;
    }

    private void GameOver()
    {
        if (_slider.value >= 22f)
        {
            GameEnd?.Invoke();
            _playerTransform = null;
        }
    }
}