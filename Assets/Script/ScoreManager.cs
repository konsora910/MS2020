using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public GameObject score_object2 = null;
    public int score_num = 0; // スコア変数
    GameObject Score;
    GameObject Score2;

    // 初期化
    void Start()
    {
        Score = GameObject.Find("teisyutudai");
        Score2 = GameObject.Find("teisyutudai1");
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text[] score_text = new Text[2];
        score_text[0] = score_object.GetComponent<Text>();
        score_text[1] = score_object2.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_num = Score.GetComponent<Score>().GetScore();
        score_text[0].text = "" + score_num;

        score_num = Score2.GetComponent<Score2>().GetScore();
        score_text[1].text = "" + score_num; 
    }
}
