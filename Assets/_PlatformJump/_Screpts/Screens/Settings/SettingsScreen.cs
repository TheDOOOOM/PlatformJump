using System.Collections.Generic;
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
        [SerializeField] private ResetProgress _resetProgress;
        [SerializeField] private GameObject _settingsContent;

        public override void Init()
        {
            base.Init();
            _moveComponents.ForEach(component => component.MovePosition());
            _soundSlider.value = AudioManager.SoundValue;
            _musickSlider.value = AudioManager.MusickValue;
            _soundSlider.onValueChanged.AddListener(SetSoundValue);
            _musickSlider.onValueChanged.AddListener(SetMuscikValue);
            _resetProgress.gameObject.SetActive(false);
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

        private void ShowResetContent()
        {
            _settingsContent.gameObject.SetActive(false);
            _resetProgress.gameObject.SetActive(true);
        }

        public void ShowSettingsContent()
        {
            _settingsContent.gameObject.SetActive(true);
            _resetProgress.gameObject.SetActive(false);
        }

        public void Reset()
        {
            AudioManager.PlayButtonClick();
            ShowResetContent();
        }
    }
}