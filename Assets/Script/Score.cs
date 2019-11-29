﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public bool b_Score = false;
    public int FoodType = Foodselect1.FOODNULL;
    public int n_Order = 0;
    public bool b_OrderCrear = false;


    //仮置き
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        n_Order = Foodselect1.RICEBALL;
        //仮置き
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (b_Score)
        {
            if (FoodType == Foodselect1.OMERICE)
            {
                if (n_Order == Foodselect1.OMERICE)
                {
                    b_OrderCrear = true;
                    score += 10000;
                    n_Order = player.GetComponent<Order>().GetOrder(1);
                }
                else
                    score += 100;
            }
            else if (FoodType == Foodselect1.RICEBALL)
            {
                if (n_Order == Foodselect1.RICEBALL)
                {
                    b_OrderCrear = true;
                    score += 20000;
                    n_Order = player.GetComponent<Order>().GetOrder(1);
                }
                else
                    score += 150;
            }
            else if (FoodType == Foodselect1.SOUP)
            {
                if (n_Order == Foodselect1.SOUP)
                {
                    b_OrderCrear = true;
                    score += 30000;
                    n_Order = player.GetComponent<Order>().GetOrder(1);
                }
                else
                    score += 200;
            }
            b_Score = false;
        }
    }

    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "Omerice" || Collider.gameObject.tag == "RiceBall" || Collider.gameObject.tag == "Soup")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Collider.gameObject.tag == "Omerice")
                    FoodType = Foodselect1.OMERICE;
                else if (Collider.gameObject.tag == "RiceBall")
                    FoodType = Foodselect1.RICEBALL;
                else if (Collider.gameObject.tag == "Soup")
                    FoodType = Foodselect1.SOUP;
                b_Score = true;
            }
        }
    }
}