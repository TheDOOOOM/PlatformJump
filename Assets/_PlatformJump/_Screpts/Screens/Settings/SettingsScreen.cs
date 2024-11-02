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

        public override void Init()
        {
            base.Init();
            _moveComponents.ForEach(component => component.MovePosition());
            _soundSlider.value = AudioManager.SoundValue;
            _musickSlider.value = AudioManager.MusickValue;
            _soundSlider.onValueChanged.AddListener(SetSoundValue);
            _musickSlider.onValueChanged.AddListener(SetMuscikValue);
        }

        public void BackMenu()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }

        public void SetSoundValue(float value)
        {
            AudioManager.SetSound(value);
        }

        public void SetMuscikValue(float value)
        {
            AudioManager.SetMusick(value);
        }

        public void Reset()
        {
            AudioManager.PlayButtonClick();
            _musickSlider.value = 1f;
            _soundSlider.value = 1f;
            AudioManager.SetSound(_soundSlider.value);
            AudioManager.SetMusick(_musickSlider.value);
        }
    }
}