using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

    public const string BG_MUSIC = "BG_Music";
    public static MainManager Instance;
    public float volume = 1f;

    private void Awake() {
        // Removing any duplicate MainManger
        if(Instance != null) {
            Destroy(gameObject);
            return;
        }

        // Instantiating new main manager instance
        Instance = this;

        // Setting the volume from the previous session if not found default to 1f
        volume = PlayerPrefs.GetFloat(BG_MUSIC, 1f);

        // Making the object not destroy itself when navigating to different scenes
        DontDestroyOnLoad(gameObject);
    }
}
