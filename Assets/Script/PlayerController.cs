using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public bool bFood_Take = false;                         // 持ってるか持ってないか
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


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(movement * speed);

        if (FoodScript.takeout == true)
        {
            // 持った食材を置くメソッド
            if (Input.GetKeyDown(KeyCode.Space) && bFood_Take == true)
            {
                FoodScript.transform.parent = null;
                FoodScript.takeout = false; // このコメントを外すと置くみたいに少しだけ離れる
                bFood_Take = false;
            }
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
        if (Collider.gameObject.tag == "Food")
        {// フードタグが付いているゲームオブジェクトに当たった時
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bFood_Take = true;
            }

        }
    }

}
