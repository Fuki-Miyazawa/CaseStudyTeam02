using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFinger : MonoBehaviour {

    Vector2 initPosition;

	// Use this for initialization
	void Start () {
        initPosition = transform.localPosition;

    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = initPosition;
        if (PlayerArmStart.GetArmMode() == (int)ARMMODE.ATTACK || PlayerArmStart.GetArmMode() == (int)ARMMODE.SHRINK)
        {
            gameObject.layer = LayerMask.NameToLayer("AttackFinger");
        }

        else
        {
            
            gameObject.layer = LayerMask.NameToLayer("Finger");
        }

     }
}
