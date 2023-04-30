using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public event EventHandler<OnNewWaveStatusChangedArgs> OnNewWaveStatusChanged;
    public class OnNewWaveStatusChangedArgs: EventArgs {
        public bool shouldNewWaveOverlayOpen;
    }

    public static LogicManager Instance { get; private set; }

    private int score = 0;
    public Text scoreText;
    private bool gameOver = false;
    private bool isPaused = false;
    private bool isNewWaveStarting = true;

    private void Awake() {
        Instance = this;

        OnNewWaveStatusChanged?.Invoke(this, new OnNewWaveStatusChangedArgs {
            shouldNewWaveOverlayOpen = true
        });
    }

    public void AddScore() {
        score++;
        scoreText.text = score.ToString();
    }
    public void SetGameOver() {
        gameOver = true;
    }
    public void SetPauseOverlay(bool isPaused) {
        this.isPaused = isPaused;
    }
    public void SetIsNewWaveStarting(bool isNewWaveStarting) {
        this.isNewWaveStarting = isNewWaveStarting;

        OnNewWaveStatusChanged?.Invoke(this, new OnNewWaveStatusChangedArgs {
            shouldNewWaveOverlayOpen = isNewWaveStarting
        });
    }
    public bool isGameOver() => gameOver;
    public bool isPausedOverlayOpen() => isPaused;
    public bool isNewWaveStart() => isNewWaveStarting;
    public int getScore() => score;
}
