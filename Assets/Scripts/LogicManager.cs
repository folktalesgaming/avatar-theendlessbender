using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    private bool gameOver = false;

    public void AddScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void SetGameOver() {
        gameOver = true;
    }

    public bool isGameOver() => gameOver;
}
