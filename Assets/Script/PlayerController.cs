using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject food;
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
            Debug.Log("aaaaa");
            
            food.GetComponent<FoodController>().takeout = false;
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
            Debug.Log("iiiii");
            if (bFood_Take == false)
            {
                if (Collider.gameObject.tag == "egg")
                {// フードタグが付いているゲームオブジェクトに当たった時
                    food = GameObject.FindGameObjectWithTag("egg");
                }
                else if (Collider.gameObject.tag == "rice")
                {// フードタグが付いているゲームオブジェクトに当たった時
                    food = GameObject.FindGameObjectWithTag("rice");
                }
                else if (Collider.gameObject.tag == "tmt")
                {// フードタグが付いているゲームオブジェクトに当たった時
                    food = GameObject.FindGameObjectWithTag("tmt");
                }
                bFood_Take = true;
            }
        }
       
    }
    
}
