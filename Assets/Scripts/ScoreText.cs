using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    private int score;

    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScore(int[] scoreData)
    {
        for(int i = 0; i < scoreData.Length; i++)
        {
            score += scoreData[i];
        }

        text.text = "SCORE："+score;
    }
}
