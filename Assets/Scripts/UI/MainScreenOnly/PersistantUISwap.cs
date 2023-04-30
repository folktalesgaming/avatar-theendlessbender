using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistantUISwap : MonoBehaviour {
    [SerializeField] private Sprite MusicOn, MusicOff;

    private void Awake() {
        if(MainManager.Instance.volume > 0f) {
            gameObject.GetComponent<Image>().sprite = MusicOn;
        }else {
            gameObject.GetComponent<Image>().sprite = MusicOff;
        }
    }
}
