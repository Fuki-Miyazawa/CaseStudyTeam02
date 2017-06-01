using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStruct{

    public enum ENEMY_COLOR
    {
        YELLOW = 0,
        BLUE,
        RED
    }

    public enum ENEMY_MOVETYPE
    {
        DOWN = 0,
        LEFT,
        RIGHT,
        ANOTHER
    }

    [System.Serializable]
    public struct ENemyStatus
    {
        public ENEMY_COLOR color;
        public ENEMY_MOVETYPE type;
        public float moveSpeed;
        public float movePower;
        public int hp;
        public Rigidbody2D rigid;
        public GolemGauge gauge;
        public SpriteRenderer render;
        public float GolemGaugeValue;
    }
}
