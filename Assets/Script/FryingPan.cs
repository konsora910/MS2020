using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    //　食材データ管理
    [SerializeField]
    public GameObject[] FPanArray = new GameObject[3];
    [SerializeField]
    public int InFood = 0;
    private int cntTomato = 0;
    private int cntRice = 0;
    private int cntEgg = 0;
    public GameObject Omrice;// インスペクタにオムライスオブジェクトを入れておくこと

    private Vector3 thisPos;
    SetCookGaugeUI CallUI;
    public GameObject getUI;
    public bool IsCookFPan = false;
    public OperatorController OpScript;

    // Start is called before the first frame update
    void Start()
    {
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
        if (IsCookFPan)
        {
            switch (InFood)
            {
                case 0:
                    IsCookFPan = false;
                    break;
                case 1:
                    IsCookFPan = false;
                    break;
                case 2:
                    LetsCooking();
                    IsCookFPan = false;
                    break;
                case 3:
                    LetsCooking();
                    IsCookFPan = false;
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
            OpScript.FoodKind(Foodselect1.RICE);
            OpScript.CookKind(OperatorController.FryingPan);
            Debug.Log("米！！");
            FoodNameRice(getFood);
        }
        if (getFood.gameObject.tag == "egg")
        {
            OpScript.FoodKind(Foodselect1.EGG);
            OpScript.CookKind(OperatorController.FryingPan);
            Debug.Log("タメェイゴォ");
            FoodNameEgg(getFood);
        }
        if (getFood.gameObject.tag == "tmt")
        {
            OpScript.FoodKind(Foodselect1.TOMATO);
            OpScript.CookKind(OperatorController.FryingPan);
            Debug.Log("トメェイトォウ");
            FoodNameTomato(getFood);
        }
        getFood.gameObject.SetActive(false);
    }

    /*===================================================
     * 特定の食材が組み合わさることで料理ができる
     ===================================================*/
    private void LetsCooking()
    {
        if (cntTomato == 1 && cntRice == 1 && cntEgg == 1)
        {
            CallUI.SetGaugeUIFlyingPan(this.transform.position);
            StartCoroutine("CookRiceOmelet");
        }
        else
        {
            Reset();
            Debug.Log("クソ料理");
        }
    }
    /*==================================================
     * 各食材の呼ばれる関数群（処理は基本的には同じ）
     * FoodNameRice()
     * FoodNameEgg()
     * FoodNameTomato()
     ==================================================*/
    private void FoodNameRice(GameObject inRice)
    {
        for (int i = 0; i < 3; i++)
        {
            if (FPanArray[i] == null)
            {
                FPanArray[i] = inRice;
                InFood++;
                cntRice++;
                break;
            }
        }
    }
    private void FoodNameEgg(GameObject inEgg)
    {
        for (int i = 0; i < 3; i++)
        {
            if (FPanArray[i] == null)
            {
                FPanArray[i] = inEgg;
                InFood++;
                cntEgg++;
                break;
            }
        }
    }
    private void FoodNameTomato(GameObject inTomato)
    {
        for (int i = 0; i < 3; i++)
        {
            if (FPanArray[i] == null)
            {
                FPanArray[i] = inTomato;
                InFood++;
                cntTomato++;
                break;
            }
        }
    }

    /*==================================================
     * オムライス調理メソッド関数
     *                          withコルーチン
     ==================================================*/
    IEnumerator CookRiceOmelet()
    {
        yield return new WaitForSeconds(5);
        GameObject obj = GameObject.FindGameObjectWithTag("Food");
        // 料理の生成場所を設定できる(生成対象オブジェクト、生成座標、生成初期角度)
        GameObject instance = (GameObject)Instantiate(Omrice, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        instance.transform.parent = obj.transform;          //コピー食材をfoodの子に
        obj.GetComponent<Foodselect1>().AddFood(instance.transform);
        Reset();
    }

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
        OpScript.FPReset();
        InFood = 0;
        cntTomato = 0;
        cntEgg = 0;
        cntRice = 0;
    }

}
