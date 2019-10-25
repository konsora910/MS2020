using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    public GameObject mainFood;
    public GameObject P;
    public PlayerController PControll;
    public string inFood;

    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("Player");
        PControll = P.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inFood == "ab" || inFood == "ba")
        {
            Debug.Log("omrice");
            inFood = inFood.Remove(0, 2);
        }
        else if (inFood == "bc" || inFood == "cb")
        {
            Debug.Log("トマ玉中華炒め");
            inFood = inFood.Remove(0, 2);
        }
        else if (inFood.Length == 2)
        {
            Debug.Log("ごみ屑");
            inFood = inFood.Remove(0, 2);
        }


    }

    void OnTriggerStay(Collider other)
    {
        if (PControll.bFood_Take == false)
        {
            Debug.Log("getFood");
            if (other.gameObject.tag == "rice")
            {
                Debug.Log("米！！");
                mainFood = GameObject.FindGameObjectWithTag("rice");
                mainFood.GetComponent<FoodController>().takeout = false;
                inFood += "a";
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "egg")
            {
                Debug.Log("タメェイゴォ");
                mainFood = GameObject.FindGameObjectWithTag("egg");
                mainFood.GetComponent<FoodController>().takeout = false;
                inFood += "b";
                Destroy(other.gameObject);
            }else
            if (other.gameObject.tag == "tmt")
            {
                Debug.Log("トメェイトォウ");
                mainFood = GameObject.FindGameObjectWithTag("tmt");
                mainFood.GetComponent<FoodController>().takeout = false;
                inFood += "c";
                Destroy(other.gameObject);
            }
        }
    }
}
