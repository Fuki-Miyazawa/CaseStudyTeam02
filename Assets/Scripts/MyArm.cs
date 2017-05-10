using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyArm : MonoBehaviour {

    bool bAttack;

    // Use this for initialization
    void Start () {
        bAttack = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerArmStart.GetArmMode() == (int)ARMMODE.ATTACK)
        {
            if (!bAttack)
            {
                gameObject.layer = LayerMask.NameToLayer("AttackArm");
                bAttack = true;
            }
        }

        else
        {
            if (bAttack)
            {
                gameObject.layer = LayerMask.NameToLayer("Arm");
                bAttack = false;
            }
        }
    }
}
