using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyId
{
    NormalEnemy = 0,
    ThormEnemy,
    BarrierEnemy,
    Enemy_Max
};


public class GameManager : MonoBehaviour {
    SoundManager soundManager;
    FadeManager fadeManager;
    InputManager inputManager;

    bool bAttack;

    static private int[] DefeatedEnemy;

    // Use this for initialization
    void Start () {
        soundManager = SoundManager.Instance;
        fadeManager = FadeManager.Instance;
        inputManager = InputManager.Instance;

        bAttack = false;

        DefeatedEnemy = new int[(int)EnemyId.Enemy_Max];

        //テスト用
        DefeatedEnemy[0] = 5;
        DefeatedEnemy[1] = 15;
        DefeatedEnemy[2] = 20;
    }
	
	// Update is called once per frame
	void Update () {

	}

    static public void AddDefeatedEnemy(int id)
    {
        DefeatedEnemy[id]++;
    }

    static public int[] GetDefeatedEnemyCount()
    {
        return DefeatedEnemy;
    }
}
