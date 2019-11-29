using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public int n_Order = Foodselect1.FOODNULL;
    // Start is called before the first frame update
    void Start()
    {
        n_Order = Foodselect1.OMERICE;
        //起動時刻でシード値確定
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetOrder(bool change)
    {
        if(change == true)
            n_Order = SelectOrder();

        return n_Order;
    }

    //乱数でお題決定
    int SelectOrder()
    {
        //完全乱数が嫌ならここに計算式


        //
        return Random.Range(Foodselect1.OMERICE, Foodselect1.RICEBALL + 1);
    }
}
