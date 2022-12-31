using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameoverScreenController : MonoBehaviour
{
    public TextMeshProUGUI finalScore;

    public void GameoverSetup(int score) {
        Debug.Log("Yeta ayooo???");
        gameObject.SetActive(true);
        finalScore.text = "SCORE: " + score;
    }

    public void Restart() {
        SceneManager.LoadScene("FirstLevel");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
