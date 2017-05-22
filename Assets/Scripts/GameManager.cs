using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    SoundManager soundManager;
    FadeManager fadeManager;
    InputManager inputManager;

    bool bAttack;

    // Use this for initialization
    void Start () {
        soundManager = SoundManager.Instance;
        fadeManager = FadeManager.Instance;
        inputManager = InputManager.Instance;

        bAttack = false;
    }
	
	// Update is called once per frame
	void Update () {

	}
}
