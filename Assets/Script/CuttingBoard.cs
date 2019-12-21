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

    public bool IsCBoard = false;   //  プレイヤーが近づくと切り替わる
    public OperatorController OpScript;
    private AudioSource CBMiss;
    public AudioClip missSound;

    public GameObject SliceTomato;

    // Start is called before the first frame update
    void Start()
    {
        food = null;
        _GaugeUI = GameObject.FindGameObjectWithTag("CookGaugeUI");
        _GaugeUIScript = _GaugeUI.GetComponent<SetCookGaugeUI>();
        CBMiss = GetComponent<AudioSource>();
        CBMiss.clip = missSound;
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
        if (!food)
        {
            Debug.Log("No FoodMaterial");
            CBMiss.Play();
        }
        else if (food.gameObject.tag == "rice")
        {
            OpScript.FoodKind(Foodselect1.RICE);
            OpScript.CookKind(OperatorController.CuttingBoard);
            Debug.Log("切れないッシュ！！");
            Reset();
        }
        else if (food.gameObject.tag == "tmt")
        {
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
    
    IEnumerator CookSarada()
    {
        if (!IsGauge)
        {
            _GaugeUIScript.SetGaugeUICuttingboard(this.transform.position);
            IsGauge = true;
        }
            yield return new WaitForSeconds(ConstGaugeUI.ConstUI.CUTTINGBOARD_COOKING_TIME);
        GameObject obj = GameObject.FindGameObjectWithTag("Food");
        // 料理の生成場所を設定できる(生成対象オブジェクト、生成座標、生成初期角度)
        GameObject instance = (GameObject)Instantiate(SliceTomato, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        instance.transform.parent = obj.transform;          //コピー食材をfoodの子に
        obj.GetComponent<Foodselect1>().AddFood(instance.transform);
        Reset();
        OpScript.CookF();

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
        IsCBoard = false;
        IsGauge = false;
    }
}

