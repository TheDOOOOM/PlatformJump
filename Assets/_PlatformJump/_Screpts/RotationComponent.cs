using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotationComponent : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    public void StartAnimation()
    {
        _transform.DORotate(new Vector3(0, 0, -360f), 1f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental);
    }
}