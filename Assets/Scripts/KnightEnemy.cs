using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightEnemy : MonoBehaviour {

    public EnemyStruct.ENemyStatus status;

    private float rotVec;

	// Use this for initialization
	void Start () {
        if (status.color == EnemyStruct.ENEMY_COLOR.BLUE)
        {
            rotVec = Random.Range(0, Mathf.PI*2.0f);
            switch (status.type)
            {
                //左から右に移動する
                case EnemyStruct.ENEMY_MOVETYPE.LEFT:

                    
                    //右側になった場合は値を修正する
                    if (rotVec <= Mathf.PI / 2.0f && rotVec >= Mathf.PI * 1.5f)
                    {
                        rotVec += Mathf.PI;
                    }
                    break;
                //右から左に移動する
                case EnemyStruct.ENEMY_MOVETYPE.RIGHT:

                    //左側になった場合は値を修正する
                    if (rotVec >= Mathf.PI / 2.0f && rotVec <= Mathf.PI * 1.5f)
                    {
                        rotVec -= Mathf.PI;
                    }
                    break;
                default:
                    break;
            }

            if(rotVec >= Mathf.PI * 2.0f)
            {
                rotVec -= Mathf.PI * 2.0f;
            }

            if(rotVec <= 0.0f)
            {
                rotVec -= Mathf.PI * 2.0f;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {

        if(status.color == EnemyStruct.ENEMY_COLOR.YELLOW)
        {
            switch (status.type)
            {
                //下方向。
                case EnemyStruct.ENEMY_MOVETYPE.DOWN:
                    transform.Translate(-transform.up * (status.moveSpeed * status.movePower));
                    break;
                //左から右に移動する
                case EnemyStruct.ENEMY_MOVETYPE.LEFT:
                    transform.Translate(transform.right * (status.moveSpeed * status.movePower));
                    break;
                //右から左に移動する
                case EnemyStruct.ENEMY_MOVETYPE.RIGHT:
                    transform.Translate(-transform.right * (status.moveSpeed * status.movePower));
                    break;
                //それ以外の移動方法
                case EnemyStruct.ENEMY_MOVETYPE.ANOTHER:
                    //transform.Translate(moveVec * status.movePower);
                    break;
                default:
                    break;
            }
        }

        else if(status.color == EnemyStruct.ENEMY_COLOR.BLUE)
        {
            transform.Translate(new Vector3(rotVec * (status.moveSpeed * status.movePower),0, rotVec * (status.moveSpeed * status.movePower)));
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Arm")
        {
            if (PlayerArmStart.GetArmMode() == (int)ARMMODE.ATTACK)
            {
                status.hp--;
                if(status.hp <= 0)
                {
                    status.gauge.AddValue(status.GolemGaugeValue);
                    Destroy(gameObject);
                }
            }
        }
    }

    public void SetMoveType(EnemyStruct.ENEMY_MOVETYPE type)
    {
        status.type = type;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
