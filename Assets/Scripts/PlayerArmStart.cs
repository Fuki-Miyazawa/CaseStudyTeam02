using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ARMMODE
{
    NORMAL,
    TOUCHED,
    ATTACK,
    SHRINK,
    RESET
};

public class PlayerArmStart : MonoBehaviour {

    public GameObject ArmL;
    public GameObject ArmR;

    private GameObject SaveArmL;
    private GameObject SaveArmR;

    public float MoveSpeed;
    public float AttackSpeed;
    public float AttackTime;

    private static ARMMODE ArmMode;

    public float ArmDistance;
    private float ArmInitPositionY;

    private Vector3 ScreenPointL;
    private Vector3 ScreenPointR;
    private Vector3 offsetL;
    private Vector3 offsetR;

    private float AttackTimeCount;

    // Use this for initialization
    void Start () {
        SaveArmL = Instantiate(ArmL,null);
        SaveArmR = Instantiate(ArmR, null);

        ArmInitPositionY = transform.position.y - 55;

        SaveArmL.transform.position = new Vector3(transform.position.x - ArmDistance,
            ArmInitPositionY,
            1);

        SaveArmR.transform.position = new Vector3(transform.position.x + ArmDistance,
        ArmInitPositionY,
        1);

        ArmMode = ARMMODE.NORMAL;

        AttackTimeCount = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("ARMMODE："+ArmMode);
        switch (ArmMode)
        {
            case ARMMODE.NORMAL://通常時
                Normal();
                break;

            case ARMMODE.TOUCHED://タッチ中
                Move();
                break;

            case ARMMODE.ATTACK://攻撃中
                if (AttackTimeCount >= AttackTime)
                {
                    SetArmMode((int)ARMMODE.SHRINK);
                    //SetArmMode((int)ARMMODE.RESET);        
                    return;
                }

                Attack();
                break;

            case ARMMODE.SHRINK://縮み中
                if(ArmInitPositionY >= SaveArmL.transform.position.y)
                {
                    SetArmMode((int)ARMMODE.RESET);
                    return;
                }
                Shrink();
                break;

            case ARMMODE.RESET://リセット
                ResetArm();
                break;
        }
	}

    //ボタンがクリックされ、離された瞬間に実行される
    public void Onclick()
    {
        ArmMode = ARMMODE.ATTACK;
    }

    //ボタンがクリックされた瞬間に実行される
    public void OnClickTrigger()
    {
        ArmMode = ARMMODE.TOUCHED;

        ScreenPointL = Camera.main.WorldToScreenPoint(SaveArmL.transform.position);
        ScreenPointR = Camera.main.WorldToScreenPoint(SaveArmR.transform.position);

        offsetL = SaveArmL.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y,
        ScreenPointL.z));

        offsetR = SaveArmR.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y,
        ScreenPointR.z));
    }

    //初期化関数
    private void InitArm()
    {
        ArmInitPositionY = transform.position.y - 55;

        SaveArmL.transform.position = new Vector3(transform.position.x - ArmDistance,
            ArmInitPositionY,
            1);

        SaveArmR.transform.position = new Vector3(transform.position.x + ArmDistance,
        ArmInitPositionY,
        1);

        AttackTimeCount = 0.0f;

        SetArmMode((int)ARMMODE.NORMAL);
    }

    //腕を伸ばす関数
    void Move()
    {
        if(InputManager.GetTouchRelease())
        {
            Onclick();
            return;
        }

        float horizonal = InputManager.GetTouchMoveHorizonal();

        SaveArmL.transform.Translate(new Vector3(horizonal, 0.5f,0));
        SaveArmR.transform.Translate(new Vector3(horizonal, 0.5f, 0));

        
    }

    //攻撃を実行する関数
    void Attack()
    {
        AttackTimeCount += Time.deltaTime;

        SaveArmL.transform.Translate(new Vector3(0.25f, 0, 0));
        SaveArmR.transform.Translate(new Vector3(-0.25f, 0, 0));
    }

    //腕を縮ませる
    void Shrink()
    {
        SaveArmL.transform.Translate(new Vector3(0, -0.5f, 0));
        SaveArmR.transform.Translate(new Vector3(0, -0.5f, 0));
    }

    //フラグをリセットする関数
    public void ResetArm()
    {
        InitArm();
    }

    public static void SetArmMode(int mode)
    {
        ArmMode = (ARMMODE)mode;
    }

    public static int GetArmMode()
    {
        return (int)ArmMode;
    }

    private void Normal()
    {
        bool clicked = InputManager.GetTouchTrigger();
        if(clicked)
        {
            OnClickTrigger();
        }
    }
}
