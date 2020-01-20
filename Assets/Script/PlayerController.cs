using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /// <summary>
    /// プレイヤーモード
    /// </summary>
    public enum Mode
    {
        Stay,        //待機(空)
        Walk,        //歩く
        Hold,　　  　//持つ
        HoldWalk,    //持って歩く
        Set,         //置く
        Cut,         //まな板
        Fry,         //フライパン
        Boil,        //鍋

    };

    /// <summary>現在の鍋の状態</summary>
    //[SerializeField]
    public Mode CurrentMode;//{ get; private set; }

    [SerializeField] private string _Gamepad_x;
    [SerializeField] private string _Gamepad_z;
    [SerializeField] private string _Gamepad_HoldSet;
    [SerializeField] private string _Gamepad_Operator;
    [SerializeField] private string _Gamepad_Cancel;
   [SerializeField] private string[] _GamepadNames;



    //触れている調理器具
    [SerializeField] private GameObject _TouchCookware;
    [SerializeField] private FryingPan _TouchFryingPanScript;          //フライパン
    [SerializeField] private Pot _TouchPotScript;                      //鍋
    [SerializeField] private CuttingBoard _TouchCutScript;             //まな板

    //プレイヤーの向き
    [SerializeField] private Vector3 _Direction;



    [SerializeField] public GameObject food;                //　持っている食材のgameobjectprivate GameObject _previousFood;
    public int FoodType = Foodselect1.FOODNULL;             //　どの食材をもっているか
    [SerializeField] private float _Speed = 0.1f;           //　プレイヤーの移動速度
    public Vector3 PlayerForward, OldPosition;              //　プレイヤーの向いている方向, 1フレーム前の位置
    private int ImputTimer = 5;                             //　食材を持ってから置くまでの入力遅延
    public bool bFood_Take = false;                         //　持ってるか持ってないか
    [SerializeField] public bool b_TouchPot = false;        //　ポットにふれているかどうか
    [SerializeField] public bool b_TouchFPan = false;       //　フライパンに触れているかどうか
    public bool b_TouchCB = false;                          //　まな板に触れているかどうか

    [SerializeField] private bool _IsTouchFood = false;     //食べ物に触れていたら
    [SerializeField] private GameObject _TouchFood=null;    //触れている食べ物
    private EggControl _TouchEggScript;
    private RiceControl _TouchRiceScript;
    private TomatoControl _TouchTomatoScript;
    private FishControl _TouchFishScript;
    [SerializeField] private SoupControl _TouchSoupScript;
    private OmericeControl _TouchOmericeScript;
    private RiceBallControl _TouchRiceballScript;
    //食材
    public bool b_TouchEgg = false;                         //　卵にふれているかどうか
    public bool b_TouchRice = false;                        //　米に触れているかどうか
    public bool b_TouchTomato = false;
    public bool b_TouchFish = false;
    //料理
    [SerializeField] public bool b_TouchSoup = false;
    public bool b_TouchOmerice = false;
    public bool b_TouchRiceball = false;


    [SerializeField] private Vector3 velocity;              //　移動方向

    //AIscript
    [SerializeField] OperatorController OpScript;
    public float PushPower;

    /// 追加部分
    ////PlayerAnimation
    private Animator animator;                              //  プレイヤーがキー入力によってモーションが変化する
    //PlayerWalkingEffect
    private ParticleSystem particle;

    //    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        //  _rb= transform.GetComponent<Rigidbody>();

        /// 追加部分
        animator = GetComponent<Animator>();
        particle = this.GetComponent<ParticleSystem>();
       // particle.Stop();

        OldPosition = this.gameObject.transform.position;
        PlayerForward = new Vector3(0.0f, 0.0f, 0.0f);

        CurrentMode = Mode.Stay;
    }

    // Update is called once per frame
    void Update()
    {
        ImputTimer++;
        OldPosition = this.gameObject.transform.position;

        _GamepadNames = Input.GetJoystickNames();

        /// 追加部分
        MotionChange();

        if (CurrentMode == Mode.Stay)
        {
            KeyBord();
            
             Gamepad();
        }
        else if (CurrentMode == Mode.Walk)
        {
            
            KeyBord();
             Gamepad(); 
        }
        else if (CurrentMode == Mode.Hold)
        {
            
        }
        else if (CurrentMode == Mode.HoldWalk)
        {
            KeyBord();
            Gamepad();
        }
        else if (CurrentMode == Mode.Set)
        {
            
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
                food.GetComponent<OmericeControl>().transform.position = new Vector3((transform.position.x + PlayerForward.x / 2), (transform.position.y), (transform.position.z + PlayerForward.z / 2));
            else if (FoodType == Foodselect1.SOUP)
                food.GetComponent<SoupControl>().transform.position = new Vector3((transform.position.x + PlayerForward.x / 2), (transform.position.y), (transform.position.z + PlayerForward.z / 2));
            else if (FoodType == Foodselect1.RICEBALL)
                food.GetComponent<RiceBallControl>().transform.position = new Vector3((transform.position.x + PlayerForward.x / 2), (transform.position.y), (transform.position.z + PlayerForward.z / 2));
        }


        
        //プレイヤーが移動していたら向ている方向計算
        if (OldPosition != this.gameObject.transform.position)
        {
           // ChangeMode(Mode.Walk);
            PlayerForward = this.gameObject.transform.position - OldPosition;
            PlayerForward = PlayerForward.normalized;
            this.gameObject.transform.forward = PlayerForward;

        }
        
        b_TouchFPan = false;
        b_TouchPot = false;
        b_TouchCB = false;

        _TouchCookware = null;
       // _TouchFood = null;

        _IsTouchFood = false;

        b_TouchEgg = false;
        b_TouchRice = false;
        b_TouchTomato = false;
        b_TouchFish = false;

        b_TouchOmerice = false;
        //b_TouchSoup = false;
        b_TouchRiceball = false;

        
        /*
        _TouchFryingPanScript = null;
        _TouchPotScript = null;
        */
    }
    
    // キーボード操作
    private void KeyBord()
    {
        // 移動
        if (Input.GetKey(KeyCode.W) )
        {
            transform.position += Vector3.forward* _Speed;
       ///     animator.SetBool("is_running", true); // Animatorタブ上の遷移条件
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(_Speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0f, 0f, _Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(_Speed, 0f, 0f);
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
                _TouchCutScript.IsCBoard = true;
            }
            else if (Input.GetKeyDown(KeyCode.L) && bFood_Take == false)
            {
                _TouchCutScript.Reset();
            }
        }
        //食べ物に触れていたら
        if (_IsTouchFood)
        {
            //持つ
            if (Input.GetKeyDown(KeyCode.Space) && bFood_Take == false)
            {
                ChangeMode(Mode.Hold);
                ImputTimer = 0;
                food = _TouchFood;

                // 食材
                if (_TouchFood.tag == "tmt")
                {
                    _TouchTomatoScript.IsHold = true;
                    FoodType = Foodselect1.TOMATO;
                }
                else if (_TouchFood.tag == "egg")
                {
                    _TouchEggScript.IsHold = true;
                    FoodType = Foodselect1.EGG;
                }
                else if (_TouchFood.tag == "rice")
                {
                    _TouchRiceScript.IsHold = true;
                    FoodType = Foodselect1.RICE;
                }
                else if(_TouchFood.tag == "Fish")
                {
                    _TouchFishScript.IsHold = true;
                }

                // 料理
                else if (_TouchFood.tag == "Soup")
                {
                    _TouchSoupScript.IsHold = true;
                    FoodType = Foodselect1.SOUP;
                }
                else if (_TouchFood.tag == "Omerice")
                {
                    _TouchOmericeScript.IsHold = true;
                    FoodType = Foodselect1.OMERICE;
                }

                else if (_TouchFood.tag == "RiceBall")
                {
                    _TouchRiceballScript.IsHold = true;
                    FoodType = Foodselect1.RICEBALL;
                }

                //bFood_Take = true;
            }
            //持っている食材を置く
            else if (Input.GetKeyDown(KeyCode.Space) && ImputTimer > 5 && bFood_Take == true)
            {
                ChangeMode(Mode.Set);
                //ポットに触れていたら
                if (b_TouchPot == true && !_TouchPotScript.IsCooking)
                {
                    _TouchPotScript.SetFood(food);
                    if (food.gameObject.tag == "tmt" || food.gameObject.tag == "egg" || food.gameObject.tag == "rice")
                    { food.gameObject.SetActive(false); }
                }
                //　フライパンに触れたら
                if (b_TouchFPan == true && !_TouchFryingPanScript.IsCookFPan)
                {
                    _TouchFryingPanScript.LeadFood(food);
                }
                if (b_TouchCB == true && !_TouchCutScript.IsCBoard)
                {

                    _TouchCutScript.LeadFood(food);

                    if (food.gameObject.tag == "tmt" || food.gameObject.tag == "egg" || food.gameObject.tag == "rice")
                    { food.gameObject.SetActive(false); }
                }


                //種類ごとに呼ぶスクリプト違う
                if (FoodType == Foodselect1.TOMATO)
                    food.GetComponent<TomatoControl>().takeout = false;
                else if (FoodType == Foodselect1.EGG)
                    food.GetComponent<EggControl>().takeout = false;
                else if (FoodType == Foodselect1.RICE)
                    food.GetComponent<RiceControl>().takeout = false;
                else if (FoodType == Foodselect1.OMERICE)
                    food.GetComponent<OmericeControl>().takeout = false;
                else if (FoodType == Foodselect1.RICEBALL)
                    food.GetComponent<RiceBallControl>().takeout = false;
                else if (FoodType == Foodselect1.SOUP)
                {
                    food.GetComponent<SoupControl>().takeout = false;
                }
                bFood_Take = false;
                food = null;
            }
        }

        //AIに対する
        if (Input.GetKeyDown(KeyCode.F))
        {
            OpScript.Miss();
        }

      
    }


    // コントローラー操作
    private void Gamepad()
    {


        //プレイヤー移動
        if ((Input.GetAxis(_Gamepad_x) > -1 && Input.GetAxis(_Gamepad_x) < 1 && Input.GetAxis(_Gamepad_z) > -1 && Input.GetAxis(_Gamepad_z) < 1)&& (CurrentMode == Mode.Stay || CurrentMode == Mode.Walk))
        {
            ChangeMode(Mode.Stay);
        }
        /*
        else if ((Input.GetAxis(_Gamepad_x) == 1 || Input.GetAxis(_Gamepad_x) == -1||Input.GetAxis(_Gamepad_z) == 1|| Input.GetAxis(_Gamepad_z) == -1) &&bFood_Take)
        {
            ChangeMode(Mode.HoldWalk);
            transform.position += (Vector3.forward * Input.GetAxis(_Gamepad_z) + Vector3.right * Input.GetAxis(_Gamepad_x)) * _Speed;
        }*/
        else if((Input.GetAxis(_Gamepad_x) == 1 || Input.GetAxis(_Gamepad_x) == -1 || Input.GetAxis(_Gamepad_z) == 1 || Input.GetAxis(_Gamepad_z) == -1)&&CurrentMode == Mode.HoldWalk)
        {
            transform.position += (Vector3.forward * Input.GetAxis(_Gamepad_z) + Vector3.right * Input.GetAxis(_Gamepad_x)) * _Speed;
        }
        else  if((Input.GetAxis(_Gamepad_x) == 1 || Input.GetAxis(_Gamepad_x) == -1 || Input.GetAxis(_Gamepad_z) == 1 || Input.GetAxis(_Gamepad_z) == -1) && (CurrentMode == Mode.Stay|| CurrentMode == Mode.Walk))
        {
            ChangeMode(Mode.Walk);
            transform.position += (Vector3.forward * Input.GetAxis(_Gamepad_z) + Vector3.right * Input.GetAxis(_Gamepad_x) )*_Speed;
           // animator.SetBool("is_running", true); // Animatorタブ上の遷移条件
        }
        


        if (b_TouchPot)
        {
            if (Input.GetButtonDown(_Gamepad_HoldSet) && bFood_Take == false)
            {
                _TouchPotScript.IsCooking = true;
            }
            else if (Input.GetButtonDown(_Gamepad_Cancel) && bFood_Take == false)
            {
                _TouchPotScript.Reset();
            }
        }
        else if (b_TouchFPan)
        {
            if (Input.GetButtonDown(_Gamepad_HoldSet) && bFood_Take == false)
            {

                _TouchFryingPanScript.IsCookFPan = true;
            }
            else if (Input.GetButtonDown(_Gamepad_Cancel) && bFood_Take == false)
            {
                _TouchFryingPanScript.Reset();
            }
        }
        else if (b_TouchCB)
        {
            if (Input.GetButtonDown(_Gamepad_HoldSet) && bFood_Take == false)
            {
                _TouchCutScript.IsCBoard = true;
            }
            else if (Input.GetButtonDown(_Gamepad_Cancel) && bFood_Take == false)
            {
                _TouchCutScript.Reset();
            }
        }

        //食べ物に触れているとき
        if (_IsTouchFood)
        {
            //持つ
            if (Input.GetButtonDown(_Gamepad_HoldSet) && bFood_Take == false && (CurrentMode == Mode.Stay || CurrentMode == Mode.Walk))
            {

                ChangeMode(Mode.Hold);
                ImputTimer = 0;
                food = _TouchFood;

                // 食材
                if (_TouchFood.tag == "tmt")
                {
                    _TouchTomatoScript.IsHold = true;
                    FoodType = Foodselect1.TOMATO;
                }
                else if (_TouchFood.tag == "egg")
                {
                    _TouchEggScript.IsHold = true;
                    FoodType = Foodselect1.EGG;
                }
                else if (_TouchFood.tag == "rice")
                {
                    _TouchRiceScript.IsHold = true;
                    FoodType = Foodselect1.RICE;
                }
                else if (_TouchFood.tag == "Fish")
                {
                    _TouchFishScript.IsHold = true;
                }

                // 料理
                else if (_TouchFood.tag == "Soup")
                {
                    _TouchSoupScript.IsHold = true;
                    FoodType = Foodselect1.SOUP;
                }
                else if (_TouchFood.tag == "Omerice")
                {
                    _TouchOmericeScript.IsHold = true;
                    FoodType = Foodselect1.OMERICE;
                }

                else if (_TouchFood.tag == "RiceBall")
                {
                    _TouchRiceballScript.IsHold = true;
                    FoodType = Foodselect1.RICEBALL;
                }

                //bFood_Take = true;
            }

            //持っている食材を置く
            else if (Input.GetButtonDown(_Gamepad_HoldSet) && bFood_Take == true && (CurrentMode == Mode.HoldWalk) )
            {
                ChangeMode(Mode.Set);
                //ポットに触れていたら
                if (b_TouchPot == true && !_TouchPotScript.IsCooking)
                {
                    //_TouchPotScript = _TouchCookware.GetComponent<Pot>();
                    _TouchPotScript.SetFood(food);
                    if (food.gameObject.tag == "tmt" || food.gameObject.tag == "egg" || food.gameObject.tag == "rice")
                    { food.gameObject.SetActive(false); }
                }
                //　フライパンに触れたら
                else if (b_TouchFPan == true&&!_TouchFryingPanScript.IsCookFPan)
                {
                    _TouchFryingPanScript.LeadFood(food);
                }
                
                else if (b_TouchCB == true&&!_TouchCutScript.IsCBoard)
                {
                    _TouchCutScript.LeadFood(food);

                    if (food.gameObject.tag == "tmt" || food.gameObject.tag == "egg" || food.gameObject.tag == "rice")
                    { food.gameObject.SetActive(false); }
                }
               /* else
                {
                    if (food.gameObject.tag == "tmt" || food.gameObject.tag == "egg" || food.gameObject.tag == "rice")
                    { food.gameObject.SetActive(false); }
                }
                */


                //種類ごとに呼ぶスクリプト違う
                if (FoodType == Foodselect1.TOMATO)
                    food.GetComponent<TomatoControl>().takeout = false;
                else if (FoodType == Foodselect1.EGG)
                    food.GetComponent<EggControl>().takeout = false;
                else if (FoodType == Foodselect1.RICE)
                    food.GetComponent<RiceControl>().takeout = false;
                else if (FoodType == Foodselect1.OMERICE)
                    food.GetComponent<OmericeControl>().takeout = false;
                else if (FoodType == Foodselect1.RICEBALL)
                    food.GetComponent<RiceBallControl>().takeout = false;
                else if (FoodType == Foodselect1.SOUP)
                    food.GetComponent<SoupControl>().takeout = false;
                bFood_Take = false;
                food = null;
            }
        }

        //AIに対する
        if(Input.GetButtonDown(_Gamepad_Operator))
        {
            OpScript.Miss();
        }

        


    }

    /// <summary>
    /// ゲームオブジェクトのcollider取得
    /// </summary>
    /// <param name="Collider">ゲームオブジェクト</param>
    void OnTriggerStay(Collider Collider)
    {// 接触中
        //ポットに触れていたら
        if (Collider.gameObject.tag == ("pot"))
        {
            b_TouchPot = true;
            ChangeTouchCookware(Collider.gameObject);
            
        }
        else if (Collider.gameObject.tag == ("FP"))
        {
            
            b_TouchFPan = true;
            ChangeTouchCookware(Collider.gameObject);
        }
        else if (Collider.gameObject.tag == ("CuttingBoard"))
        {
            
            b_TouchCB = true;
            ChangeTouchCookware(Collider.gameObject);
        }
        
        //食べ物に触れていたら
        if (Collider.gameObject.tag == "tmt" )
        {
            b_TouchTomato = true;
            _IsTouchFood = true;
            ChangeTouchFood(Collider.gameObject);
        }
        else if(Collider.gameObject.tag == "egg")
        {
            b_TouchEgg = true;
            _IsTouchFood = true;
            ChangeTouchFood(Collider.gameObject);
        }
        else if(Collider.gameObject.tag == "rice")
        {
            b_TouchRice = true;
            _IsTouchFood = true;
            ChangeTouchFood(Collider.gameObject);
        }
        else if(Collider.gameObject.tag == "Soup")
        {
            b_TouchSoup = true;
            _IsTouchFood = true;
            ChangeTouchFood(Collider.gameObject);
        }
        else if(Collider.gameObject.tag == "Omerice")
        {
            b_TouchOmerice = true;
            _IsTouchFood = true;
            ChangeTouchFood(Collider.gameObject);
        }
        else if(Collider.gameObject.tag == "RiceBall")
        {
            b_TouchRiceball = true;
            _IsTouchFood = true;
            ChangeTouchFood(Collider.gameObject);
        }

    }

    /// <summary>
    /// 触れている調理器具からスクリプト取得
    /// </summary>
    /// <param name="obj"></param>
    private void ChangeTouchCookware(GameObject obj)
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
        if (b_TouchFPan)
        {
            _TouchFryingPanScript = _TouchCookware.GetComponent<FryingPan>();
        }
        if (b_TouchCB)
        {
            _TouchCutScript = _TouchCookware.GetComponent<CuttingBoard>();
        }
    }

    /// <summary>
    /// 触れている食べ物からスクリプト取得
    /// </summary>
    /// <param name="food"></param>
    private void ChangeTouchFood(GameObject food)
    {
        if (food == _TouchFood)
        {
            return;
        }
        _TouchFood = food;

        if (b_TouchEgg)
        {
            _TouchEggScript = _TouchFood.GetComponent<EggControl>();
        }
        if (b_TouchRice)
        {
            _TouchRiceScript = _TouchFood.GetComponent<RiceControl>();
        }
        if (b_TouchTomato)
        {
            _TouchTomatoScript = _TouchFood.GetComponent<TomatoControl>();
        }
        if (b_TouchSoup)
        {
            _TouchSoupScript = _TouchFood.GetComponent<SoupControl>();
        }
        if (b_TouchOmerice)
        {
            _TouchOmericeScript = _TouchFood.GetComponent<OmericeControl>();
        }
        if (b_TouchRiceball)
        {
            _TouchRiceballScript = _TouchFood.GetComponent<RiceBallControl>();
        }
    }

    public bool is_parametor;
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

    /// 追加部分
    /// <summary>
    /// モーションを変更
    /// </summary>
    // モーションをモードによって切り替える
    void MotionChange()
    {
        switch (CurrentMode)
        {
            case Mode.Boil:
                break;
            case Mode.Cut:
                break;
            case Mode.Fry:
                break;
            case Mode.Hold:
                animator.SetBool("is_stay", false);
                animator.SetBool("is_running", false);
                animator.SetBool("is_hold", true);
                //animator.GetCurrentAnimatorStateInfo(0).IsName("hold");
                //if (!animator.GetCurrentAnimatorStateInfo(0).IsName("hold"))
                {
                    bFood_Take = true;
                    ChangeMode(Mode.HoldWalk);

                }
                
                break;
            case Mode.HoldWalk:
                animator.SetBool("is_stay", false);
                animator.SetBool("is_running", false);
                animator.SetBool("is_hold", false);
                animator.SetBool("is_holdwalk", true);
                break;
            case Mode.Set:
                animator.SetBool("is_hold", false);
                animator.SetBool("is_holdwalk", false);
                animator.SetBool("is_set", true);
                ChangeMode(Mode.Stay);
                break;
            case Mode.Stay:
                //animator.SetBool("is_running", true); // Animatorタブ上の遷移条件
                animator.SetBool("is_running", false);
                //animator.SetBool("is_hold", false);
                animator.SetBool("is_stay", true); // Animatorタブ上の遷移条件
                animator.SetBool("is_set", false);
                // particle.Stop();
                break;
            case Mode.Walk:
                animator.SetBool("is_stay", false);
                animator.SetBool("is_running", true); // Animatorタブ上の遷移条件
                animator.SetBool("is_set", false);
                //particle.Play();
                break;
        }
    }

  
    }
