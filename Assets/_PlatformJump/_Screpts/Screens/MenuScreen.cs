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
            AudioManager.PlayButtonClick();
            Dialog.ShowSettingsScreen();
        }

        public void ShowScreenSelect()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowSelectLevel();
        }

        public void ShowAchigmentsScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowAchigmentsScreen();
        }

        public void CloseApp()
        {
            AudioManager.PlayButtonClick();
            Application.Quit();
        }
    }
}