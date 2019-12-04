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
    private bool FP1 = false;
    private bool FP2 = false;
    private bool FP3 = false;
    private bool Pot1 = false;
    private bool Pot2 = false;
    private bool Pot3 = false;
    private bool Cut1 = false;
    private bool Cut2 = false;
    private bool Cut3 = false;

    public static readonly int FryingPan = 1;
    public static readonly int Pot = 2;
    public static readonly int CuttingBoard = 3;
    public static readonly int CookNull = 10;
    int ClearCook = 0;
    int AiThink = Foodselect1.FOODNULL;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Neutral");
       
    }

    // Update is called once per frame
    void Update()
    {

       

    }

    IEnumerator Neutral()
    {
        while (true)
        {
            order = OrderScript.GetOrder(ClearCook);
            if (order == Foodselect1.RICEBALL)
            {
                Debug.Log("焼きおにぎりを作ろう");
                StartCoroutine("Thinking");
                yield break;
            }
            if (order == Foodselect1.SOUP)
            {
                Debug.Log("スープを作ろう");
                StartCoroutine("Thinking");
                yield break;
            }
            if (order == Foodselect1.OMERICE)
            {
                Debug.Log("オムライスを作ろう");
                StartCoroutine("Thinking");
                yield break;
            }
           yield return null;
            
        }
    }


    IEnumerator Operation()
    {
        while (true)
        {
            if (Foodselect1.RICEBALL == order)
            {
                if (FP1 == false)
                {
                    RiceFP();
                }else if(FP1  == true)
                {
                    ClearCook++;
                    FPReset();
                    StartCoroutine("Neutral");
                    yield break;
                }

            }
            if (Foodselect1.SOUP == order)
            {
                if (Pot1 == false && Pot2 == false)
                {
                    TomatoPot();

                }
                else if (Pot1 == true && Pot2 == false)
                {
                    EggPot();
                }else if(Pot1 == true && Pot2 == true)
                {
                    ClearCook++;
                    PotReset();
                    StartCoroutine("Neutral");
                    yield break;
                }

            }

            if (Foodselect1.OMERICE == order)
            {
                if (FP1 == false && FP2 == false && FP3 == false)
                {
                    RiceFP();
                }
                else if (FP1 == true && FP2 == false && FP3 == false)
                {
                    TomatoFP();
                }
                else if (FP1 == true && FP2 == true && FP3 == false)
                {
                    EggFP();
                }else if(FP1 == true && FP2 == true && FP3 == true)
                {
                    ClearCook++;
                    FPReset();
                    StartCoroutine("Neutral");
                    yield break;
                }

            }

            yield return null;

        }
    }
    IEnumerator Thinking()
    {
        while (true)
        {
            //正しい答え
            if (Probability(100))
            {
                AiThink = order;
                StartCoroutine("Operation");
                yield break;
            }
            


            yield return null;
        }
    }

    void RiceFP()
    {

       
            Debug.Log("米をフライパンへ");
            if (foodKind == Foodselect1.RICE)
            {
                    if (cookKind == OperatorController.FryingPan)
                    {
                    if (FP1 == false && FP2 == false && FP3 == false)
                    {
                        FP1 = true;
                    }
                    else if (FP1 == true && FP2 == false && FP3 == false)
                    {
                        FP2 = true;
                    }
                    else if (FP1 == true && FP2 == true && FP3 == false)
                    {
                    FP3 = true;
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
                    if (FP1 == false && FP2 == false && FP3 == false)
                    {
                    FP1 = true;
                    }
                    else if (FP1 == true && FP2 == false && FP3 == false)
                    {
                    FP2 = true;
                    }
                    else if (FP1 == true && FP2 == true && FP3 == false)
                    {
                    FP3 = true;
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
                if (FP1 == false && FP2 == false && FP3 == false)
                {
                    FP1 = true;
                }
                else if (FP1 == true && FP2 == false && FP3 == false)
                {
                    FP2 = true;
                }
                else if (FP1 == true && FP2 == true && FP3 == false)
                {
                    FP3 = true;
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
                if (Cut1 == false && Cut2 == false && Cut3 == false)
                {
                    Cut1 = true;
                }
                else if (Cut1 == true && Cut2 == false && Cut3 == false)
                {
                    Cut2 = true;
                }
                else if (Cut1 == true && Cut2 == true && Cut3 == false)
                {
                    Cut3 = true;
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
                    if (Cut1 == false && Cut2 == false && Cut3 == false)
                    {
                    Cut1 = true;
                    }
                    else if (Cut1 == true && Cut2 == false && Cut3 == false)
                    {
                    Cut2 = true;
                    }
                    else if (Cut1 == true && Cut2 == true && Cut3 == false)
                    {
                    Cut3 = true;
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
                    if (Cut1 == false && Cut2 == false && Cut3 == false)
                    {
                    Cut1 = true;
                    }
                    else if (Cut1 == true && Cut2 == false && Cut3 == false)
                    {
                    Cut2 = true;
                    }
                    else if (Cut1 == true && Cut2 == true && Cut3 == false)
                    {
                    Cut3 = true;
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


            Debug.Log("米を鍋へ");
            if (foodKind == Foodselect1.RICE)
            {
                if (cookKind == OperatorController.Pot)
                {
                    if (Pot1 == false && Pot2 == false && Pot3 == false)
                    {
                    Pot1 = true;
                    }
                    else if (Pot1 == true && Pot2 == false && Pot3 == false)
                    {
                    Pot2 = true;
                    }
                    else if (Pot1 == true && Pot2 == true && Pot3 == false)
                    {
                    Pot3 = true;
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
                if (Pot1 == false && Pot2 == false && Pot3 == false)
                {
                    Pot1 = true;
                }
                else if (Pot1 == true && Pot2 == false && Pot3 == false)
                {
                    Pot2 = true;
                }
                else if (Pot1 == true && Pot2 == true && Pot3 == false)
                {
                    Pot3 = true;
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
                    if (Pot1 == false && Pot2 == false && Pot3 == false)
                    {
                    Cut1 = true;
                    }
                    else if (Pot1 == true && Pot2 == false &&Pot3 == false)
                    {
                        Pot2 = true;
                    }
                    else if (Pot1 == true && Pot2 == true && Pot3 == false)
                    {
                    Pot3 = true;
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



    public void PotReset()
    {
        Pot1 = false;
        Pot2 = false;
        Pot3 = false;
    }
    public void FPReset()
    {
        FP1 = false;
        FP2 = false;
        FP3 = false;
    }
    public void CutReset()
    {
        Cut1 = false;
        Cut2 = false;
        Cut3 = false;
    }










}
