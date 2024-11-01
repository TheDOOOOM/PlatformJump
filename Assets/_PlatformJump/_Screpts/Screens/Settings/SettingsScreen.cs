using System.Collections.Generic;
using _PlatformJump._Screpts.SO;
using Screens;
using UnityEngine;
using UnityEngine.UI;

namespace _PlatformJump._Screpts.Screens.Settings
{
    public class SettingsScreen : BaseScreen
    {
        [SerializeField] private List<MoveComponent> _moveComponents;
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private Slider _musickSlider;
        [SerializeField] private SounConfig _sounConfig;

        public override void Init()
        {
            base.Init();
            _moveComponents.ForEach(component => component.MovePosition());
            _soundSlider.value = _sounConfig.ValueSound;
            _musickSlider.value = _sounConfig.ValueMusick;
            _soundSlider.onValueChanged.AddListener(SetSoundValue);
            _musickSlider.onValueChanged.AddListener(SetMuscikValue);
        }

        public void BackMenu()
        {
            Dialog.ShowMenuScreen();
        }

        public void SetSoundValue(float value)
        {
            _sounConfig.SetSoundValue(value);
        }

        public void SetMuscikValue(float value)
        {
            _sounConfig.SetMuscikValue(value);
        }

        public void Reset()
        {
            _musickSlider.value = 1f;
            _soundSlider.value = 1f;
        }
    }
}