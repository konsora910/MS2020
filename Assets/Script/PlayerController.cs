using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject food;
    public int FoodType;
    public float speed;
    public Vector3 PlayerForward, OldPosition;
    private Rigidbody rb;
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
    }

    // Update is called once per frame
    void Update()
    {
        OldPosition = this.gameObject.transform.position;
        KeyBord();
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (Input.GetKeyDown(KeyCode.B) && bFood_Take == true)
        {   
            if(FoodType == 0)
                food.GetComponent<TomatoControl>().takeout = false;
            else if (FoodType == 1)
                food.GetComponent<EggControl>().takeout = false;
            else if (FoodType == 2)
                food.GetComponent<RiceControl>().takeout = false;
            bFood_Take = false;
            food = null;
        }

        if (OldPosition != this.gameObject.transform.position)
        {
            PlayerForward = this.gameObject.transform.position - OldPosition;
            PlayerForward = PlayerForward.normalized;
            Debug.Log(PlayerForward);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bFood_Take == false)
            {
                  bFood_Take = true;
            }
        }
       
    }
    
}
