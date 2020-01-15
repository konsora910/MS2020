using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCon : MonoBehaviour
{
    public bool b_food;
    public bool b_delatefood;
    public bool b_cooking;
    public bool b_foodtake;
    public bool b_foodin;
    [SerializeField] Pot pot;
    [SerializeField] PlayerController player;
    [SerializeField] CuttingBoard Cb;
    [SerializeField] FryingPan Fp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.bFood_Take == true)
            b_foodtake = true;
        Debug.Log(b_cooking);
        Debug.Log(b_delatefood);
        Debug.Log(b_food);
        Debug.Log(b_foodin);
        Debug.Log(b_foodtake);
        b_food = false;
        b_delatefood = false;
        b_cooking = false;
        b_foodtake = false;
        b_foodin = false;
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
            if (Collider.gameObject.tag == "pot")
            {
                if (Collider.gameObject.GetComponent<CuttingBoard>().food != null)
                {
                    b_delatefood = true;
                    b_cooking = true;
                }
            }
            //フライパンに触れている
            if (Collider.gameObject.tag == "pot")
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
