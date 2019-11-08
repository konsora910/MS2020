using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject food;
    public int FoodType;
    public float speed;
    private Rigidbody rb;
    public bool bFood_Take = false;                         // 持ってるか持ってないか
    [SerializeField] private Vector3 velocity;              // 移動方向
                                                            //    public GameObject food;
    public float PushPower;
    //    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
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
