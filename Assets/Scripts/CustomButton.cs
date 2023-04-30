using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour {

    public static event EventHandler OnButtonClicked;
    private Button button;

    private void Awake() {
        button = GetComponent<Button>();

        button.onClick.AddListener(() => {
            OnButtonClicked?.Invoke(this, EventArgs.Empty);
        });
    }
}
