using DG.Tweening;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private RectTransform _movePoint;

    private RectTransform _transform;
    private void Awake() => _transform = GetComponent<RectTransform>();

    public void MovePosition() => _transform.DOMove(_movePoint.position, 1f);
}