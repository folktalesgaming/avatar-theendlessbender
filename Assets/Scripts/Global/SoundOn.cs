using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOn : MonoBehaviour
{
    
    public enum SOUND_PLAY_TYPE {
        On_CLICK,
        On_AWAKE,
        On_LOOP,
    }

    [SerializeField] private SOUND_PLAY_TYPE[] soundType;

    [SerializeField] private AudioSource audioSourceMain;
    [SerializeField] private AudioSource audioSourceSecondary;
    
    private void Start() {
        CustomButton.OnButtonClicked += CustomButton_OnButtonClicked;

        if(soundType[0] == SOUND_PLAY_TYPE.On_AWAKE) {
            audioSourceMain.loop = false;
        }

        if(soundType[0] == SOUND_PLAY_TYPE.On_LOOP) {
            audioSourceMain.loop = true;
        }

        audioSourceMain.volume = MainManager.Instance.volume;

        if(soundType[0] == SOUND_PLAY_TYPE.On_AWAKE || soundType[0] == SOUND_PLAY_TYPE.On_LOOP) {
            audioSourceMain.playOnAwake = true;
            audioSourceMain.Play();
        } else {}
    }

    private void CustomButton_OnButtonClicked(object sender, System.EventArgs e) {
        PlaySound();
    }

    public void PlaySound() {
        if(soundType[1] == SOUND_PLAY_TYPE.On_CLICK) {
            audioSourceSecondary.Play();
        }
    }

    public void ToogleSoundPlay() {
        if(MainManager.Instance.volume > 0f) {
            MainManager.Instance.volume = 0f;
        }else {
            MainManager.Instance.volume = 1f;
        }

        audioSourceMain.volume = MainManager.Instance.volume;
        PlayerPrefs.SetFloat(MainManager.BG_MUSIC, MainManager.Instance.volume);

        if(TryGetComponent(out UISwappingLogics uISwapping)) {
            uISwapping.ToogleState(MainManager.Instance.volume > 0f);
        }
    }

}
