using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    [SerializeField] private Vector3    velocity;              // 移動方向
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
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
        // ものを持つ動作
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
        
    }
    // コントローラー操作
    void control()
    {

    }
    // ものを持つ離す（飛ばす？）関数
    void takefood()
    {

    }
}
