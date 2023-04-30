using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISwappingLogics : MonoBehaviour {

    [SerializeField] private Image imageIcon;
    [SerializeField] private Sprite OnState, OffState;

    public void OnTheState() {
        imageIcon.sprite = OnState;
    }

    public void OffTheState() {
        imageIcon.sprite = OffState;
    }

    public void ToogleState(bool IsOnState) {
        if(IsOnState) 
            imageIcon.sprite = OnState;
        else
            imageIcon.sprite = OffState;
    }
}
