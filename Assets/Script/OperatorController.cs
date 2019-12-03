using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorController : MonoBehaviour
{    
    private int cookKind = 10;
    private int foodKind = 10;
    private int AILevel = 1;
    public Order OrderScript;
    private int order;
    private bool cook1 = false;
    private bool cook2 = false;
    private bool cook3 = false;
    public static readonly int FryingPan = 1;
    public static readonly int Pot = 2;
    public static readonly int CuttingBoard = 3;
    public static readonly int CookNull = 10;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Neutral");
       
    }

    // Update is called once per frame
    void Update()
    {
        order = OrderScript.GetOrder(0);
        if(order == Foodselect1.RICEBALL)
        {
            Debug.Log("焼きおにぎりを作ろう");
        }
        if(order == Foodselect1.SOUP)
        {
            Debug.Log("スープを作ろう");
        }
        if (order == Foodselect1.OMERICE)
        {
            Debug.Log("オムライスを作ろう");
        }
        Cook();
    }

    IEnumerator Neutral()
    {
        while (true)
        {


            yield return null;
            
        }
    }


    IEnumerator Order()
    {
        while (true)
        {


            yield return null;

        }
    }
    void Cook() //正しい処理とは
    {
        
        if(Foodselect1.RICEBALL == order)
        {
            RiceFP();

        }
        if(Foodselect1.SOUP == order)
        {
            if(cook1 == false && cook2 == false)
            {
                TomatoPot(); 

            }else if(cook1 == true && cook2 == false)
            {
                EggPot();
            }

        }

        if(Foodselect1.OMERICE == order)
        {
            if(cook1 == false && cook2 == false && cook3 ==false)
            {
                RiceFP();
            }else if(cook1 == true && cook2 == false && cook3 == false)
            {
                TomatoFP();
            }else if(cook1 == true && cook2 == true && cook3 == false)
            {
                EggFP();
            }

        }

    }

    void RiceFP()
    {

       
            Debug.Log("米をフライパンへ");
            if (foodKind == Foodselect1.RICE)
            {
                    if (cookKind == OperatorController.FryingPan)
                    {
                    if (cook1 == false && cook2 == false && cook3 == false)
                    {
                        cook1 = true;
                    }
                    else if (cook1 == true && cook2 == false && cook3 == false)
                    {
                        cook2 = true;
                    }
                    else if (cook1 == true && cook2 == true && cook3 == false)
                    {
                        cook3 = true;
                    }
                    Debug.Log("正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("不正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("不正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }
       
    }

    void TomatoFP()
    {
  
       
            Debug.Log("トマトをフライパンへ");
            if (foodKind == Foodselect1.TOMATO)
            {
                    if (cookKind == OperatorController.FryingPan)
                    {
                    if (cook1 == false && cook2 == false && cook3 == false)
                    {
                        cook1 = true;
                    }
                    else if (cook1 == true && cook2 == false && cook3 == false)
                    {
                        cook2 = true;
                    }
                    else if (cook1 == true && cook2 == true && cook3 == false)
                    {
                        cook3 = true;
                    }
                    Debug.Log("正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("不正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }
    
            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("不正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }
        
    
    }

    void EggFP()
    {
        

            Debug.Log("卵をフライパンへ");
            if (foodKind == Foodselect1.EGG)
            {
                if (cookKind == OperatorController.FryingPan)
                    {
                    if (cook1 == false && cook2 == false && cook3 == false)
                    {
                        cook1 = true;
                    }
                    else if (cook1 == true && cook2 == false && cook3 == false)
                    {
                        cook2 = true;
                    }
                    else if (cook1 == true && cook2 == true && cook3 == false)
                    {
                        cook3 = true;
                    }
                    Debug.Log("正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("不正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("不正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }


    }

    void RiceCut()
    {


        Debug.Log("米をまな板へ");
        if (foodKind == Foodselect1.RICE)
        {
            if (cookKind == OperatorController.CuttingBoard)
            {
                if (cook1 == false && cook2 == false && cook3 == false)
                {
                    cook1 = true;
                }
                else if (cook1 == true && cook2 == false && cook3 == false)
                {
                    cook2 = true;
                }
                else if (cook1 == true && cook2 == true && cook3 == false)
                {
                    cook3 = true;
                }
                Debug.Log("正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }
            else if (cookKind != OperatorController.CookNull)
            {
                Debug.Log("不正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }

        }
        else if (foodKind != Foodselect1.FOODNULL)
        {
            Debug.Log("不正解");
            foodKind = Foodselect1.FOODNULL;
            cookKind = OperatorController.CookNull;
        }

    }

    void TomatoCut()
    {


            Debug.Log("トマトをまな板へ");
            if (foodKind == Foodselect1.TOMATO
)
            {
                    if (cookKind == OperatorController.CuttingBoard)
                    {
                    if (cook1 == false && cook2 == false && cook3 == false)
                    {
                        cook1 = true;
                    }
                    else if (cook1 == true && cook2 == false && cook3 == false)
                    {
                        cook2 = true;
                    }
                    else if (cook1 == true && cook2 == true && cook3 == false)
                    {
                        cook3 = true;
                    }
                    Debug.Log("正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("不正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("不正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }


    }

    void EggCut()
    {


            Debug.Log("卵をまな板へ");
            if (foodKind == Foodselect1.EGG)
            {
                if (cookKind == OperatorController.CuttingBoard)
                {
                    if (cook1 == false && cook2 == false && cook3 == false)
                    {
                        cook1 = true;
                    }
                    else if (cook1 == true && cook2 == false && cook3 == false)
                    {
                        cook2 = true;
                    }
                    else if (cook1 == true && cook2 == true && cook3 == false)
                    {
                        cook3 = true;
                    }
                    Debug.Log("正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("不正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("不正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }

    }

    void RicePot()
    {


            Debug.Log("米を鍋へへ");
            if (foodKind == Foodselect1.RICE)
            {
                if (cookKind == OperatorController.Pot)
                {
                    if (cook1 == false && cook2 == false && cook3 == false)
                    {
                        cook1 = true;
                    }
                    else if (cook1 == true && cook2 == false && cook3 == false)
                    {
                        cook2 = true;
                    }
                    else if (cook1 == true && cook2 == true && cook3 == false)
                    {
                        cook3 = true;
                    }
                    Debug.Log("正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("不正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("不正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }


    }

    void TomatoPot()
    {

            Debug.Log("トマトを鍋へ");
            if (foodKind == Foodselect1.TOMATO)
            {
                if (cookKind == OperatorController.Pot)
                {
                    if(cook1 ==false && cook2 == false && cook3 ==false)
                    {
                        cook1 = true;
                    }else if(cook1 ==true && cook2 == false && cook3 == false)
                     {
                        cook2 = true;
                     }else if(cook1 == true && cook2 == true && cook3 == false)
                     {
                        cook3 = true;
                     }


                        
                    Debug.Log("正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("不正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("不正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }

    }

    void EggPot()
    {

            Debug.Log("卵を鍋へ");
            if (foodKind == Foodselect1.EGG)
            {
                if (cookKind == OperatorController.Pot)
                {
                    if (cook1 == false && cook2 == false && cook3 == false)
                    {
                        cook1 = true;
                    }
                    else if (cook1 == true && cook2 == false && cook3 == false)
                    {
                        cook2 = true;
                    }
                    else if (cook1 == true && cook2 == true && cook3 == false)
                    {
                        cook3 = true;
                    }

                    Debug.Log("正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("不正解");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("不正解");
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            }

    }

    public static bool Probability(float fPercent)
        {
            float fProbabilityRate = UnityEngine.Random.value * 100.0f;

            if (fPercent == 100.0f && fProbabilityRate == fPercent)
            {
                return true;
            }
            else if (fProbabilityRate < fPercent)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void FoodKind(int num)
        {
            foodKind = num;
        }

        public void CookKind(int num)
        {
            cookKind = num;
        }








    







}
