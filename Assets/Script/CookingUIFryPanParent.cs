using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//     
//   A   B
//　　　　　の順
//
/// <summary>
/// フライパンに入っているものを表示するcanvasに入れる
/// </summary>
public class CookingUIFryPanParent : MonoBehaviour
{
    //private GameObject _Child;
    /// <summary>
    /// 子オブジェクト
    /// </summary>
    private GameObject CookUIA;
    private GameObject CookUIB;
    

    /// <summary>
    /// 子オブジェクトスクリプト
    /// </summary>
    private CookingUIChange CookUIScriptA;
    private CookingUIChange CookUIScriptB;
    

    private int UINumA = 0;
    private int UINumB = 0;
    

    [System.Obsolete]
    void Start()
    {

        CookUIA = transform.FindChild("CookingUIA").gameObject;
        CookUIB = transform.FindChild("CookingUIB").gameObject;
        
        CookUIScriptA = CookUIA.GetComponent<CookingUIChange>();
        CookUIScriptB = CookUIB.GetComponent<CookingUIChange>();
        

        transform.rotation = Quaternion.Euler(60.0f, 0.0f, 0.0f);
    }


    void Update()
    {

    }
    /// <summary>
    /// 左に表示するUIに対応する番号を取得
    /// </summary>
    /// <param name="FoodsNum">CookingUI内の配列の番号</param>
    public void SetUIA(int FoodsNum)
    {
        UINumA = FoodsNum;
        CookUIScriptA.SetCookingUI(UINumA);
    }
    /// <summary>
    /// 右に表示するUIに対応する番号を取得
    /// </summary>
    /// <param name="FoodsNum">CookingUI内の配列の番号</param>
    public void SetUIB(int FoodsNum)
    {
        UINumB = FoodsNum;
        CookUIScriptB.SetCookingUI(UINumB);
    }
    
}
