using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;

    public void AddScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
