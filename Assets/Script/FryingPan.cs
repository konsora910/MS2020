using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    //　運ぶ食材を管理する変数
    public GameObject mainFood;
    //　PlayerContorollerを外部参照
    public GameObject P;
    public PlayerController PControll;
    //　食材データ管理
    public string inFood;

    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("Player");
        PControll = P.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inFood == "ab" || inFood == "ba")
        {//　米＋卵：オムライスができる
            Debug.Log("オムライス");
            inFood = inFood.Remove(0, 2);
        }
        else if (inFood == "bc" || inFood == "cb")
        {//　卵＋トマト：トマ玉中華炒めができる
            Debug.Log("トマ玉中華炒め");
            inFood = inFood.Remove(0, 2);
        }
        else if (inFood.Length == 2)
        {//　例外：無い組み合わせなら中身を消す
            Debug.Log("ごみ屑");
            inFood = inFood.Remove(0, 2);
        }


    }

    void OnTriggerStay(Collider other)
    {
        if (PControll.bFood_Take == false)
        {
            if (other.gameObject.tag == "rice")
            {
                Debug.Log("米！！");
                mainFood = GameObject.FindGameObjectWithTag("rice");
                mainFood.GetComponent<FoodController>().takeout = false;
                inFood += "a";
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "egg")
            {
                Debug.Log("タメェイゴォ");
                mainFood = GameObject.FindGameObjectWithTag("egg");
                mainFood.GetComponent<FoodController>().takeout = false;
                inFood += "b";
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "tmt")
            {
                Debug.Log("トメェイトォウ");
                mainFood = GameObject.FindGameObjectWithTag("tmt");
                mainFood.GetComponent<FoodController>().takeout = false;
                inFood += "c";
                Destroy(other.gameObject);
            }
        }
    }
}
