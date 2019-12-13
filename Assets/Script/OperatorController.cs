using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorController : MonoBehaviour
{    
    private int cookKind = 10;
    private int foodKind = 10;
    public  int AILevel = 1;
    public int AIEXP = 0;
    public Order OrderScript;
    private int order;
    public bool FP1 = false;
    public bool FP2 = false;
    public bool FP3 = false;
    public bool Pot1 = false;
    public bool Pot2 = false;
    public bool Pot3 = false;
    public bool Cut1 = false;
    public bool Cut2 = false;
    public bool Cut3 = false;

    private bool Cook1 = false;
    private bool MissOpe = false;

    private bool end = true;

    public static readonly int FryingPan = 1;
    public static readonly int Pot = 2;
    public static readonly int CuttingBoard = 3;
    public static readonly int CookNull = 10;

    public static readonly int TFP = 21;
    public static readonly int TPot = 22;
    public static readonly int TCut = 23;
    public static readonly int EFP = 24;
    public static readonly int EPot = 25;
    public static readonly int ECut = 26;
    public static readonly int RFP = 27;
    public static readonly int RPot = 28;
    public static readonly int RCut = 29;

    public GameObject[] AILevelUI;


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
        if(AIEXP >= 10)
        {
            AIEXP = 0;
            AILevel++;
        }
       if(AIEXP < 0)
        {
            if(AILevel > 0)
            AIEXP = 5;
            AILevel--;
        }

        switch (AILevel)
        {
            case 0:
                AILevelUI[0].SetActive(false);
                AILevelUI[1].SetActive(false);
                AILevelUI[2].SetActive(false);
                AILevelUI[3].SetActive(false);
                break;
            case 1:
                AILevelUI[0].SetActive(true);
                AILevelUI[1].SetActive(false);
                AILevelUI[2].SetActive(false);
                AILevelUI[3].SetActive(false);
                break;
            case 2:
                AILevelUI[0].SetActive(true);
                AILevelUI[1].SetActive(true);
                AILevelUI[2].SetActive(false);
                AILevelUI[3].SetActive(false);
                break;
            case 3:
                AILevelUI[0].SetActive(true);
                AILevelUI[1].SetActive(true);
                AILevelUI[2].SetActive(true);
                AILevelUI[3].SetActive(false);
                break;
            case 4:
                AILevelUI[0].SetActive(true);
                AILevelUI[1].SetActive(true);
                AILevelUI[2].SetActive(true);
                AILevelUI[3].SetActive(true);
                AILevelUI[3].SetActive(true);
                break;

        }




    }

    IEnumerator Neutral()
    {
        while (true)
        {
          if(end == true)
            {
                end = false;
                StartCoroutine("CookStart");
                yield break;
            }
            Debug.Log("待機中");
            if(order == Foodselect1.RICEBALL)
            {
                if(FP1 == false)
                {
                    end = true;
                }
            }
            if (order == Foodselect1.SOUP)
            {
                if (Pot1 == false)
                {
                    end = true;
                }
            }
            if (order == Foodselect1.OMERICE)
            {
                if (FP1 == false)
                {
                    end = true;
                }
            }

            yield return null;
            
        }
    }
    IEnumerator CookStart()
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

        yield return null;
    }

    IEnumerator Operation()
    {
        while (true)
        {
            if (Foodselect1.OMERICE == order)
            {
                if (FP1 == true && FP2 == true && FP3 == true)
                {
                    StartCoroutine("Neutral");
                    yield break;
                }

            }
            if (order == Foodselect1.SOUP)
            {
                if (Pot1 == true && Pot2 == true)
                {
                    StartCoroutine("Neutral");
                    yield break;
                }
            }
            if (Foodselect1.RICEBALL == order)
            {
                if (FP1 == true)
                {
                    StartCoroutine("Neutral");
                    yield break;
                }

            }

            //正しい処理
            if (Foodselect1.RICEBALL == AiThink)
            {
                if (FP1 == false)
                {

                    if (RiceFP())
                    {
                        StartCoroutine("Thinking");
                        yield break;
                    }
                }

            }
         
            if (Foodselect1.SOUP == AiThink)
            {
                if (Pot1 == false && Pot2 == false)
                {

                    if (TomatoPot())
                    {
                        StartCoroutine("Thinking");
                        yield break;
                    }

                }
                else if (Pot1 == true && Pot2 == false)
                {

                    if (EggPot())
                    {
                        StartCoroutine("Thinking");
                        yield break;
                    }
                }

            }
          
            if (Foodselect1.OMERICE == AiThink)
            {
                if (FP1 == false && FP2 == false && FP3 == false)
                {
                    if (RiceFP())
                    {
                        StartCoroutine("Thinking");
                        yield break;
                    }
                }
                else if (FP1 == true && FP2 == false && FP3 == false)
                {

                    if (TomatoFP())
                    {
                        StartCoroutine("Thinking");
                        yield break;
                    }
                }
                else if (FP1 == true && FP2 == true && FP3 == false)
                {

                    if (EggFP())
                    {
                        StartCoroutine("Thinking");
                        yield break;
                    }
                }


            }
            //ここまで正しい処理
            if (Cook1 == false)
            {

                if (AiThink == TFP)
                {
                    TomatoFP();
                }
                if (AiThink == TPot)
                {
                    TomatoPot();
                }
                if (AiThink == TCut)
                {
                    TomatoCut();
                }
                if (AiThink == EFP)
                {
                    EggFP();
                }
                if (AiThink == EPot)
                {
                    EggPot();
                }
                if (AiThink == ECut)
                {
                    EggCut();
                }
                if (AiThink == RFP)
                {
                    RiceFP();
                }
                if (AiThink == RPot)
                {
                    RicePot();
                }
                if (AiThink == RCut)
                {
                    RiceCut();
                }
            }
            else
            {
                Cook1 = false;
                StartCoroutine("Thinking");
                yield break;
            }

            if(MissOpe == true)
            {
                if (order == AiThink)
                {
                    AIEXP--;
                }
                else
                {
                    AIEXP++;
                }
                

                    
                MissOpe = false;
                Debug.Log("それは違う");
                StartCoroutine("Thinking");
                yield break;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                MissOpe = true;
            }
            yield return null;

        }
    }

    public void Miss()
    {
        MissOpe = true;
    }

    IEnumerator Thinking()
    {
        while (true)
        {
          //  //正しい答え
          //  if (Probability(100))
          //  {
          //      AiThink = order;
          //      StartCoroutine("Operation");
          //      yield break;
          //  }

            switch (AILevel)
            {
                case 0:
                    if (Probability(10))
                    {
                        AiThink = order;
                        StartCoroutine("Operation");
                        yield break;
                    }
                    else
                    {
                        MissOperation();
                        StartCoroutine("Operation");
                        yield break;

                    }
                        break;
                case 1:
                    if (Probability(35))
                    {
                        AiThink = order;
                        StartCoroutine("Operation");
                        yield break;
                    }else
                    {
                        MissOperation();
                        StartCoroutine("Operation");
                        yield break;
                    }
                    break;
                case 2:
                    if (Probability(50))
                    {
                        AiThink = order;
                        StartCoroutine("Operation");
                        yield break;
                    }
                    else
                    {
                        MissOperation();
                        StartCoroutine("Operation");
                        yield break;
                    }
                    break;
                case 3:
                    if (Probability(70))
                    {
                        AiThink = order;
                        StartCoroutine("Operation");
                        yield break;
                    }
                    else
                    {
                        MissOperation();
                        StartCoroutine("Operation");
                        yield break;
                    }
                    break;
                case 4:
                    if (Probability(90))
                    {
                        AiThink = order;
                        StartCoroutine("Operation");
                        yield break;
                    }
                    else
                    {
                        MissOperation();
                        StartCoroutine("Operation");
                        yield break;

                    }
                    break;

            }

            yield return null;
        }
    }

    void MissOperation()
    {
        if (order == Foodselect1.RICEBALL)
        {
            do
            {
                AiThink = Random.Range(TFP, RCut + 1);

            } while (AiThink == RFP);

        }

        if (order == Foodselect1.SOUP)
        {
            do
            {
                AiThink = Random.Range(TFP, RCut + 1);

            } while (AiThink == TPot || AiThink == EPot);

        }
        if (order == Foodselect1.OMERICE)
        {
            do
            {
                AiThink = Random.Range(TFP, RCut + 1);

            } while (AiThink == RFP || AiThink == EFP || AiThink == TFP);
        }
    }
    bool RiceFP()
    {
            Debug.Log("米をフライパンへ");
            if (foodKind == Foodselect1.RICE)
            {
                if (cookKind == OperatorController.FryingPan)
                {
                if (AiThink == Foodselect1.RICEBALL || AiThink == Foodselect1.OMERICE)
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
                    Debug.Log("指示通りで正しい処理");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP++;
                    return true;

                }else if(AiThink == RFP)
                {
                    Debug.Log("指示通りだけど正しくない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP--;
                    return false;
                }


                       
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("指示通りじゃない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP--;
                return false;
            }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("指示通りじゃない処理");
                Cook1 = true;
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
                AIEXP--;
                return false;
           }
        return false;
    }

    bool TomatoFP()
    {
  
       
            Debug.Log("トマトをフライパンへ");
            if (foodKind == Foodselect1.TOMATO)
            {
               
                if (cookKind == OperatorController.FryingPan)
                 {
                    if (AiThink == Foodselect1.OMERICE)
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
                        Debug.Log("指示通り正しい処理");
                        foodKind = Foodselect1.FOODNULL;
                        cookKind = OperatorController.CookNull;
                        AIEXP++;
                        return true;
                    }else if (AiThink == TFP)
                    {
                    Debug.Log("指示通りだけど正しくない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP--;
                }

                  }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("指示通りじゃない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                AIEXP--;
            }
    
            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("指示通りじゃない処理");
                Cook1 = true;
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            AIEXP--;
        }
        return false;
    
    }

    bool EggFP()
    {


        Debug.Log("卵をフライパンへ");
        if (foodKind == Foodselect1.EGG)
        {
            if (cookKind == OperatorController.FryingPan)
            {
                if (AiThink == Foodselect1.OMERICE)
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
                    Debug.Log("指示通り正しい処理");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP++;
                    return true;
                }else if(AiThink == EFP)
                {
                    Debug.Log("指示通りだけど正しくない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP--;
                }
            }
            else if (cookKind != OperatorController.CookNull)
            {
                Debug.Log("指示通りじゃない処理");
                Cook1 = true;
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
                AIEXP--;
            }

        }
        else if (foodKind != Foodselect1.FOODNULL)
        {
            Debug.Log("指示通りじゃない処理");
            Cook1 = true;
            foodKind = Foodselect1.FOODNULL;
            cookKind = OperatorController.CookNull;
            AIEXP--;
        }


        return false;
    }

    void RiceCut()
    {


        Debug.Log("米をまな板へ");
        if (foodKind == Foodselect1.RICE)
        {
           
            if (cookKind == OperatorController.CuttingBoard)
            {
                    //
                    //if (Cut1 == false && Cut2 == false && Cut3 == false)
                    //{
                    //    Cut1 = true;
                    //}
                    //else if (Cut1 == true && Cut2 == false && Cut3 == false)
                    //{
                    //    Cut2 = true;
                    //}
                    //else if (Cut1 == true && Cut2 == true && Cut3 == false)
                    //{
                    //    Cut3 = true;
                    //}
                    //Debug.Log("正解");
                    //foodKind = Foodselect1.FOODNULL;
                    //cookKind = OperatorController.CookNull;
                if(AiThink == RCut)
                {
                    Debug.Log("指示通りだけど正しくない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP--;
                }
            }
            else if (cookKind != OperatorController.CookNull)
            {
                Debug.Log("指示通りじゃない処理");
                Cook1 = true;
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
                AIEXP--;
            }

        }
        else if (foodKind != Foodselect1.FOODNULL)
        {
            Debug.Log("指示通りじゃない処理");
            Cook1 = true;
            foodKind = Foodselect1.FOODNULL;
            cookKind = OperatorController.CookNull;
            AIEXP--;
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
                    //if (Cut1 == false && Cut2 == false && Cut3 == false)
                    //{
                    //Cut1 = true;
                    //}
                    //else if (Cut1 == true && Cut2 == false && Cut3 == false)
                    //{
                    //Cut2 = true;
                    //}
                    //else if (Cut1 == true && Cut2 == true && Cut3 == false)
                    //{
                    //Cut3 = true;
                    //}
                    //Debug.Log("正解");
                    //foodKind = Foodselect1.FOODNULL;
                    //cookKind = OperatorController.CookNull;
                    if(AiThink == TCut)
                    {
                      Debug.Log("指示通りだけど正しくない処理");
                      Cook1 = true;
                      foodKind = Foodselect1.FOODNULL;
                      cookKind = OperatorController.CookNull;
                    AIEXP--;
                    }
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("指示通りじゃない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                AIEXP--;
            }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("指示通りじゃない処理");
                Cook1 = true;
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            AIEXP--;
        }


    }

    void EggCut()
    {


            Debug.Log("卵をまな板へ");
            if (foodKind == Foodselect1.EGG)
            {
                if (cookKind == OperatorController.CuttingBoard)
                {
                    //if (Cut1 == false && Cut2 == false && Cut3 == false)
                    //{
                    //Cut1 = true;
                    //}
                    //else if (Cut1 == true && Cut2 == false && Cut3 == false)
                    //{
                    //Cut2 = true;
                    //}
                    //else if (Cut1 == true && Cut2 == true && Cut3 == false)
                    //{
                    //Cut3 = true;
                    //}
                    //Debug.Log("正解");
                    //foodKind = Foodselect1.FOODNULL;
                    //cookKind = OperatorController.CookNull;
                    if(AiThink == ECut)
                    {
                    Debug.Log("指示通りだけど正しくない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP--;
                    }
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("指示通りじゃない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                AIEXP--;
            }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("指示通りじゃない処理");
                Cook1 = true;
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            AIEXP--;
        }

    }

    void RicePot()
    {


            Debug.Log("米を鍋へ");
            if (foodKind == Foodselect1.RICE)
            {
                if (cookKind == OperatorController.Pot)
                {
                    //if (Pot1 == false && Pot2 == false && Pot3 == false)
                    //{
                    //Pot1 = true;
                    //}
                    //else if (Pot1 == true && Pot2 == false && Pot3 == false)
                    //{
                    //Pot2 = true;
                    //}
                    //else if (Pot1 == true && Pot2 == true && Pot3 == false)
                    //{
                    //Pot3 = true;
                    //}
                    //Debug.Log("正解");
                    //foodKind = Foodselect1.FOODNULL;
                    //cookKind = OperatorController.CookNull;
                    if(AiThink == RPot)
                    {
                    Debug.Log("指示通りだけど正しくない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP--;
                }
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("指示通りじゃない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                AIEXP--;
            }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("指示通りじゃない処理");
                Cook1 = true;
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            AIEXP--;
        }


    }

    bool TomatoPot()
    {
        Debug.Log("トマトを鍋へ");
        if (foodKind == Foodselect1.TOMATO)
        {
            if (cookKind == OperatorController.Pot)
            {
                if (AiThink == Foodselect1.SOUP)
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
                    Debug.Log("指示通り正しい処理");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP++;
                    return true;
                }else if(AiThink == TPot)
                {
                    Debug.Log("指示通りだけど正しくない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP--;
                }
            }
            else if (cookKind != OperatorController.CookNull)
            {
                Debug.Log("指示通りじゃない処理");
                Cook1 = true;
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
                AIEXP--;
            }

        }
        else if (foodKind != Foodselect1.FOODNULL)
        {
            Debug.Log("指示通りじゃない処理");
            Cook1 = true;
            foodKind = Foodselect1.FOODNULL;
            cookKind = OperatorController.CookNull;
            AIEXP--;
        }
        return false;
    }

    bool EggPot()
    {

            Debug.Log("卵を鍋へ");
            if (foodKind == Foodselect1.EGG)
            {
                if (cookKind == OperatorController.Pot)
                {
                if (AiThink == Foodselect1.SOUP)
                {


                    if (Pot1 == false && Pot2 == false && Pot3 == false)
                    {
                        Cut1 = true;
                    }
                    else if (Pot1 == true && Pot2 == false && Pot3 == false)
                    {
                        Pot2 = true;
                    }
                    else if (Pot1 == true && Pot2 == true && Pot3 == false)
                    {
                        Pot3 = true;
                    }

                    Debug.Log("指示通り正しい処理");
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP++;
                    return true;
                }else if (AiThink == EPot)
                {
                    Debug.Log("指示通りだけど正しくない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                    AIEXP--;
                }
                }
                else if (cookKind != OperatorController.CookNull)
                {
                    Debug.Log("指示通りじゃない処理");
                    Cook1 = true;
                    foodKind = Foodselect1.FOODNULL;
                    cookKind = OperatorController.CookNull;
                AIEXP--;
            }

            }
            else if (foodKind != Foodselect1.FOODNULL)
            {
                Debug.Log("指示通りじゃない処理");
                Cook1 = true;
                foodKind = Foodselect1.FOODNULL;
                cookKind = OperatorController.CookNull;
            AIEXP--;
        }
        return false;
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

    public void CookEnd()
    {
        if (Foodselect1.OMERICE == order)
        {
            FPReset();

        }
        if (order == Foodselect1.SOUP)
        {
            PotReset();
        }
        if (Foodselect1.RICEBALL == order)
        {
            FPReset();
        }
        ClearCook++;
        end = true;
    }








}
