using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounter : MonoBehaviour
{

    public static event EventHandler OnTimeOver;

    private float totalTimer, totalTimerMax;
    private float baseSeconds = 60f;
    private Image timerImage;

    private void Awake() {
        float timer = (PlayerPrefs.GetInt("TIMED_MODE_TIMER", 0)*2+2) * baseSeconds;
        totalTimerMax = timer;
        totalTimer = timer;
    
        timerImage = GetComponent<Image>();
    }

    private void Update() {
        if(!LogicManager.Instance.isGameOver() && !LogicManager.Instance.isPausedOverlayOpen()) {
            totalTimer -= Time.deltaTime;

            timerImage.fillAmount = (totalTimer / totalTimerMax);

            if(totalTimer <= 0f) {
                OnTimeOver?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
