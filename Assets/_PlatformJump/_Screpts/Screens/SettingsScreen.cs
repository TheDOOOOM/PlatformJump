using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private List<MoveComponent> _moveComponents;

    private void Start() => Init();


    public void Init()
    {
        _moveComponents.ForEach(component => component.MovePosition());
    }
}