using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 鍋オブジェクトにつけるスクリプト
/// </summary>
public class Pot : MonoBehaviour
{
    /// <summary> 調理モード/// </summary>
    public enum Mode
    {
        Stay,        //待機(空)
        Single,      //一つ
        Double,　　　//二つ
        Triple,      //三つ

    };

    /// <summary>現在の鍋の状態</summary>
    public Mode CurrentMode { get; private set; }

    //現在鍋に入っているものを入れる配列
    [SerializeField]public GameObject[] PotArray = new GameObject[3];

    //鍋の中の個数
    [SerializeField] private int _FoodsNum = 0;

    //ゲージUIオブジェクト
    private GameObject _GaugeUI;

    //ゲージUIスクリプト
    private SetCookGaugeUI _GaugeUIScript;

    //ゲージ使用
    [SerializeField] public bool IsGauge = false;

    //調理開始用
    [SerializeField] public bool IsCooking = false;


    public GameObject Soup;

    public OperatorController OpScript;

    // SE専用変数...coffee
    public AudioClip cooking;
    AudioSource audioCookPot;

    void Start()
    {
        for (int i=0;i<3 ;i++)
        {
            PotArray[i] = null;
        }
        ChangeMode(Mode.Stay);
        Soup = (GameObject)Resources.Load("Soup");

        _GaugeUI= GameObject.FindGameObjectWithTag("CookGaugeUI");
        _GaugeUIScript = _GaugeUI.GetComponent<SetCookGaugeUI>();

        audioCookPot = GetComponent<AudioSource>();
        audioCookPot.clip = cooking;
    }



    void Update()
    {



        FoodCounter();
        /*
        if (CurrentMode == Mode.Stay)
        {
            IsCooking = false;
            StopCoroutine("CookingDouble");
            StopCoroutine("CookingTriple");
        }
        else if (CurrentMode == Mode.Single)
        {
            IsCooking = false;
        }
        else if (CurrentMode == Mode.Double) 
        {
            StartCoroutine("CookingDouble");
        }
        else if (CurrentMode == Mode.Triple) 
        {
            StartCoroutine("CookingTriple");
        }
        */
        switch (_FoodsNum)
        {
            case 0:
                {
                    ChangeMode(Mode.Stay);
                    StopCoroutine("CookingDouble");
                    StopCoroutine("CookingTriple");
                    IsCooking = false;
                    IsGauge = false;
                    break;
                }
            case 1:
                {
                    ChangeMode(Mode.Single);
                    IsCooking = false;
                    break;
                }
            case 2:
                {
                    ChangeMode(Mode.Double);
                    StartCoroutine("CookingDouble");
                    break;
                }
            case 3:
                {
                    ChangeMode(Mode.Triple);
                    StartCoroutine("CookingTriple");
                    break;
                }


        }
    }

   /// <summary>
   /// 鍋に入れる
   /// </summary>
   /// <param name="food">食べ物</param>
    public void SetFood(GameObject food)
    {
       // if (!Full)
        {
            

            if (food.gameObject.tag == "egg")
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PotArray[i] == null)
                    {
                        OpScript.FoodKind(Foodselect1.EGG);
                        OpScript.CookKind(OperatorController.Pot);
                        PotArray[i] = food;
                        break;
                    }
                }
                
            }
            else if (food.gameObject.tag == "tmt")
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PotArray[i] == null)
                    {
                        OpScript.FoodKind(Foodselect1.TOMATO);
                        OpScript.CookKind(OperatorController.Pot);
                        PotArray[i] = food;
                        break;
                    }
                }
               
            }
            else if (food.gameObject.tag == "rice")
            {
      
                for (int i = 0; i < 3; i++)
                {
                    if (PotArray[i] == null)
                    {
                        OpScript.FoodKind(Foodselect1.RICE);
                        OpScript.CookKind(OperatorController.Pot);
                        PotArray[i] = food;
                        break;
                    }
                }
                
            }
        }
        
    }

    /// <summary>
    /// 2つの食べ物の調理の関数
    /// 時間経過で料理に変える
    /// </summary>
    IEnumerator CookingDouble()
    {
        if (IsCooking)
        {
            if (!IsGauge)
            {
                _GaugeUIScript.SetGaugeUIPot(this.transform.position);
                IsGauge = true;
                audioCookPot.Play();
            }

            yield return new WaitForSeconds(ConstGaugeUI.ConstUI.POT_COOKING_TIME);
            GameObject obj = GameObject.FindGameObjectWithTag("Food");
            GameObject instance = (GameObject)Instantiate(Soup, new Vector3(this.transform.position.x + 1.0f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            instance.transform.parent = obj.transform;          //食材をfoodの子に
            obj.GetComponent<Foodselect1>().AddFood(instance.transform);
            Debug.Log("料理1");
            OpScript.CookF();
            Reset();
            audioCookPot.Stop();
            ChangeMode(Mode.Stay);
        }

    }
    /// <summary>
    /// 3つの食べ物の調理の関数
    /// 時間経過で料理に変える
    /// </summary>
    IEnumerator CookingTriple()
    {

        if (IsCooking)
        {
            if (!IsGauge)
            {
                _GaugeUIScript.SetGaugeUIPot(this.transform.position);
                IsGauge = true;
                audioCookPot.Play();
            }
            
            yield return new WaitForSeconds(ConstGaugeUI.ConstUI.POT_COOKING_TIME);
            Debug.Log("料理2");
            OpScript.CookF();
            Reset();
            ChangeMode(Mode.Stay);
        }

        //yield break;
    }

    private void FoodCounter()
    {
        int FoodCnt=0;
        //鍋のなか確認
        for (int i = 0; i <= 2; i++)
        {
            if (PotArray[i] != null)
            {
                FoodCnt++;
            }
        }
        _FoodsNum = FoodCnt;
    }


        /// <summary>
        /// 鍋を空にする
        /// </summary>
    public void Reset()
    {
        
        for (int i = 0; i <= 2; i++)
        {
            if (PotArray[i] != null)
            {
                if (PotArray[i].gameObject.tag == "tmt")
                {
                    PotArray[i].gameObject.GetComponent<TomatoControl>().takeout = false;
                    PotArray[i].gameObject.GetComponent<TomatoControl>().DestroyFood(true);
                }
                else if (PotArray[i].gameObject.tag == "rice")
                {
                    PotArray[i].gameObject.GetComponent<RiceControl>().takeout = false;
                    PotArray[i].gameObject.GetComponent<RiceControl>().DestroyFood(true);
                }
                else if (PotArray[i].gameObject.tag == "egg")
                {
                    PotArray[i].gameObject.GetComponent<EggControl>().takeout = false;
                    PotArray[i].gameObject.GetComponent<EggControl>().DestroyFood(true);
                }
            }
            PotArray[i] = null;
            
        }
        OpScript.PotReset();
        _FoodsNum = 0;
        ChangeMode(Mode.Stay);
    }

    /// <summary>
    /// モードを変更
    /// </summary>
    /// <param name="mode"> 調理モード </param>
    protected void ChangeMode(Mode mode)
    {
        if (mode == CurrentMode)
        {
            return;
        }

        CurrentMode = mode;
    }



}
