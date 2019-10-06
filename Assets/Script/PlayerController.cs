using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public bool btake = false; // 持ってるか持ってないか
    [SerializeField] private Vector3 velocity;              // 移動方向
    public GameObject food;
    public FoodController FoodScript;
    public float PushPower;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       collider = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyBord();

        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        */
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
        if(FoodScript.takeout==true)
        {
            // 親を解除
            FoodScript.transform.parent = null;
            if (Input.GetKey(KeyCode.Space))
            {// 前方向に飛ばす
                food.transform.position += new Vector3(0f, 0f, PushPower);
                // FoodScript.takeout = false; // このコメントを外すと置くみたいに少しだけ離れる
            }
            btake = false;

        }
        

    }
    // コントローラー操作
    void control()
    {

    }

    void OnTriggerStay(Collider Collider)
    {// 接触中
        if (Collider.gameObject.tag == "Food")
        {// フードタグが付いているゲームオブジェクトに当たった時
            btake = true;
        }
            Debug.Log(gameObject.name + "接触中");
    }

}
