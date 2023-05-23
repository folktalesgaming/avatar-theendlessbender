using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

    public static MainManager Instance;
    private const string BG_MUSIC = "BG_Music", TIMED_MODE_TIMER = "Timed_Mode_Count_Index", SFX_VOLUME = "SFX_Volume";
    private float bgVolume = 1f, sfxVolume = 1f;
    private int timedCounterIndex = 0;

    private void Awake() {
        // Removing any duplicate MainManger
        if(Instance != null) {
            Destroy(gameObject);
            return;
        }

        // Instantiating new main manager instance
        Instance = this;

        // Setting the volume from the previous session if not found default to 1f
        bgVolume = PlayerPrefs.GetFloat(BG_MUSIC, 1f);
        sfxVolume = PlayerPrefs.GetFloat(SFX_VOLUME, 1f);
        timedCounterIndex = PlayerPrefs.GetInt(TIMED_MODE_TIMER, 0);

        // Making the object not destroy itself when navigating to different scenes
        DontDestroyOnLoad(gameObject);
    }

    // Getter and Setter for private variables
    public float GetBgVolume() { return bgVolume; }
    public void SetBgVolume(float bgVolume) {  
        this.bgVolume = bgVolume; 
        PlayerPrefs.SetFloat(BG_MUSIC, bgVolume);
    }

    public float GetSFXVolume() { return sfxVolume; }
    public void SetSFXVolume(float sfxVolume) {  
        this.sfxVolume = sfxVolume; 
        PlayerPrefs.SetFloat(SFX_VOLUME, sfxVolume);
    }

    public int GetTimedCountIndex() { return timedCounterIndex; }
    public void SetTimedCountIndex(int timedCounterIndex) {
        this.timedCounterIndex = timedCounterIndex;
        PlayerPrefs.SetInt(TIMED_MODE_TIMER, timedCounterIndex);
    }
}
