using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControl : MonoBehaviour
{
    public GameObject Player;           //プレイヤ―情報
    public bool takeout = false;        // 持っていない状態を表す
    public Vector3 FoodResetPosition;   //食べ物の初期位置
    public Vector3 TakePosition;         // 食べ物を持つ位置

    public GameObject AI;
    public bool AiTaleOut = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AI = GameObject.FindGameObjectWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {// Rキーを押すと元の（指定した）場所に戻る
            this.gameObject.transform.parent = null;

            this.gameObject.transform.position = new Vector3(FoodResetPosition.x, FoodResetPosition.y, FoodResetPosition.z);
        }
        if (takeout == true)
        {
            this.gameObject.transform.position = new Vector3((Player.transform.position.x/*+TakePosition.x*/), (Player.transform.position.y/*+TakePosition.y*/), (Player.transform.position.z + TakePosition.z));
        }
        if (AiTaleOut == true)
        {
            this.gameObject.transform.position = new Vector3((AI.transform.position.x), (AI.transform.position.y), (AI.transform.position.z));
        }
    }
    void OnTriggerStay(Collider Collider)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //プレイヤーと接触していたら
            if (Collider.gameObject.tag == "Player")
            {
                takeout = true; // true = 何かしら持っている
            }
        }

        if (Collider.gameObject.tag == "AI")
        {
            AiTaleOut = true;
        }
    }
    // 親を変更する関数

}
