using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceBallControl : MonoBehaviour
{
    public bool takeout = false;     　  // 持っていない状態を表す
    public Vector3 FoodResetPosition;  　//食べ物の初期位置
    public GameObject Food;
    bool bDestroy = false;
    public bool IsHold = false;

    
    void Start()
    {

    }

    
    void Update()
    {
        DestroyFood(bDestroy);      //食べ物消す
    }
    void OnTriggerStay(Collider Collider)
    {

        if (IsHold)
        {

            //作業台と接触していたら
            if (Collider.gameObject.tag == "Workbench")
            {
                bDestroy = true;
            }

            //プレイヤーかAIが食べ物を持ったら
            if (Collider.gameObject.tag == "Player")
            {
                takeout = true; // true = 何かしら持っている
            }
        }
    }

    public void DestroyFood(bool delate)
    {
        if (takeout == false && delate == true)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Food");
            obj.GetComponent<Foodselect1>().DelateFood(this.transform);
            Destroy(this.gameObject);
        }
    }
}
