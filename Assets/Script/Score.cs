using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public int n_ListNum = 0;
    public bool b_Score = false;
    public int FoodType = Foodselect1.FOODNULL;
    public int n_Order = 0;
    public OperatorController OpScript;
    public OrderGUI OrGUIScript;
    //仮置き
    GameObject scoreobj;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 9000;
        n_ListNum = 1;
        b_Score = false;

        //仮置き
        scoreobj = GameObject.Find("order");

        n_Order = 5;
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
                    OpScript.CookEnd();
                    OrGUIScript.OrderNext();
                    score += 10000;
                    n_Order = scoreobj.GetComponent<Order>().GetOrder(n_ListNum);
                    n_ListNum++;
                }
                else
                    score += 100;
            }
            else if (FoodType == Foodselect1.RICEBALL)
            {
                if (n_Order == Foodselect1.RICEBALL)
                {
                    OpScript.CookEnd();
                    OrGUIScript.OrderNext();
                    score += 20000;
                    n_Order = scoreobj.GetComponent<Order>().GetOrder(n_ListNum);
                    n_ListNum++;
                }
                else
                    score += 150;
            }
            else if (FoodType == Foodselect1.SOUP)
            {
                if (n_Order == Foodselect1.SOUP)
                {
                    OpScript.CookEnd();
                    OrGUIScript.OrderNext();
                    score += 30000;
                    n_Order = scoreobj.GetComponent<Order>().GetOrder(n_ListNum);
                    n_ListNum++;
                }
                else
                    score += 200;
            }
            b_Score = false;
            FoodType = Foodselect1.FOODNULL;
        }
    }

    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "Omerice" || Collider.gameObject.tag == "RiceBall" || Collider.gameObject.tag == "Soup")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Collider.gameObject.tag == "Omerice")
                {
                    FoodType = Foodselect1.OMERICE;
                }
                else if (Collider.gameObject.tag == "RiceBall")
                {
                    FoodType = Foodselect1.RICEBALL;
                }
                else if (Collider.gameObject.tag == "Soup")
                {
                    FoodType = Foodselect1.SOUP;
                }
                b_Score = true;
            }
        }
    }

    public static int GetScore()
    {
        return score;
    }
}
