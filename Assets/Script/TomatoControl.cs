using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoControl : MonoBehaviour
{
    public GameObject Player;          　//プレイヤ―情報
    public bool takeout = false;     　  // 持っていない状態を表す
    public Vector3 FoodResetPosition;  　//食べ物の初期位置
    public Vector3 TakePosition;         // 食べ物を持つ位置
    public GameObject copyFood;
    public GameObject Food;
    bool copy = false;

    public GameObject AI;
    public bool AiTaleOut = false;
    // Start is called before the first frame update
    void Start()
    {
        copy = false;
        copyFood = (GameObject)Resources.Load("tomato");
        Player = GameObject.FindGameObjectWithTag("Player");
        AI = GameObject.FindGameObjectWithTag("AI");
        FoodResetPosition = this.transform.position;
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
            //食材を持たれたら元の位置にコピーする
            if (copy == false)
            {
                GameObject obj = GameObject.FindGameObjectWithTag("Food");
                GameObject instance = (GameObject)Instantiate(copyFood, new Vector3(FoodResetPosition.x, FoodResetPosition.y, FoodResetPosition.z), Quaternion.identity);
                instance.transform.parent = obj.transform;
                obj.GetComponent<Foodselect1>().AddFood(instance.transform);
            }
            copy = true;
            //
            this.gameObject.transform.position = new Vector3((Player.transform.position.x + Player.GetComponent<PlayerController>().PlayerForward.x/2), (Player.transform.position.y), (Player.transform.position.z + Player.GetComponent<PlayerController>().PlayerForward.z/2));
        }
        if (AiTaleOut == true)
        {
            //食材を持たれたら元の位置にコピーする
            if (copy == false)
            {
                GameObject obj = GameObject.FindGameObjectWithTag("Food");
                GameObject instance = (GameObject)Instantiate(copyFood, new Vector3(FoodResetPosition.x, FoodResetPosition.y, FoodResetPosition.z), Quaternion.identity);
                obj.transform.parent = instance.transform;
                obj.GetComponent<Foodselect1>().AddFood(instance.transform);
            }

            //
            copy = true;
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
