using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] GameObject exitPopup;
    [SerializeField] GameObject settingPage;
    [SerializeField] GameObject homePage;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame() {
        audioSource.Play();
        SceneManager.LoadScene("FirstLevel");
    }

    public void OpenExitPopUp() {
        audioSource.Play();
        exitPopup.SetActive(true);
    }

    public void CloseExitPopUp() {
        audioSource.Play();
        exitPopup.SetActive(false);
    }

    public void OpenSettingPage() {
        audioSource.Play();
        settingPage.SetActive(true);
        homePage.SetActive(false);
    }

    public void CloseSettingPage() {
        audioSource.Play();
        settingPage.SetActive(false);
        homePage.SetActive(true);
    }

    public void Exit() { 
        Application.Quit(); 
    }
}
