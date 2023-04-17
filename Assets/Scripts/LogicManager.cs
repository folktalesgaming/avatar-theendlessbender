using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    private bool gameOver = false;
    private bool isPaused = false;
    private int numberOfEnemies = 2;
    private int waveNumber = 1;

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

    public void setNumberOfEnemies() {
        if(waveNumber < 4) {
            numberOfEnemies++;
        }
    }

    public void setWaveNumber() {
        if(waveNumber < 4) {
            waveNumber++;
        }
    }

    public bool isGameOver() => gameOver;
    public bool isPausedOverlayOpen() => isPaused;
    public int getScore() => score;

    public int getNumberOfEnemies() => numberOfEnemies;
    public int getWaveNumber() => waveNumber;
}
