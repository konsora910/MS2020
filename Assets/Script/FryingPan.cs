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
    public GameObject Omrice;// インスペクタにオムライスオブジェクトを入れておくこと

    private Vector3 thisPos;
    SetCookGaugeUI CallUI;
    public GameObject getUI;


    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("Player");
        PControll = P.GetComponent<PlayerController>();
        thisPos = this.gameObject.transform.position;
        getUI = GameObject.Find("TestObject");
        CallUI = getUI.GetComponent<SetCookGaugeUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // 食材が３つ入ったら通る
        if (inFood.Length == 3)
        {
            Debug.Log("調理開始");
            LetsCooking();
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
            FoodNameRice();
            getFoodcol.gameObject.GetComponent<RiceControl>().DestroyFood(true);
        }
        if (getFoodcol.gameObject.tag == "egg")
        {
            Debug.Log("タメェイゴォ");
            FoodNameEgg();
            getFoodcol.gameObject.GetComponent<EggControl>().DestroyFood(true);
        }
        if (getFoodcol.gameObject.tag == "tmt")
        {
            Debug.Log("トメェイトォウ");
            FoodNameTomato();
            getFoodcol.gameObject.GetComponent<TomatoControl>().DestroyFood(true);
        }
    }

    /*===================================================
     * 特定の食材が組み合わさることで料理ができる
     ===================================================*/
    private void LetsCooking()
    {
        string str1 = "a";
        string str2 = "b";
        string str3 = "c";
        if (inFood.Contains(str1) && inFood.Contains(str2) && inFood.Contains(str3))
        {// オムライス
            CallUI.SetGaugeUIFlyingPan();
            StartCoroutine("CookRiceOmelet");
        }
        else
        {
            inFood = inFood.Remove(0, 3);
            Debug.Log("クソ料理");
        }
    }
    /*==================================================
     * 各食材の呼ばれる関数群（処理は基本的には同じ）
     * FoodNameRice()
     * FoodNameEgg()
     * FoodNameTomato()
     ==================================================*/
    private void FoodNameRice()
    {
        mainFood = GameObject.FindGameObjectWithTag("rice");
        mainFood.GetComponent<RiceControl>().takeout = false;
        inFood += "a";
    }
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

    /*==================================================
     * オムライス調理メソッド関数
     *                          withコルーチン
     ==================================================*/
    IEnumerator CookRiceOmelet()
    {
        inFood = inFood.Remove(0, 3);
        yield return new WaitForSeconds(5);
        // 料理の生成場所を設定できる(生成対象オブジェクト、生成座標、生成初期角度)
        Instantiate(Omrice, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
    }

    void OnTriggerStay(Collider other)
    {
        if (PControll.bFood_Take == false)
        {
            LeadFood(other);
        }
    }
}
