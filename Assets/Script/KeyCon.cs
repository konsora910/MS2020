using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCon : MonoBehaviour
{
    public static int AIASK = 0;
    public static int FOOD = 1;
    public static int FOODTAKE = 2;
    public static int COOKING = 3;
    public static int FOODIN = 4;
    public static int DELATEFOOD = 5;

    public bool b_food;
    public bool b_delatefood;
    public bool b_cooking;
    public bool b_foodtake;
    public bool b_foodin;
    public bool b_Ai;

    private int[] OperationList = new int[6];
    [SerializeField] Pot pot;
    [SerializeField] PlayerController player;
    [SerializeField] CuttingBoard Cb;
    [SerializeField] FryingPan Fp;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            OperationList[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        b_Ai = true;
        if (player.bFood_Take == true)
            b_foodtake = true;

        //リストに追加していく
        if (b_Ai == true)
            OperationList[0] = AIASK;
        if(b_food == true)
        {
            for (int i = 0; i < 6; i++)
            {
                if (OperationList[i] == -1)
                {
                    OperationList[i] = FOOD;
                    break;
                }
            }
        }
        if (b_foodtake == true)
        {
            for (int i = 0; i < 6; i++)
            {
                if (OperationList[i] == -1)
                {
                    OperationList[i] = FOODTAKE;
                    break;
                }
            }
        }
        if (b_cooking == true)
        {
            for (int i = 0; i < 6; i++)
            {
                if (OperationList[i] == -1)
                {
                    OperationList[i] = COOKING;
                    break;
                }
            }
        }
        if (b_cooking == true)
        {
            for (int i = 0; i < 6; i++)
            {
                if (OperationList[i] == -1)
                {
                    OperationList[i] = FOODIN;
                    break;
                }
            }
        }
        if (b_delatefood == true)
        {
            for (int i = 0; i < 6; i++)
            {
                if (OperationList[i] == -1)
                {
                    OperationList[i] = DELATEFOOD;
                    break;
                }
            }
        }

        //リストを空に
        for (int i = 0; i < 6; i++)
            OperationList[i] = -1;

        Debug.Log(b_cooking);
        Debug.Log(b_delatefood);
        Debug.Log(b_food);
        Debug.Log(b_foodin);
        Debug.Log(b_foodtake);

        //全部falseに
        b_food = false;
        b_delatefood = false;
        b_cooking = false;
        b_foodtake = false;
        b_foodin = false;
        b_Ai = false;
    }

    void OnTriggerStay(Collider Collider)
    {
        //食べ物を持っていない
        if (b_foodtake == false)
        {
            //食べ物に触れている
            if (Collider.gameObject.tag == "tmt" || Collider.gameObject.tag == "rice" || Collider.gameObject.tag == "egg" ||
                Collider.gameObject.tag == "Omerice" || Collider.gameObject.tag == "Soup" || Collider.gameObject.tag == "RiceBall")
            {
                b_food = true;
            }
            //ポットに触れている
            if(Collider.gameObject.tag == "pot")
            {
                if (Collider.gameObject.GetComponent<Pot>().PotArray[0] != null)
                {
                    b_delatefood = true;
                    if(pot.b_ReadyCook == true)
                        b_cooking = true;
                }
            }
            //まな板に触れている
            if (Collider.gameObject.tag == "CuttingBoard")
            {
                if (Collider.gameObject.GetComponent<CuttingBoard>().food != null)
                {
                    b_delatefood = true;
                    b_cooking = true;
                }
            }
            //フライパンに触れている
            if (Collider.gameObject.tag == "FP")
            {
                if (Collider.gameObject.GetComponent<FryingPan>().FPanArray[0] != null)
                {
                    b_delatefood = true;
                    if (Fp.b_ReadyCook == true)
                        b_cooking = true;
                }
            }
        }
        //食べ物を持っている
        if (b_foodtake == true)
        {
            //調理器具に触れている
            if (Collider.gameObject.tag == "pot" || Collider.gameObject.tag == "CuttingBoard" || Collider.gameObject.tag == "FP")
            {
                b_foodin = true;
            }
        }
    }
}
