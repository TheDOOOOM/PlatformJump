using DG.Tweening;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private RectTransform _transform;
    [SerializeField] private Transform _movePoint;

    public void MovePosition()
    {
        _transform.DOMove(_movePoint.position, 1f);
    }
}