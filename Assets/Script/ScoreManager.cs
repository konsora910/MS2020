using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public int score_num = 0; // スコア変数
    GameObject player;

    // 初期化
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "Score:" + score_num;

        score_num = player.GetComponent<Score>().GetScore(); // とりあえず1加算し続けてみる
    }
}
