using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewWaveController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdown;
    private float intervalTillNewWave;
    private float maxIntervalTimeTillNewWave = 6f;

    private void Start() {
        intervalTillNewWave = maxIntervalTimeTillNewWave;
    }

    private void Update() {
        if(gameObject.activeSelf && !LogicManager.Instance.isGameOver() && !LogicManager.Instance.isPausedOverlayOpen()) {
            intervalTillNewWave -= Time.deltaTime;

            countdown.text = Mathf.Ceil(intervalTillNewWave).ToString();

            if(intervalTillNewWave < 0f){
                intervalTillNewWave = maxIntervalTimeTillNewWave;
            }
        }
    }
}
