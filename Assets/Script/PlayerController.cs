using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /// <summary> プレイヤーモード/// </summary>
    public enum Mode
    {
        Stay,        //待機(空)
        Walk,        //歩く
        Hold,　　  　//持つ
        Set,         //置く
        Cut,         //まな板
        Fry,         //フライパン
        Boil,        //鍋

    };

    /// <summary>現在の鍋の状態</summary>
    [SerializeField] public Mode CurrentMode;// { get; private set; }

    [SerializeField] private GameObject[] _FryingPanObject;
    [SerializeField] private GameObject[] _PotObject;

    private FryingPan[] _FryingPanScript;          //フライパン
    private Pot[] _PotScript;                      //鍋

    //触れている調理器具
    [SerializeField] private GameObject _TouchCookware;
    private FryingPan _TouchFryingPanScript;          //フライパン
    private Pot _TouchPotScript;                      //鍋




    public GameObject CBoard;
    public CuttingBoard CBScript;
    [SerializeField] public GameObject food;                                 //　持っている食材のgameobjectprivate GameObject _previousFood;
    public int FoodType = Foodselect1.FOODNULL;             //　どの食材をもっているか
    public float speed = 0.05f;                             //　プレイヤーの移動速度
    public Vector3 PlayerForward, OldPosition;              //　プレイヤーの向いている方向, 1フレーム前の位置
    private int ImputTimer = 5;                             //　食材を持ってから置くまでの入力遅延
    public bool bFood_Take = false;                         //　持ってるか持ってないか
    [SerializeField] public bool b_TouchPot = false;                         //　ポットにふれているかどうか
    [SerializeField] public bool b_TouchFPan = false;                        //　フライパンに触れているかどうか
    public bool b_TouchCB = false;                          //　まな板に触れているかどうか
    [SerializeField] private Vector3 velocity;              //　移動方向


    public float PushPower;
    //    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        OldPosition = this.gameObject.transform.position;
        PlayerForward = new Vector3(0.0f, 0.0f, 0.0f);


        //フライパンと鍋のタグ付いているもの取得
        _FryingPanObject = GameObject.FindGameObjectsWithTag("FP");
        _PotObject = GameObject.FindGameObjectsWithTag("pot");


        CBoard = GameObject.FindGameObjectWithTag("Cook");
        CBScript = CBoard.GetComponent<CuttingBoard>();
        CurrentMode = Mode.Stay;
    }

    // Update is called once per frame
    void Update()
    {
        ImputTimer++;
        OldPosition = this.gameObject.transform.position;


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (CurrentMode == Mode.Stay)
        {
            KeyBord();
        }
        else if (CurrentMode == Mode.Walk)
        {
            KeyBord();
        }
        else if (CurrentMode == Mode.Hold)
        {
            KeyBord();
        }
        else if (CurrentMode == Mode.Set)
        {
            ChangeMode(Mode.Stay);
        }
        else if (CurrentMode == Mode.Cut)
        {

        }
        else if (CurrentMode == Mode.Fry)
        {

        }
        else if (CurrentMode == Mode.Boil)
        {

        }

        //食材の移動
        if (bFood_Take == true)
        {


            //種類ごとに呼ぶスクリプト違う
            if (FoodType == Foodselect1.TOMATO)
                food.GetComponent<TomatoControl>().transform.position = new Vector3((transform.position.x + PlayerForward.x / 2), (transform.position.y), (transform.position.z + PlayerForward.z / 2));
            else if (FoodType == Foodselect1.EGG)
                food.GetComponent<EggControl>().transform.position = new Vector3((transform.position.x + PlayerForward.x / 2), (transform.position.y), (transform.position.z + PlayerForward.z / 2));
            else if (FoodType == Foodselect1.RICE)
                food.GetComponent<RiceControl>().transform.position = new Vector3((transform.position.x + PlayerForward.x / 2), (transform.position.y), (transform.position.z + PlayerForward.z / 2));
            else if (FoodType == Foodselect1.OMERICE)
                food.GetComponent<OmericeControle>().transform.position = new Vector3((transform.position.x + PlayerForward.x / 2), (transform.position.y), (transform.position.z + PlayerForward.z / 2));
            else if (FoodType == Foodselect1.SOUP)
                food.GetComponent<SoupControl>().transform.position = new Vector3((transform.position.x + PlayerForward.x / 2), (transform.position.y), (transform.position.z + PlayerForward.z / 2));
            else if (FoodType == Foodselect1.RICEBALL)
                food.GetComponent<RiceBallControl>().transform.position = new Vector3((transform.position.x + PlayerForward.x / 2), (transform.position.y), (transform.position.z + PlayerForward.z / 2));
        }



        //プレイヤーが移動していたら向ている方向計算
        if (OldPosition != this.gameObject.transform.position)
        {
            PlayerForward = this.gameObject.transform.position - OldPosition;
            PlayerForward = PlayerForward.normalized;
            this.gameObject.transform.forward = PlayerForward;

        }
        b_TouchFPan = false;
        b_TouchPot = false;
        b_TouchCB = false;
    }
    // キーボード操作
    void KeyBord()
    {
        // 移動
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0f, 0f);
        }
        if (b_TouchPot)
        {
            if (Input.GetKeyDown(KeyCode.K) && bFood_Take == false)
            {
                _TouchPotScript.IsCooking = true;
            }
            else if (Input.GetKeyDown(KeyCode.L) && bFood_Take == false)
            {
                _TouchPotScript.Reset();
            }
        }
        else if (b_TouchFPan)
        {
            if (Input.GetKeyDown(KeyCode.K) && bFood_Take == false)
            {
                
                _TouchFryingPanScript.IsCookFPan = true;
            }
            else if (Input.GetKeyDown(KeyCode.L) && bFood_Take == false)
            {
                _TouchFryingPanScript.Reset();
            }
        }
        else if (b_TouchCB)
        {
            if (Input.GetKeyDown(KeyCode.K) && bFood_Take == false)
            {
                CBScript.IsCBoard = true;
            }
            else if (Input.GetKeyDown(KeyCode.L) && bFood_Take == false)
            {

            }
        }

        //持っている食材を置く
        if (Input.GetKeyDown(KeyCode.Space) && ImputTimer > 5 && bFood_Take == true)
        {
            ChangeMode(Mode.Set);
            //ポットに触れていたら
            if (b_TouchPot == true)
            {
                _TouchPotScript = _TouchCookware.GetComponent<Pot>();
                _TouchPotScript.SetFood(food);
                if (food.gameObject.tag == "tmt" || food.gameObject.tag == "egg" || food.gameObject.tag == "rice")
                { food.gameObject.SetActive(false); }
            }
            //　フライパンに触れたら
            if (b_TouchFPan == true)
                _TouchFryingPanScript.LeadFood(food);
            if (b_TouchCB == true)
                CBScript.LeadFood(food);

            //種類ごとに呼ぶスクリプト違う
            if (FoodType == Foodselect1.TOMATO)
                food.GetComponent<TomatoControl>().takeout = false;
            else if (FoodType == Foodselect1.EGG)
                food.GetComponent<EggControl>().takeout = false;
            else if (FoodType == Foodselect1.RICE)
                food.GetComponent<RiceControl>().takeout = false;
            else if (FoodType == Foodselect1.OMERICE)
                food.GetComponent<OmericeControle>().takeout = false;
            else if (FoodType == Foodselect1.RICEBALL)
                food.GetComponent<RiceBallControl>().takeout = false;
            else if (FoodType == Foodselect1.SOUP)
                food.GetComponent<SoupControl>().takeout = false;
            bFood_Take = false;
            food = null;
        }

    }

    // コントローラー操作
    void control()
    {

    }

    void OnTriggerStay(Collider Collider)
    {// 接触中
        //ポットに触れていたら
        if (Collider.gameObject.tag == ("pot"))
        {
            b_TouchPot = true;
            _TouchCookware = Collider.gameObject;
        }
        else if (Collider.gameObject.tag == ("FP"))
        {
            b_TouchFPan = true;
            _TouchCookware = Collider.gameObject;
        }
        else if (Collider.gameObject.tag == ("Cook"))
        {
            b_TouchCB = true;
            _TouchCookware = Collider.gameObject;

        }

        //食べ物に触れていたら
        if (Collider.gameObject.tag == "tmt" || Collider.gameObject.tag == "egg" || Collider.gameObject.tag == "rice" || Collider.gameObject.tag == "Soup" || Collider.gameObject.tag == "Omerice" || Collider.gameObject.tag == "RiceBall")
        {
            //持つ
            if (Input.GetKeyDown(KeyCode.Space) && bFood_Take == false)
            {
                ChangeMode(Mode.Hold);
                ImputTimer = 0;
                bFood_Take = true;
                food = Collider.gameObject;
                if (Collider.gameObject.tag == "tmt")
                    FoodType = Foodselect1.TOMATO;
                else if (Collider.gameObject.tag == "egg")
                    FoodType = Foodselect1.EGG;
                else if (Collider.gameObject.tag == "rice")
                    FoodType = Foodselect1.RICE;
                else if (Collider.gameObject.tag == "Omerice")
                    FoodType = Foodselect1.OMERICE;
                else if (Collider.gameObject.tag == "Soup")
                    FoodType = Foodselect1.SOUP;
                else if (Collider.gameObject.tag == "RiceBall")
                    FoodType = Foodselect1.RICEBALL;
            }


        }

    }

    protected void ChangeTouchCookware(GameObject obj)
    {
        if (obj == _TouchCookware)
        {
            return;
        }

        _TouchCookware = obj;

        if (b_TouchPot)
        {
            _TouchPotScript = _TouchCookware.GetComponent<Pot>();
        }
        else if(b_TouchFPan)
        {
            _TouchFryingPanScript = _TouchCookware.GetComponent<FryingPan>();
        }
       // else if((b_TouchCB)
        {

        }
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
