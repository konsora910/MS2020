﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    [SerializeField] public GameObject TenPlace;
    [SerializeField] public GameObject FirstPlace;
    [SerializeField] public Sprite[] Times;
    [SerializeField] public float FirstSeconds;
    [SerializeField] public int TenSeconds;
    [SerializeField] public int HundredSeconds;
    Image TenSprite;
    Image FirstSprite;
    Image HundredSprite;
    // Start is called before the first frame update
    void Start()
    {
//        TenSprite = TenPlace.gameObject.GetComponent<Image>();
//        FirstSprite = FirstPlace.gameObject.GetComponent<Image>();
//        HundredSprite = HundredPlace.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TenSeconds <= 0 && FirstSeconds <=0 && HundredSeconds <= 0)
        {
            //ここにゲームオーバー処理
//            GameController.TimeOver();
            
        }
        else
        {
            if(TenSeconds < 0)
            {
                FirstSeconds = 9.9f;
                TenSeconds = 9;
                HundredSeconds -= 1;
            }

            if (FirstSeconds < 0)
            {
                FirstSeconds = 9.9f;
                TenSeconds -= 1;
            }

//            FirstSprite.sprite = Times[(int)FirstSeconds];
//            TenSprite.sprite = Times[TenSeconds];
//            HundredSprite.sprite = Times[HundredSeconds];
            FirstSeconds -= Time.deltaTime;
        }

    }
}