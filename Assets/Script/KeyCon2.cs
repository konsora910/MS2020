using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCon2 : MonoBehaviour
{
    GameObject Action0;
    GameObject Action1;
    GameObject Action2;
    GameObject Action3;
    GameObject Action4;
    GameObject Action5;
    GameObject Action6;
    GameObject Action7;

    public static int LIST_NUM = 3;

    public bool b_food;
    public bool b_delatefood;
    public bool b_cooking;
    public bool b_foodtake;
    public bool b_foodinnabe;
    public bool b_foodinmanaita;
    public bool b_foodinfrypan;
    public bool b_Ai;

    private GameObject[] OperationList = new GameObject[LIST_NUM];
    private GameObject[] OperationListOld = new GameObject[LIST_NUM];
    [SerializeField] Pot pot;
    [SerializeField] PlayerController player;
    [SerializeField] CuttingBoard Cb;
    [SerializeField] FryingPan Fp;
    // Start is called before the first frame update
    void Start()
    {
        Action0 = GameObject.Find("Action02");
        Action0.SetActive(false);
        Action1 = GameObject.Find("Action12");
        Action1.SetActive(false);
        Action2 = GameObject.Find("Action22");
        Action2.SetActive(false);
        Action3 = GameObject.Find("Action32");
        Action3.SetActive(false);
        Action4 = GameObject.Find("Action42");
        Action4.SetActive(false);
        Action5 = GameObject.Find("Action52");
        Action5.SetActive(false);
        Action6 = GameObject.Find("Action62");
        Action6.SetActive(false);
        Action7 = GameObject.Find("Action72");
        Action7.SetActive(false);

        for (int i = 0; i < LIST_NUM; i++)
        {
            OperationList[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //リストを空に
        for (int i = 0; i < LIST_NUM; i++)
        {
            if (OperationList[i] != null)
            {
                OperationList[i].SetActive(false);
                OperationList[i] = null;
            }
        }

        b_Ai = true;

        b_foodtake = player.bFood_Take;

        //リストに追加していく
        if (b_Ai == true)
            OperationList[0] = Action0;
        if (b_delatefood == true)
        {
            for (int i = 0; i < LIST_NUM; i++)
            {
                if (OperationList[i] == null)
                {
                    OperationList[i] = Action7;
                    break;
                }
            }
        }
        if (b_food == true)
        {
            for (int i = 0; i < LIST_NUM; i++)
            {
                if (OperationList[i] == null)
                {
                    OperationList[i] = Action1;
                    break;
                }
            }
        }
        else if (b_cooking == true)
        {
            for (int i = 0; i < LIST_NUM; i++)
            {
                if (OperationList[i] == null)
                {
                    OperationList[i] = Action3;
                    break;
                }
            }
        }
        else if (b_foodinnabe == true)
        {
            for (int i = 0; i < LIST_NUM; i++)
            {
                if (OperationList[i] == null)
                {
                    OperationList[i] = Action4;
                    break;
                }
            }
        }
        else if (b_foodinmanaita == true)
        {
            for (int i = 0; i < LIST_NUM; i++)
            {
                if (OperationList[i] == null)
                {
                    OperationList[i] = Action5;
                    break;
                }
            }
        }
        else if (b_foodinfrypan == true)
        {
            for (int i = 0; i < LIST_NUM; i++)
            {
                if (OperationList[i] == null)
                {
                    OperationList[i] = Action6;
                    break;
                }
            }
        }
        else if (b_foodtake == true)
        {
            for (int i = 0; i < LIST_NUM; i++)
            {
                if (OperationList[i] == null)
                {
                    OperationList[i] = Action2;
                    break;
                }
            }
        }

        for (int i = 0; i < LIST_NUM; i++)
        {
            if (OperationList[i] != null)
            {
                OperationList[i].SetActive(true);

                OperationList[i].transform.position = new Vector3(1770.0f, 820.0f - (i * 60.0f), 0.0f);
            }
        }

        //全部falseに
        b_food = false;
        b_delatefood = false;
        b_cooking = false;
        b_foodinnabe = false;
        b_foodinmanaita = false;
        b_foodinfrypan = false;
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
            if (Collider.gameObject.tag == "pot")
            {
                if (Collider.gameObject.GetComponent<Pot>().PotArray[0] != null)
                {
                    b_delatefood = true;
                    if (pot.b_ReadyCook == true)
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
            if (Collider.gameObject.tag == "pot")
            {
                b_foodinnabe = true;
            }
            if (Collider.gameObject.tag == "FP")
            {
                b_foodinfrypan = true;
            }
            if (Collider.gameObject.tag == "CuttingBoard")
            {
                b_foodinmanaita = true;
            }
        }
    }
}
