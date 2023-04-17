using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIController : MonoBehaviour
{
    
    [SerializeField] private GameObject gameOverOverlay;
    [SerializeField] private GameObject pauseOverlay;
    [SerializeField] private LogicManager logicManager;

    public void OpenGameoverOverlay() {
        gameOverOverlay.SetActive(true);
        logicManager.SetGameOver();
    }

    public void CloseGameoverOverlay() {
        gameOverOverlay.SetActive(false);
    }

    public void OpenPauseOverlay() {
        pauseOverlay.SetActive(true);
        logicManager.SetPauseOverlay(true);
    }

    public void ClosePauseOverlay() {
        pauseOverlay.SetActive(false);
        logicManager.SetPauseOverlay(false);
    }
}
