using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private PlayerMove _movePlayer;

    private CancellationTokenSource _cancellationTokenSource;

    public void OnPointerDown(PointerEventData eventData)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        HoldRoutine(_cancellationTokenSource.Token).Forget();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource = null;
    }

    private async UniTaskVoid HoldRoutine(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Debug.Log("Button is being held down");
            _movePlayer.MoveDirection(_moveDirection);
            await UniTask.Yield(PlayerLoopTiming.FixedUpdate, cancellationToken);
        }
    }
}