using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public GameObject Food;
    public float time;
    //FoodController fctr; // FoodController script の値を参照
    //　PlayerContorollerを外部参照
    public GameObject P;
    public PlayerController PControll;

    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("Player");
        PControll = P.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        //name = gameObject.name; // 接触したゲームオブジェクトの名前を格納する
        //Debug.Log("接触している食材: " + gameObject.name);

        if (PControll.bFood_Take == false)
        {
            if (other.gameObject.tag == "rice")
            {
                Debug.Log("米！！");
                Food = GameObject.FindGameObjectWithTag("rice");
                Food.GetComponent<FoodController>().takeout = false;
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "egg")
            {
                Debug.Log("タメェイゴォ");
                Food = GameObject.FindGameObjectWithTag("egg");
                Food.GetComponent<FoodController>().takeout = false;
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "tmt")
            {
                Debug.Log("トメェイトォウ");
                Food = GameObject.FindGameObjectWithTag("tmt");
                Food.GetComponent<FoodController>().takeout = false;
                Destroy(other.gameObject);
            }
        }
    }
    //void OnCollisionExit(Collision collision)
    //{// 作成されたもの
    // //===============================================================================
    // /* 単体用 */
    // //
    // //===============================================================================
    //    if (food = GameObject.FindGameObjectWithTag("egg"))
    //    {// フードタグが付いているゲームオブジェクトに当たった時
    //        Debug.Log("失敗!");
    //        //fctr = true;


    //    }
    //    else if (food = GameObject.FindGameObjectWithTag("rice"))
    //    {// フードタグが付いているゲームオブジェクトに当たった時
    //        Debug.Log("失敗!");
    //        //fctr.brice = true;
    //    }
    //    else if (food = GameObject.FindGameObjectWithTag("tmt"))
    //    {// フードタグが付いているゲームオブジェクトに当たった時
    //        Debug.Log("サラダ");
    //        //fctr.btmt = true;
    //    }
    //    //===============================================================================
    //    if (collision.gameObject.tag == "cook")
    //    {
    //        Debug.Log("作成されたもの:" + gameObject.name);

    //    }
    //}
}
