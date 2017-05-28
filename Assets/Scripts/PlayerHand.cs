using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerArmStart.GetArmMode() == (int)ARMMODE.ATTACK)
        {
            gameObject.layer = LayerMask.NameToLayer("AttackHand");
        }

        else
        {
            gameObject.layer = LayerMask.NameToLayer("Hand");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "AttackHand")
        {
            PlayerArmStart.SetArmMode((int)ARMMODE.SHRINK);
        }
    }
}
