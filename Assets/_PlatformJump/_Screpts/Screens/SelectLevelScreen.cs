using System.Collections.Generic;
using Screens;
using UnityEngine;

namespace _PlatformJump._Screpts.Screens
{
    public class SelectLevelScreen : BaseScreen
    {
        [SerializeField] private LevelsData _levelsData;
        [SerializeField] private List<LoadLevel> _loadLevels;

        public override void Init()
        {
            var colection = _levelsData.GetLevels();
            for (int i = 0; i < _loadLevels.Count; i++)
            {
                _loadLevels[i].SetIndexLevel(i, colection[i], _levelsData);
            }

            base.Init();
        }

        public void BackMenu()
        {
            Dialog.ShowMenuScreen();
        }
    }
}