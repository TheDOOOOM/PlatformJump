using System;
using Screens;
using UnityEngine;

namespace _PlatformJump._Screpts
{
    public class LoadingWindow : BaseScreen
    {
        [SerializeField] private RotationComponent _rotationComponent;

        public override void Init()
        {
            base.Init();
            _rotationComponent.StartAnimation();
        }
    }
}