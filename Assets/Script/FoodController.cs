using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public GameObject food; // 複数の食べ物配列
    public GameObject Player;
    public PlayerController PLscript; // 外部参照　プレイヤースクリプト
    public bool takeout = false; // 持っていない状態を表す
    public Vector3 FoodResetPosition; //食べ物の初期位置
    //private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = this.GetComponent<Rigidbody>();
        //this.gameObject.transform.position = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(PLscript.btake == true)
        {
            foodparent();
        }
        if(Input.GetKey(KeyCode.R))
        {// Rキーを押すと元の（指定した）場所に戻る
            this.gameObject.transform.parent = null;
            //transform.parent = null;
            this.gameObject.transform.position = new Vector3(FoodResetPosition.x, FoodResetPosition.y, FoodResetPosition.z);
        }
    }
    // 親を変更する関数
   void foodparent()
    {// 親をプレイヤーにする
        transform.parent = GameObject.Find("Player").transform;
        // プレイヤーの一歩手前　の手の位置にしてる
        food.transform.position = new Vector3 ((Player.transform.position.x+ 0.0146f), (Player.transform.position.y+ 0.63f), (Player.transform.position.z+ 0.6f));
        takeout = true; // true = 何かしら持っている
      
    }
    
}
