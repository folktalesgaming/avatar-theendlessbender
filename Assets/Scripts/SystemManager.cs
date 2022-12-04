using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager: MonoBehaviour {
    void update() {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            Application.Quit(); 
    }
} 