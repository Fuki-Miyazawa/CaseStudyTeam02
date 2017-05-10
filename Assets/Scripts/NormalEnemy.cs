using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour {

    private Rigidbody2D rigid;

    public GolemGauge gauge;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigid.AddForce(-transform.up*3);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Arm")
        {
            if(PlayerArmStart.GetArmMode() == (int)ARMMODE.ATTACK)
            {
                gauge.AddValue(0.5f);
                Destroy(gameObject);
            }
        }
    }
}
