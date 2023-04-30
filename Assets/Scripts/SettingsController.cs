using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour {
    
    [SerializeField] private TMP_Dropdown timerDropdown;

    private void Awake() {
        timerDropdown.value = PlayerPrefs.GetInt("TIMED_MODE_TIMER", 0);
        timerDropdown.onValueChanged.AddListener(delegate { DropdownTimeSelected(timerDropdown); });
    }

    private void DropdownTimeSelected(TMP_Dropdown timerDd) {
        PlayerPrefs.SetInt("TIMED_MODE_TIMER", timerDd.value);
    }
}
