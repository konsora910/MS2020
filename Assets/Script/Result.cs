﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public GameObject score_object2 = null;
    GameObject Win;
    GameObject Lose;
    GameObject Draw;
    Text[] score_text = new Text[2];
    int n_score;
    int n_score2;
    bool b_fade;

    public static float ResultUIMove = 360.0f;

    // Start is called before the first frame update
    void Start()
    {
        b_fade = false;
        //１人用のリザルトシーン
        if (SceneManager.GetActiveScene().name == "SPResultScene")
        {
            SingleInit();
        }

        //２人用のリザルトシーン
        if (SceneManager.GetActiveScene().name == "DPResultScene")
        {
            DoubleInit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (b_fade == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button_b"))
            {
                b_fade = true;
                GameObject obj = GameObject.FindGameObjectWithTag("scene");
                obj.gameObject.GetComponent<SceneControl>().FadeOut("TitleScene");
            }
        }
    }

    //１人用リザルトシーン
    void SingleInit()
    {
        score_text[0] = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        n_score = Score.GetScore();
        score_text[0].text = "" + n_score;

    }

    //２人用リザルトシーン
    void DoubleInit()
    {
        Win = GameObject.Find("Win");
        Lose = GameObject.Find("Lose");
        Draw = GameObject.Find("Draw");

        Win.SetActive(true);
        Lose.SetActive(true);
        Draw.SetActive(false);

        // オブジェクトからTextコンポーネントを取得
        score_text[0] = score_object.GetComponent<Text>();
        score_text[1] = score_object2.GetComponent<Text>();
        // テキストの表示を入れ替える
        n_score = Score.GetScore();
        score_text[0].text = "" + n_score;

        n_score2 = Score2.GetScore();
        score_text[1].text = "" + n_score2;

        if (n_score < n_score2)
        {
            score_text[1].transform.parent = Win.transform;          //プレイヤー２をWinの子に
            score_text[0].transform.parent = Lose.transform;          //プレイヤー１をLoseの子に

            Win.gameObject.transform.position = new Vector3(Win.gameObject.transform.position.x + ResultUIMove, Win.gameObject.transform.position.y, 0.0f);
            Lose.gameObject.transform.position = new Vector3(Lose.gameObject.transform.position.x - ResultUIMove, Lose.gameObject.transform.position.y, 0.0f);
        }
        else if (n_score > n_score2)
        {
            score_text[0].transform.parent = Win.transform;          //プレイヤー１をWinの子に
            score_text[1].transform.parent = Lose.transform;          //プレイヤー２をLoseの子に

            Win.gameObject.transform.position = new Vector3(Win.gameObject.transform.position.x - ResultUIMove, Win.gameObject.transform.position.y, 0.0f);
            Lose.gameObject.transform.position = new Vector3(Lose.gameObject.transform.position.x + ResultUIMove, Lose.gameObject.transform.position.y, 0.0f);
        }
        else if (n_score == n_score2)
        {
            Lose.SetActive(false);
            Draw.SetActive(true);

            score_text[0].transform.parent = Win.transform;          //プレイヤー１をWinの子に
            score_text[1].transform.parent = Draw.transform;          //プレイヤー２をLoseの子に

            Win.gameObject.transform.position = new Vector3(Win.gameObject.transform.position.x - ResultUIMove, Win.gameObject.transform.position.y, 0.0f);
            Draw.gameObject.transform.position = new Vector3(Draw.gameObject.transform.position.x + ResultUIMove, Draw.gameObject.transform.position.y, 0.0f);

        }
    }
}
