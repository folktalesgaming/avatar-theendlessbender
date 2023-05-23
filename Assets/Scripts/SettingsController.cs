using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour {
    
    [SerializeField] private TMP_Dropdown timerDropdown;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;

    private void Awake() {
        timerDropdown.value = MainManager.Instance.GetTimedCountIndex();
        timerDropdown.onValueChanged.AddListener(delegate { DropdownTimeSelected(timerDropdown); });

        slider.value = MainManager.Instance.GetSFXVolume();
        sliderText.text = "Sound Effects (" + System.Math.Round(slider.value, 1) + ")";
        slider.onValueChanged.AddListener(delegate { SliderVolumeSlide(slider); });
    }

    private void DropdownTimeSelected(TMP_Dropdown timerDd) {
        MainManager.Instance.SetTimedCountIndex(timerDd.value);
    }

    private void SliderVolumeSlide(Slider sliderDd) {
        MainManager.Instance.SetSFXVolume(sliderDd.value);
        sliderText.text = "Sound Effects (" + System.Math.Round(slider.value, 1) + ")";
    }
}
