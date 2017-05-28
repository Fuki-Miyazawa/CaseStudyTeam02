using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(InputManager.GetTouchPress())
        {
            transform.position = new Vector3(InputManager.GetTouchMoveHorizonal(),InputManager.GetTouchMoveVertical(),transform.position.z);
        }

	}
}
