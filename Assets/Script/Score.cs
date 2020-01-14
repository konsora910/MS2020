using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int n_ListNum = 0;
    public static bool b_Score = false;
    public static int FoodType = Foodselect1.FOODNULL;
    public static int n_Order = 0;
    public OperatorController OpScript;
    public OrderGUI OrGUIScript;
    //仮置き
    public static GameObject scoreobj;
    public Order OrderScript;
    // Start is called before the first frame update
    public void Start()
    {
        score = 0;
        n_ListNum = 1;
        b_Score = false;

        //仮置き
        // scoreobj = GameObject.Find("order");

        //n_Order = scoreobj.GetComponent<Order>().GetOrder(0);

        n_Order = OrderScript.GetOrder(0);
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
                    //OpScript.CookEnd();
                    score += 300;
                    //n_Order = scoreobj.GetComponent<Order>().GetOrder(n_ListNum);
                    n_Order = OrderScript.GetOrder(n_ListNum);
                    n_ListNum++;
                }
                else
                    score += 30;
            }
            else if (FoodType == Foodselect1.RICEBALL)
            {
                if (n_Order == Foodselect1.RICEBALL)
                {
                    OpScript.CookEnd();
                    OrGUIScript.OrderNext();
                    //OpScript.CookEnd();
                    score += 100;
                    //n_Order = scoreobj.GetComponent<Order>().GetOrder(n_ListNum);
                    n_Order = OrderScript.GetOrder(n_ListNum);
                    n_ListNum++;
                }
                else
                    score += 10;
            }
            else if (FoodType == Foodselect1.SOUP)
            {
                if (n_Order == Foodselect1.SOUP)
                {
                    OpScript.CookEnd();
                    OrGUIScript.OrderNext();
                    //OpScript.CookEnd();
                    score += 200;
                    //n_Order = scoreobj.GetComponent<Order>().GetOrder(n_ListNum);
                    n_Order = OrderScript.GetOrder(n_ListNum);
                    n_ListNum++;
                }
                else
                    score += 20;
            }
            b_Score = false;
            FoodType = Foodselect1.FOODNULL;
        }
    }

    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "Omerice" || Collider.gameObject.tag == "RiceBall" || Collider.gameObject.tag == "Soup")
        {
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetButtonDown("Gamepad1_HoldSet"))
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

    public void CookTrue()
    {
        score += 20;
    }
}
