using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector2 _moveDirection;

    private PlayerMove _movePlayer;
    private CancellationTokenSource _cancellationTokenSource;
    private bool _HoldFlag = false;

    public void SetPlayerMove(PlayerMove player)
    {
        _movePlayer = player;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource = new CancellationTokenSource();

        _HoldFlag = true;
        HoldRoutine(_cancellationTokenSource.Token).Forget();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _HoldFlag = false;
        _cancellationTokenSource?.Cancel();
    }

    private async UniTaskVoid HoldRoutine(CancellationToken cancellationToken)
    {
        while (_HoldFlag)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            Debug.Log("Кнопка удерживается");
            _movePlayer.MoveDirection(_moveDirection);
            await UniTask.Yield(PlayerLoopTiming.FixedUpdate, cancellationToken);
        }
    }
}