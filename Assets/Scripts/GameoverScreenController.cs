using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameoverScreenController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private string level;

    public void GameoverSetup(int score) {
        gameObject.SetActive(true);
        finalScore.text = "SCORE: " + score;
    }

    public void Restart() {
        SceneManager.LoadScene(level);
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
