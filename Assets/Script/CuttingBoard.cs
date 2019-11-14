using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public GameObject food;
    public float time;
    Collider col;
    public string name;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("OnTriggerStay");
        //Collider col;
    }

    // Update is called once per frame
    void Update()
    {

        if (time < 2)
        {// 食材を置いたときにcutfood関数が使われる
            CutFood();
        }
    }
    void CutFood()
    {
        Debug.Log("切っている食材: " + gameObject.name);
    }

    private IEnumerator OnTriggerStay(Collider Collider)
    {// 接触している時間が一定時間たったら

        name = gameObject.name; // 接触したゲームオブジェクトの名前を格納する

        Debug.Log("接触している食材: " + gameObject.name);

        yield return time;
    }
    void OnCollisionExit(Collision collision)
    {// 作成されたもの
     //===============================================================================
     /* 単体用 */
     //
     //===============================================================================
        if (food = GameObject.FindGameObjectWithTag("egg"))
        {// フードタグが付いているゲームオブジェクトに当たった時
            Debug.Log("失敗!");
            //fctr.begg = true;
            food.GetComponent<EggControl>().takeout = false;

        }
        else if (food = GameObject.FindGameObjectWithTag("rice"))
        {// フードタグが付いているゲームオブジェクトに当たった時
            Debug.Log("失敗!");
            //fctr.brice = true;
            food.GetComponent<RiceControl>().takeout = false;
        }
        else if (food = GameObject.FindGameObjectWithTag("tmt"))
        {// フードタグが付いているゲームオブジェクトに当たった時
            Debug.Log("サラダ");
            //fctr.btmt = true;
            food.GetComponent<TomatoControl>().takeout = false;
        }
        //===============================================================================
        if (collision.gameObject.tag == "cook")
        {
            Debug.Log("作成されたもの:" + gameObject.name);

        }
    }
}
