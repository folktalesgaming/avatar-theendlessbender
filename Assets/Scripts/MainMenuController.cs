using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] GameObject exitPopup;

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

    public void Exit() { 
        Application.Quit(); 
    }
}
