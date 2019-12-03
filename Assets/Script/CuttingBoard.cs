using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public GameObject food;
    //public float time;
    public GameObject Sashimi;

    public bool IsCBoard = false;

    // Start is called before the first frame update
    void Start()
    {
        food = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCBoard)
        {
            CutFood();
        }
    }

    public void LeadFood(GameObject getFood)
    {
        if (getFood.gameObject.tag == "rice")
        {
            Debug.Log("切っている食材: " + gameObject.name);
            FoodNameRice(getFood);
        }
        else if (getFood.gameObject.tag == "tmt")
        {
            Debug.Log("切っている食材: " + gameObject.name);
            FoodNameTomato(getFood);

        }
        else if (getFood.gameObject.tag == "egg")
        {
            Debug.Log("切っている食材: " + gameObject.name);
            FoodNameEgg(getFood);
        }
        getFood.gameObject.SetActive(false);
    }
    void CutFood()
    {
        if (food.tag == "rice")
        {
            Debug.Log("切れないッシュ！！");
        }
        else if (food.tag == "tmt")
        {
            Debug.Log("サラダぁ...");
        }
        else if (food.tag == "egg")
        {
            Debug.Log("切れると思ってんの？");
        }
    }

    /*===============================================
     * 各食材が呼ばれる関数群（処理は基本的に同じ）
     * 　関数が呼ばれて中に食材がある場合は
     * 中身を消して食材を書き換える
     ==============================================*/
    private void FoodNameRice(GameObject inRice)
    {
        if (food != null)
        {
            food = null;
        }
        food = inRice;
    }

    private void FoodNameTomato(GameObject inTomato)
    {
        if (food != null)
        {
            food = null;
        }
        food = inTomato;
    }

    private void FoodNameEgg(GameObject inEgg)
    {
        if (food != null)
        {
            food = null;
        }
        food = inEgg;
    }
    //private IEnumerator OnTriggerStay(Collider Collider)
    //{// 接触している時間が一定時間たったら

    //    name = gameObject.name; // 接触したゲームオブジェクトの名前を格納する

    //    Debug.Log("接触している食材: " + gameObject.name);

    //    yield return time;
    //}
    //void OnCollisionExit(Collision collision)
    //{// 作成されたもの
    // //===============================================================================
    // /* 単体用 */
    // //
    // //===============================================================================
    //    if (food = GameObject.FindGameObjectWithTag("egg"))
    //    {// フードタグが付いているゲームオブジェクトに当たった時
    //        Debug.Log("失敗!");
    //        //fctr.begg = true;
    //        food.GetComponent<EggControl>().takeout = false;

    //    }
    //    else if (food = GameObject.FindGameObjectWithTag("rice"))
    //    {// フードタグが付いているゲームオブジェクトに当たった時
    //        Debug.Log("失敗!");
    //        //fctr.brice = true;
    //        food.GetComponent<RiceControl>().takeout = false;
    //    }
    //    else if (food = GameObject.FindGameObjectWithTag("tmt"))
    //    {// フードタグが付いているゲームオブジェクトに当たった時
    //        Debug.Log("サラダ");
    //        //fctr.btmt = true;
    //        food.GetComponent<TomatoControl>().takeout = false;
    //    }
    //    //===============================================================================
    //    if (collision.gameObject.tag == "cook")
    //    {
    //        Debug.Log("作成されたもの:" + gameObject.name);

    //    }
    //}
}
