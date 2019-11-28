using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Pot;
    public Pot PotScript;
    public GameObject food;                                 //　持っている食材のgameobject
    public int FoodType = Foodselect1.FOODNULL;             //　どの食材をもっているか
    public float speed = 0.05f;                             //　プレイヤーの移動速度
    public Vector3 PlayerForward, OldPosition;              //　プレイヤーの向いている方向, 1フレーム前の位置
    private int ImputTimer = 5;                             //　食材を持ってから置くまでの入力遅延
    public bool bFood_Take = false;                         //　持ってるか持ってないか
    public bool b_TouchPot = false;                         //　ポットにふれているかどうか
    [SerializeField] private Vector3 velocity;              //　移動方向
                                                            //    public GameObject food;
    public float PushPower;
    //    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        OldPosition = this.gameObject.transform.position;
        PlayerForward = new Vector3(0.0f, 0.0f, 0.0f);
        Pot = GameObject.FindGameObjectWithTag("pot");
        PotScript = Pot.GetComponent<Pot>();
    }

    // Update is called once per frame
    void Update()
    {
        ImputTimer++;
        OldPosition = this.gameObject.transform.position;
        KeyBord();
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        //食材の移動
        if(bFood_Take == true)
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
        //持っている食材を置く
        if (Input.GetKeyDown(KeyCode.Space) && ImputTimer > 5 && bFood_Take == true)
        {
            //ポットに触れていたら
            if(b_TouchPot == true)
                PotScript.SetFood(food);

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

        //プレイヤーが移動していたら向ている方向計算
        if (OldPosition != this.gameObject.transform.position)
        {
            PlayerForward = this.gameObject.transform.position - OldPosition;
            PlayerForward = PlayerForward.normalized;
            this.gameObject.transform.forward = PlayerForward;
         
        }
        b_TouchPot = false;
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
    }

    // コントローラー操作
    void control()
    {

    }

    void OnTriggerStay(Collider Collider)
    {// 接触中
        //ポットに触れていたら
        if (Collider.gameObject.tag == ("pot"))
            b_TouchPot = true;

        //食べ物に触れていたら
        if (Collider.gameObject.tag == "tmt" || Collider.gameObject.tag == "egg" || Collider.gameObject.tag == "rice" || Collider.gameObject.tag == "Soup" || Collider.gameObject.tag == "Omerice" || Collider.gameObject.tag == "RiceBall")
        {
            //持つ
            if (Input.GetKeyDown(KeyCode.Space) && bFood_Take == false)
            {
                ImputTimer = 0;
                bFood_Take = true;
                food = Collider.gameObject;
                if (Collider.gameObject.tag == "tmt")
                    FoodType = Foodselect1.TOMATO;
                if (Collider.gameObject.tag == "egg")
                    FoodType = Foodselect1.EGG;
                if (Collider.gameObject.tag == "rice")
                    FoodType = Foodselect1.RICE;
                if (Collider.gameObject.tag == "Omerice")
                    FoodType = Foodselect1.OMERICE;
                if (Collider.gameObject.tag == "Soup")
                    FoodType = Foodselect1.SOUP;
                if (Collider.gameObject.tag == "RiceBall")
                    FoodType = Foodselect1.RICEBALL;
            }
        
        }

    }
    
}
