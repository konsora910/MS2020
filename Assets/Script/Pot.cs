﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 鍋オブジェクトにつけるスクリプト
/// </summary>
public class Pot : MonoBehaviour
{
    /// <summary> 調理モード/// </summary>
    public enum Mode
    {
        Stay,        //待機(空)
        Single,      //一つ
        Double,　　　//二つ
        Triple,      //三つ

    };

    /// <summary>現在の鍋の状態</summary>
    public Mode CurrentMode { get; private set; }

    //現在鍋に入っているものを入れる配列
    [SerializeField] GameObject[] PotArray = new GameObject[3];

    //調理可能か（鍋に2つ以上ものが入っているか）
    [SerializeField] public bool Cook { get; private set; } = false;

    //鍋が満タンかどうか
    [SerializeField] public bool Full { get; private set; } = false;

    //鍋の中の個数
    [SerializeField] public int FoodsNum=0;


    public GameObject Soup;



    void Start()
    {
        for (int i=0;i<3 ;i++)
        {
            PotArray[i] = null;
        }
        ChangeMode(Mode.Stay);
        Soup = (GameObject)Resources.Load("Soup");
    }

    

    void Update()
    {



        FoodCounter();

            switch (FoodsNum)
            {
                case 0:
                {
                    ChangeMode(Mode.Stay); Cook = false;
                    StopCoroutine("CookingDouble");
                    StopCoroutine("CookingTriple");
                    break;
                }
                case 1: ChangeMode(Mode.Single); Cook = false; break;
                case 2: ChangeMode(Mode.Double); Cook = true; StartCoroutine("CookingDouble"); break;
                case 3:
                {
                    ChangeMode(Mode.Triple);
                    Cook = true;
                    StartCoroutine("CookingTriple");
                    break;
                }

            }
        
        
    }

   /// <summary>
   /// 鍋に入れる
   /// </summary>
   /// <param name="food">食べ物</param>
    public void SetFood(GameObject food)
    {
       // if (!Full)
        {
            

            if (food.gameObject.tag == "egg")
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PotArray[i] == null)
                    {
                        PotArray[i] = food;
                        break;
                    }
                }
                food.gameObject.SetActive(false);
            }
            else if (food.gameObject.tag == "tmt")
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PotArray[i] == null)
                    {
                        PotArray[i] = food;
                        break;
                    }
                }
                food.gameObject.SetActive(false);
            }
            else if (food.gameObject.tag == "rice")
            {
      
                for (int i = 0; i < 3; i++)
                {
                    if (PotArray[i] == null)
                    {
                        PotArray[i] = food;
                        break;
                    }
                }
                food.gameObject.SetActive(false);
            }
        }
    }
    /// <summary>
    /// 2つの食べ物の調理の関数
    /// 時間経過で料理に変える
    /// </summary>
    IEnumerator CookingDouble()
    {
        yield return new WaitForSeconds(ConstGaugeUI.ConstUI.POT_COOKING_TIME);
        GameObject obj = GameObject.FindGameObjectWithTag("Food");
        GameObject instance = (GameObject)Instantiate(Soup, new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z), Quaternion.identity);
        instance.transform.parent = obj.transform;          //食材をfoodの子に
        obj.GetComponent<Foodselect1>().AddFood(instance.transform);
        Debug.Log("料理1");
        Reset();
        ChangeMode(Mode.Stay);

    }
    /// <summary>
    /// 3つの食べ物の調理の関数
    /// 時間経過で料理に変える
    /// </summary>
    IEnumerator CookingTriple()
    {


        yield return new WaitForSeconds(ConstGaugeUI.ConstUI.POT_COOKING_TIME);
        Debug.Log("料理2");
        Reset();
        ChangeMode(Mode.Stay);

        //yield break;
    }

    private void FoodCounter()
    {
        int FoodCnt=0;
        //鍋のなか確認
        for (int i = 0; i <= 2; i++)
        {
            if (PotArray[i] != null)
            {
                FoodCnt++;
            }
        }
        FoodsNum = FoodCnt;
    }


        /// <summary>
        /// 鍋を空にする
        /// </summary>
    public void Reset()
    {
        
        for (int i = 0; i <= 2; i++)
        {
            if (PotArray[i] != null)
            {
                if (PotArray[i].gameObject.tag == "tmt")
                {
                    PotArray[i].gameObject.GetComponent<TomatoControl>().takeout = false;
                    PotArray[i].gameObject.GetComponent<TomatoControl>().DestroyFood(true);
                }
                else if (PotArray[i].gameObject.tag == "rice")
                {
                    PotArray[i].gameObject.GetComponent<RiceControl>().takeout = false;
                    PotArray[i].gameObject.GetComponent<RiceControl>().DestroyFood(true);
                }
                else if (PotArray[i].gameObject.tag == "egg")
                {
                    PotArray[i].gameObject.GetComponent<EggControl>().takeout = false;
                    PotArray[i].gameObject.GetComponent<EggControl>().DestroyFood(true);
                }
            }
            PotArray[i] = null;
            
        }
        FoodsNum = 0;
        Cook = false;
        Full = false;
    }
    /// <summary>
    /// モードを変更
    /// </summary>
    /// <param name="mode"> 調理モード </param>
    protected void ChangeMode(Mode mode)
    {
        if (mode == CurrentMode)
        {
            return;
        }

        CurrentMode = mode;
    }



}
