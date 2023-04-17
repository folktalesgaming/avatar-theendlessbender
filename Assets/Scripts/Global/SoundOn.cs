using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOn : MonoBehaviour
{
    
    public enum SOUND_PLAY_TYPE {
        On_CLICK,
        On_AWAKE,
        On_LOOP,
    }

    [SerializeField] private SOUND_PLAY_TYPE soundType;

    private AudioSource audioSource;
    
    private void Awake() {
        audioSource = GetComponent<AudioSource>();

        if(soundType == SOUND_PLAY_TYPE.On_AWAKE) {
            audioSource.loop = false;
            audioSource.Play();
        }

        if(soundType == SOUND_PLAY_TYPE.On_LOOP) {
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlaySound() {
        if(soundType == SOUND_PLAY_TYPE.On_CLICK) {
            audioSource.Play();
        }
    }

}
