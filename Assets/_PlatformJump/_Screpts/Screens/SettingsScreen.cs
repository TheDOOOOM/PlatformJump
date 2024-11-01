using System.Collections.Generic;
using Screens;
using UnityEngine;

public class SettingsScreen : BaseScreen
{
    [SerializeField] private List<MoveComponent> _moveComponents;

    public override void Init()
    {
        base.Init();
        _moveComponents.ForEach(component => component.MovePosition());
    }
}