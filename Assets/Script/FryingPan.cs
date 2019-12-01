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
    //public string inFood;
    [SerializeField]
    public GameObject[] FPanArray = new GameObject[3];
    [SerializeField]
    private int InFood = 0;
    public GameObject Omrice;// インスペクタにオムライスオブジェクトを入れておくこと

    private Vector3 thisPos;
    SetCookGaugeUI CallUI;
    public GameObject getUI;
    public OperatorController OpScript;

    // Start is called before the first frame update
    void Start()
    {
        //P = GameObject.Find("Player");
        //PControll = P.GetComponent<PlayerController>();
        for (int i = 0; i < 3; i++)
        {
            FPanArray[i] = null;
        }
        thisPos = this.gameObject.transform.position;
        getUI = GameObject.Find("TestObject");
        CallUI = getUI.GetComponent<SetCookGaugeUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // 食材が３つ入ったら通る
        //if (inFood.Length == 3)
        //{
        //    Debug.Log("調理開始");
        //    LetsCooking();
        //}
        if (Input.GetKey(KeyCode.I))
        {
            switch (InFood)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    LetsCooking();
                    break;
                case 3:
                    LetsCooking();
                    break;
                default:
                    break;
            }
        }

    }

    /*=====================================================
     *  食材が触れていてプレイヤーから手放されたら読み込まれる
     *  OnTriggerStayに依存
     ====================================================*/
    public void LeadFood(GameObject getFood)
    {
        if (getFood.gameObject.tag == "rice")
        {
            //OpScript.FoodKind(Foodselect1.RICE);
            //OpScript.CookKind(OperatorController.FryingPan);
            Debug.Log("米！！");
            FoodNameRice(getFood);
            //getFood.gameObject.GetComponent<RiceControl>().DestroyFood(true);
        }
        if (getFood.gameObject.tag == "egg")
        {
            //OpScript.FoodKind(Foodselect1.EGG);
            //OpScript.CookKind(OperatorController.FryingPan);
            Debug.Log("タメェイゴォ");
            FoodNameEgg(getFood);
            //getFood.gameObject.GetComponent<EggControl>().DestroyFood(true);
        }
        if (getFood.gameObject.tag == "tmt")
        {
            //OpScript.FoodKind(Foodselect1.TOMATO);
            //OpScript.CookKind(OperatorController.FryingPan);
            Debug.Log("トメェイトォウ");
            FoodNameTomato(getFood);
            //getFood.gameObject.GetComponent<TomatoControl>().DestroyFood(true);
        }
    }

    /*===================================================
     * 特定の食材が組み合わさることで料理ができる
     ===================================================*/
    private void LetsCooking()
    {
        //string str1 = "a";
        //string str2 = "b";
        //string str3 = "c";
        //if (inFood.Contains(str1) && inFood.Contains(str2) && inFood.Contains(str3))
        //{// オムライス
        //    CallUI.SetGaugeUIFlyingPan();
        //    StartCoroutine("CookRiceOmelet");
        //}
        //else
        //{
        //    inFood = inFood.Remove(0, 3);
        //    Debug.Log("クソ料理");
        //}
    }
    /*==================================================
     * 各食材の呼ばれる関数群（処理は基本的には同じ）
     * FoodNameRice()
     * FoodNameEgg()
     * FoodNameTomato()
     ==================================================*/
    private void FoodNameRice(GameObject inRice)
    {
        //mainFood = GameObject.FindGameObjectWithTag("rice");
        //mainFood.GetComponent<RiceControl>().takeout = false;
        //inFood += "a";
        for (int i = 0; i < 3; i++)
        {
            if (FPanArray[i] == null)
            {
                FPanArray[i] = inRice;
                break;
            }
            inRice.gameObject.SetActive(false);
        }
    }
    private void FoodNameEgg(GameObject inEgg)
    {
        //mainFood = GameObject.FindGameObjectWithTag("egg");
        //mainFood.GetComponent<EggControl>().takeout = false;
        //inFood += "b";
        for (int i = 0; i < 3; i++)
        {
            if (FPanArray[i] == null)
            {
                FPanArray[i] = inEgg;
                break;
            }
            inEgg.gameObject.SetActive(false);
        }
    }
    private void FoodNameTomato(GameObject inTomato)
    {
        //mainFood = GameObject.FindGameObjectWithTag("tmt");
        //mainFood.GetComponent<TomatoControl>().takeout = false;
        //inFood += "c";
        for (int i = 0; i < 3; i++)
        {
            if (FPanArray[i] == null)
            {
                FPanArray[i] = inTomato;
                break;
            }
            inTomato.gameObject.SetActive(false);
        }
    }

    /*==================================================
     * オムライス調理メソッド関数
     *                          withコルーチン
     ==================================================*/
    IEnumerator CookRiceOmelet()
    {
        //inFood = inFood.Remove(0, 3);
        yield return new WaitForSeconds(5);
        // 料理の生成場所を設定できる(生成対象オブジェクト、生成座標、生成初期角度)
        GameObject obj = GameObject.FindGameObjectWithTag("Food");
        GameObject instance = (GameObject)Instantiate(Omrice, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        instance.transform.parent = obj.transform;          //コピー食材をfoodの子に
        obj.GetComponent<Foodselect1>().AddFood(instance.transform);
        
    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (PControll.bFood_Take == false)
    //    {
    //        LeadFood(other.gameObject);
    //    }
    //}

    public void Reset()
    {
        for (int i = 0; i <= 2; i++)
        {
            if (FPanArray[i] != null)
            {
                if (FPanArray[i].gameObject.tag == "tmt")
                {
                    FPanArray[i].gameObject.GetComponent<TomatoControl>().takeout = false;
                    FPanArray[i].gameObject.GetComponent<TomatoControl>().DestroyFood(true);
                }
                if (FPanArray[i].gameObject.tag == "rice")
                {
                    FPanArray[i].gameObject.GetComponent<RiceControl>().takeout = false;
                    FPanArray[i].gameObject.GetComponent<RiceControl>().DestroyFood(true);
                }
                if (FPanArray[i].gameObject.tag == "egg")
                {
                    FPanArray[i].gameObject.GetComponent<EggControl>().takeout = false;
                    FPanArray[i].gameObject.GetComponent<EggControl>().DestroyFood(true);
                }
            }
            FPanArray[i] = null;
        }
        InFood = 0;
    }

}
