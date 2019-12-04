using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public GameObject score_object2 = null;
    public int score_num = 0; // スコア変数
    GameObject player;
    GameObject player2;

    // 初期化
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text[] score_text = new Text[2];
        score_text[0] = score_object.GetComponent<Text>();
        score_text[1] = score_object2.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_num = player.GetComponent<Score>().GetScore();
        score_text[0].text = "Score:" + score_num;

        score_num = player2.GetComponent<Score2>().GetScore();
        score_text[1].text = "Score:" + score_num; 
    }
}
