using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Pot;
    public Pot PotScript;
    public GameObject food;
    public int FoodType;
    public float speed;
    public Vector3 PlayerForward, OldPosition;
    private Rigidbody rb;
    private int ImputTimer = 5;
    public bool bFood_Take = false;                         // 持ってるか持ってないか
    [SerializeField] private Vector3 velocity;              // 移動方向
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

        if (Input.GetKeyDown(KeyCode.Space) && ImputTimer > 5)
        {   
            if(FoodType == 0)
                food.GetComponent<TomatoControl>().takeout = false;
            else if (FoodType == 1)
                food.GetComponent<EggControl>().takeout = false;
            else if (FoodType == 2)
                food.GetComponent<RiceControl>().takeout = false;
            bFood_Take = false;
            food = null;
            ImputTimer = 0;
        }

        if (OldPosition != this.gameObject.transform.position)
        {
            PlayerForward = this.gameObject.transform.position - OldPosition;
            PlayerForward = PlayerForward.normalized;
            this.gameObject.transform.forward = PlayerForward;
         
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && bFood_Take == false)
        {
            ImputTimer = 0;
            if (bFood_Take == false)
            {
                  bFood_Take = true;
            }
        }
        if (Collider.gameObject.tag == ("pot"))
        {
            if (Input.GetKeyDown(KeyCode.B) && bFood_Take == true)
            {
                food.GetComponent<FoodController>().takeout = false;
                bFood_Take = false;
                PotScript.SetFood(food);
            }
        }

    }
    
}
