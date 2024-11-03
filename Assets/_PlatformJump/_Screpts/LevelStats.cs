using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class LevelStats
{
    private int _jumps;
    private int _gravitySwitch;
    private int _itamsColection;
    private int _scrore;

    private bool _startGame;

    private CancellationTokenSource _cancellationTokenSource;

    public int Jumps => _jumps;
    public int GrawvitySwitch => _gravitySwitch;
    public int _itemsColection => _itemsColection;
    public int Score => _scrore;

    public void AddJumps() => _jumps++;

    public void AddGravitySwitch() => _gravitySwitch++;

    public void StartScoreAdd()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _startGame = true;
        AddScore(_cancellationTokenSource.Token);
    }

    private async UniTaskVoid AddScore(CancellationToken cancellationToken)
    {
        var delay = TimeSpan.FromSeconds(0.5f);
        while (_startGame)
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            _scrore += 3;
            Debug.Log(_scrore);
            await UniTask.Delay(delay);
        }
    }

    public void Close()
    {
        _startGame = false;
        _scrore = 0;
    }
}