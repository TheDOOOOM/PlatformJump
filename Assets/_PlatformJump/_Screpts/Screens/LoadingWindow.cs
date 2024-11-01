using System;
using System.Threading.Tasks;
using Screens;
using UnityEngine;

namespace _PlatformJump._Screpts
{
    public class LoadingWindow : BaseScreen
    {
        [SerializeField] private RotationComponent _rotationComponent;

        private bool _loadComplite = false;

        public override void Init()
        {
            base.Init();
            _rotationComponent.StartAnimation();
            LoadNextScreen();
        }

        public async void LoadNextScreen()
        {
            var delay = TimeSpan.FromSeconds(3f);
            while (!_loadComplite)
            {
                await Task.Delay(delay);
                _loadComplite = true;
                Dialog.ShowMenuScreen();
            }
        }
    }
}