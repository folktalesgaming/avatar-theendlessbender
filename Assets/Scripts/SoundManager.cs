using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    private const string BG_MUSIC = "BG_Music";
    private AudioSource audioSource;

    [SerializeField] private Image iconImage;
    [SerializeField] private Sprite musicOn, musicOff;

    private float bgMusicVolume = .5f;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();

        bgMusicVolume = PlayerPrefs.GetFloat(BG_MUSIC, .5f);

        if(bgMusicVolume <= 0f) {
            iconImage.sprite = musicOff;
        } else {
            iconImage.sprite = musicOn;
        }

        audioSource.volume = bgMusicVolume;
    }

    private void Update() {
        
    }
    
    public void ToggleBGMusic() {
        if(bgMusicVolume >= .5f) {
            bgMusicVolume = 0f;
            PlayerPrefs.SetFloat(BG_MUSIC, 0f);
            iconImage.sprite = musicOff;
        }else {
            bgMusicVolume = .5f;
            PlayerPrefs.SetFloat(BG_MUSIC, .5f);
            iconImage.sprite = musicOn;
        }

        audioSource.volume = bgMusicVolume;
    }
}
