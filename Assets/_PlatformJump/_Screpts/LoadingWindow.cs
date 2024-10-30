using System;
using UnityEngine;

namespace _PlatformJump._Screpts
{
    public class LoadingWindow : MonoBehaviour
    {
        [SerializeField] private RotationComponent _rotationComponent;

        private void Start() => _rotationComponent.StartAnimation();
    }
}