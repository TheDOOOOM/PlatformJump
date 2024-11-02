using System.Collections.Generic;
using _PlatformJump._Screpts.SO;
using Screens;
using UnityEngine;

public class AchigmentsScreen : BaseScreen
{
    [SerializeField] private List<AchigmentViue> _achigmentViues;
    [SerializeField] private AchigmentsColection _achigment;

    public override void Init()
    {
        var items = _achigment.GetAchigments();
        for (int i = 0; i < _achigmentViues.Count; i++)
            _achigmentViues[i].SetData(items[i].Header, items[i].Discription, items[i].Status);

        base.Init();
    }

    public void BackMenu()
    {
        Dialog.ShowMenuScreen();
    }
}