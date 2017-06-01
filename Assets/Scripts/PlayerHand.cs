using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour {

    GameObject mainCmaera;

    SwayCamera swayCamera;

    Vector2 initPosition;

    public GameObject particle;

    // Use this for initialization
    void Start () {
        mainCmaera = GameObject.FindGameObjectWithTag("MainCamera");
        swayCamera = mainCmaera.GetComponent<SwayCamera>();
        initPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = initPosition;
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
        if(collision.transform.tag == "AttackHand" || collision.transform.tag == "Hand")
        {
            GameObject obj;
            if (particle != null)
            {
                obj = Instantiate(particle, null);
                obj.transform.position = transform.position;
            }

            PlayerArmStart.SetArmMode((int)ARMMODE.SHRINK);

            swayCamera.SwayStart();
        }
    }
}
