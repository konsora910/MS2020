using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    [SerializeField] public GameObject food { get; private set; }
    //public float time;
    public GameObject Sashimi;

    //ゲージUIオブジェクト
    private GameObject _GaugeUI;

    //ゲージUIスクリプト
    private SetCookGaugeUI _GaugeUIScript;

    //ゲージ使用
    [SerializeField] public bool IsGauge = false;

    public bool IsCBoard = false;
    public OperatorController OpScript;


    // Start is called before the first frame update
    void Start()
    {
        food = null;
        _GaugeUI = GameObject.FindGameObjectWithTag("CookGaugeUI");
        _GaugeUIScript = _GaugeUI.GetComponent<SetCookGaugeUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCBoard)
        {
            CutFood();
           IsCBoard = false;
        }
    }
    

    public void LeadFood(GameObject getFood)
    {
        
      
        
        if (getFood.gameObject.tag == "rice")
        {
            Debug.Log("切っている食材: " + gameObject.name);
            food = getFood;
            //FoodNameRice(getFood);
        }
        else if (getFood.gameObject.tag == "tmt")
        {
            Debug.Log("切っている食材: " + gameObject.name);
            food = getFood;
            //FoodNameTomato(getFood);

        }
        else if (getFood.gameObject.tag == "egg")
        {
            Debug.Log("切っている食材: " + gameObject.name);
            food = getFood;
            //FoodNameEgg(getFood);
        }
        
        
    }
    
    void CutFood()
    {
        if (food.gameObject.tag == "rice")
        {
            OpScript.FoodKind(Foodselect1.RICE);
            OpScript.CookKind(OperatorController.CuttingBoard);
            Debug.Log("切れないッシュ！！");
            Reset();
        }
        else if (food.gameObject.tag == "tmt")
        {
            _GaugeUIScript.SetGaugeUICuttingboard(this.transform.position);
            OpScript.FoodKind(Foodselect1.TOMATO);
            OpScript.CookKind(OperatorController.CuttingBoard);
            Debug.Log("サラダぁ...");
            StartCoroutine("CookSarada");
        }
        else if (food.gameObject.tag == "egg")
        {
            OpScript.FoodKind(Foodselect1.EGG);
            OpScript.CookKind(OperatorController.CuttingBoard);
            Debug.Log("切れると思ってんの？");
            Reset();
        }
    }
    

    /*===============================================
     * 各食材が呼ばれる関数群（処理は基本的に同じ）
     * 　関数が呼ばれて中に食材がある場合は
     * 中身を消して食材を書き換える
     ==============================================*/
     /*
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
    */
    
    IEnumerator CookSarada()
    {
        yield return new WaitForSeconds(2);
        OpScript.CookF();
        Reset();
    }
    public void Reset()
    {
        if (food != null)
        {
            if (food.gameObject.tag == "tmt")
            {
                food.gameObject.GetComponent<TomatoControl>().takeout = false;
                food.gameObject.GetComponent<TomatoControl>().DestroyFood(true);
            }
            if (food.gameObject.tag == "rice")
            {
                food.gameObject.GetComponent<RiceControl>().takeout = false;
                food.gameObject.GetComponent<RiceControl>().DestroyFood(true);
            }
            if (food.gameObject.tag == "egg")
            {
                food.gameObject.GetComponent<EggControl>().takeout = false;
                food.gameObject.GetComponent<EggControl>().DestroyFood(true);
            }
        }
        OpScript.CutReset();
        food = null;
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
