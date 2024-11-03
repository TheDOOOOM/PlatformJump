using System.Collections.Generic;
using Screens;
using UnityEngine;

namespace _PlatformJump._Screpts.Screens
{
    public class SelectLevelScreen : BaseScreen
    {
        [SerializeField] private LevelsData _levelsData;
        [SerializeField] private List<LoadLevel> _loadLevels;

        public void BackMenu()
        {
            Dialog.ShowMenuScreen();
        }
    }
}