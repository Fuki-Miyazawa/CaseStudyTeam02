using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDataGenerator : MonoBehaviour {

    public Image EnemyPrefab;
    public Text DefeatedEnemyPrefab;
    public RectTransform EnemyPrefabTransform;
    public RectTransform DefeatedEnemyPrefabTransform;
    public RectTransform ScrollView;

    [System.Serializable]
    class ResultEnemyData
    {
        public string name;
        public int score;
        public Sprite EnemyImage;

    }

    [SerializeField]
    ResultEnemyData[] EnemyData;

    private int[] EnemyScore;

    public ScoreText scoreText;

    // Use this for initialization
    void Start () {
        //実際のスコアを入れる変数の配列を用意する
        EnemyScore = new int[EnemyData.Length];

        //スクロールビューの左上と右上の座標を計算する
        Vector2 leftUp = new Vector2(ScrollView.transform.position.x - ScrollView.sizeDelta.x*0.5f,
            ScrollView.transform.position.y + ScrollView.sizeDelta.y*0.5f);

        Vector2 rightUp = new Vector2(ScrollView.transform.position.x + ScrollView.sizeDelta.x * 0.5f,
    ScrollView.transform.position.y + ScrollView.sizeDelta.y * 0.5f);

        //倒した敵の数のデータを取得する
        int[] defeated = GameManager.GetDefeatedEnemyCount();

        if(defeated == null)
        {
            defeated = new int[EnemyData.Length];
            for(int i = 0; i < defeated.Length; i++)
            {
                defeated[i] = 0;
            }
        }

        for (int i = 0; i < EnemyData.Length; i++)
        {
            //敵の画像を表示するオブジェクトの生成
            Image image = (Image)Instantiate(EnemyPrefab,transform.parent);
            //対応する敵の画像を設定
            image.sprite = EnemyData[i].EnemyImage;

            //オブジェクトを適切な位置に移動させる
            Vector2 imagePos = new Vector2(leftUp.x + EnemyPrefabTransform.sizeDelta.x*0.5f,
                leftUp.y - EnemyPrefabTransform.sizeDelta.y * 0.5f - (EnemyPrefabTransform.sizeDelta.y*i));

            image.transform.position = imagePos;

            //倒した敵の数を表示するオブジェクトの生成
            Text text = (Text)Instantiate(DefeatedEnemyPrefab,transform.parent);
            //倒した敵の数を設定
            //text.text = "×"+ defeated[i];
            text.text = "×" + i*10;//テスト用

            //オブジェクトを適切な位置に移動させる
            Vector2 textPos = new Vector2(rightUp.x - DefeatedEnemyPrefabTransform.sizeDelta.x*0.5f,
                rightUp.y - DefeatedEnemyPrefabTransform.sizeDelta.y * 0.5f - (DefeatedEnemyPrefabTransform.sizeDelta.y*i));

            text.transform.position = textPos;

            //実際のスコアを計算
            //EnemyScore[i] = EnemyData[i].score * defeated[i];
            EnemyScore[i] = EnemyData[i].score * i*10;//テスト用
        }

        scoreText.SetScore(EnemyScore);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
