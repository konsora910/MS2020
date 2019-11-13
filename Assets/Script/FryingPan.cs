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
    public GameObject Omrice;

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
            Instantiate(Omrice);
        }
        else if (inFood.Length == 2)
        {//　例外：無い組み合わせなら中身を消す
            Debug.Log("ごみ屑");
            inFood = inFood.Remove(0, 2);
        }


    }

    /*=====================================================
     *  食材が触れていてプレイヤーから手放されたら読み込まれる
     *  OnTriggerStayに依存
     ====================================================*/
    private void LeadFood(Collider getFoodcol)
    {
        if (getFoodcol.gameObject.tag == "rice")
        {
            Debug.Log("米！！");
            mainFood = GameObject.FindGameObjectWithTag("rice");
            mainFood.GetComponent<RiceControl>().takeout = false;
            inFood += "a";
            Destroy(getFoodcol.gameObject);
        }
        if (getFoodcol.gameObject.tag == "egg")
        {
            Debug.Log("タメェイゴォ");
            FoodNameEgg();
            Destroy(getFoodcol.gameObject);
        }
        if (getFoodcol.gameObject.tag == "tmt")
        {
            Debug.Log("トメェイトォウ");
            FoodNameTomato();
            Destroy(getFoodcol.gameObject);
        }
    }

    /*==================================================
     * 各食材の呼ばれる関数群（処理は基本的には同じ）
     * 
     * FoodNameEgg()
     * FoodNameTomato()
     ==================================================*/
    private void FoodNameEgg()
    {
        mainFood = GameObject.FindGameObjectWithTag("egg");
        mainFood.GetComponent<EggControl>().takeout = false;
        inFood += "b";
    }
    private void FoodNameTomato()
    {
        mainFood = GameObject.FindGameObjectWithTag("tmt");
        mainFood.GetComponent<TomatoControl>().takeout = false;
        inFood += "c";
    }

    void OnTriggerStay(Collider other)
    {
        if (PControll.bFood_Take == false)
        {
            LeadFood(other);
        }
    }
}
