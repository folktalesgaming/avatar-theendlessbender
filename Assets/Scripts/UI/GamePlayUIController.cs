using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    
    [SerializeField] private GameObject gameOverOverlay;
    [SerializeField] private GameObject pauseOverlay;
    [SerializeField] private GameObject newWaveOverlay;
    [SerializeField] private LogicManager logicManager;

    private void Start() {
        LogicManager.Instance.OnNewWaveStatusChanged += LogicManager_OnNewWaveStatusChanged;

        TimerCounter.OnTimeOver += TimerCounter_OnTimeOver;
    }

    private void LogicManager_OnNewWaveStatusChanged(object sender, LogicManager.OnNewWaveStatusChangedArgs e) {
        if(e.shouldNewWaveOverlayOpen){
            OpenNewWaveOverlay();
        }else {
            CloseNewWaveOverlay();
        }
    }

    private void TimerCounter_OnTimeOver(object sender, System.EventArgs e) {
        OpenGameoverOverlay();
    }

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

    private void OpenNewWaveOverlay() {
        newWaveOverlay.SetActive(true);
    }

    private void CloseNewWaveOverlay() {
        newWaveOverlay.SetActive(false);
    }

    public void ExitToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
