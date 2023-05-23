using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimedModeOverlay : MonoBehaviour {
    public static TimedModeOverlay Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI overlayText;

    private void Awake() {
        Instance = this;
    }
    
    public void SetOverlayText(string oText) {
        overlayText.text = oText;
    }
}
