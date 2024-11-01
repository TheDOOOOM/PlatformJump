using Screens;
using UnityEngine;

namespace _PlatformJump._Screpts
{
    public class MenuScreen : BaseScreen
    {
        [SerializeField] private MoveComponent _moveCloudOne;
        [SerializeField] private MoveComponent _moveCloudTwo;

        public override void Init()
        {
            base.Init();
            _moveCloudOne.MovePosition();
            _moveCloudTwo.MovePosition();
        }

        public void ShowSettingsScreen()
        {
            Dialog.ShowSettingsScreen();
        }
    }
}