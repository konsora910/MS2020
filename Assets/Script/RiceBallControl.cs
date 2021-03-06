﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceBallControl : MonoBehaviour
{
    public bool takeout = false;     　  // 持っていない状態を表す
    public Vector3 FoodResetPosition;  　//食べ物の初期位置
    public GameObject Food;
    bool bDestroy = false;
    public bool IsHold = false;
    bool b_teisyutu = false;
    
    void Start()
    {

    }

    
    void Update()
    {
        DestroyFood(bDestroy);      //食べ物消す
        bDestroy = false;
        if (takeout == false && b_teisyutu == true)
        {
            if (this.transform.position.x < -0.42f)
                this.transform.position = new Vector3(-0.42f, this.transform.position.y, this.transform.position.z);
            else if (this.transform.position.x > 0.8f)
                this.transform.position = new Vector3(0.8f, this.transform.position.y, this.transform.position.z);
            this.transform.position -= new Vector3(0.0f, 0.0f, 0.1f);
        }
        b_teisyutu = false;
    }
    void OnTriggerStay(Collider Collider)
    {
        if (Collider.tag == "conbair")
        {
            b_teisyutu = true;
        }

        //作業台と接触していたら
        if (Collider.gameObject.tag == "Workbench")
        {
            bDestroy = true;
        }

        if (IsHold)
        {
            //プレイヤーかAIが食べ物を持ったら
            if (Collider.gameObject.tag == "Player" || Collider.gameObject.tag == "Player2")
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
