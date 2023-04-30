using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] GameObject exitPopup;
    [SerializeField] GameObject settingPage;
    [SerializeField] GameObject homePage;

    private const string EndlessMode = "EndlessMode";
    private const string TimedMode = "TimedMode";
    private const string MainMenu = "MainMenu";

    private void Awake() {
    }

    public void StartGame() {
        SceneManager.LoadScene(TimedMode);
    }

    public void StartTimedMode() { SceneManager.LoadScene(TimedMode); }

    public void StartEndlessMode() { SceneManager.LoadScene(EndlessMode); }

    public void OpenExitPopUp() {
        exitPopup.SetActive(true);
    }

    public void CloseExitPopUp() {
        exitPopup.SetActive(false);
    }

    public void OpenSettingPage() {
        settingPage.SetActive(true);
        homePage.SetActive(false);
    }

    public void CloseSettingPage() {
        settingPage.SetActive(false);
        homePage.SetActive(true);
    }

    public void Exit() { 
        Application.Quit(); 
    }
}
