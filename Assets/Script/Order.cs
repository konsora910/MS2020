using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class Order : MonoBehaviour
{
    public int[] n_FoodList = new int[20];

    // Start is called before the first frame update
    void Start()
    {
        //起動時刻でシード値確定
        Random.InitState(System.DateTime.Now.Millisecond);
        MakeList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MakeList()
    {
        for(int i = 0; i < 20;i++)
        {
            n_FoodList[i] = Random.Range(Foodselect1.OMERICE, Foodselect1.RICEBALL + 1);
        }
    }

    public int GetOrder(int FoodList)
    {
        return n_FoodList[FoodList];
    }
}
