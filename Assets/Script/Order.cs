using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //起動時刻でシード値確定
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //乱数でお題決定
    public int SelectOrder()
    {
        //完全乱数が嫌ならここに計算式


        //
        return Random.Range(Foodselect1.OMERICE, Foodselect1.RICEBALL + 1);
    }
}
