using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//     A
//   B   C
//　　　　　の順
//
/// <summary>
/// 鍋に入っているものを表示するcanvasに入れる
/// </summary>
public class CookingUIPotParent : MonoBehaviour
{
    //private GameObject _Child;
    /// <summary>
    /// 子オブジェクト
    /// </summary>
    private GameObject CookUIA;
    private GameObject CookUIB;
    private GameObject CookUIC;

    /// <summary>
    /// 子オブジェクトスクリプト
    /// </summary>
    private CookingUIChange CookUIScriptA;
    private CookingUIChange CookUIScriptB;
    private CookingUIChange CookUIScriptC;

    private int UINumA = 0;
    private int UINumB = 0;
    private int UINumC = 0;

    [System.Obsolete]
    void Start()
    {
        
        CookUIA = transform.FindChild("CookingUIA").gameObject;
        CookUIB = transform.FindChild("CookingUIB").gameObject;
        CookUIC = transform.FindChild("CookingUIC").gameObject;

        CookUIScriptA = CookUIA.GetComponent<CookingUIChange>();
        CookUIScriptB = CookUIB.GetComponent<CookingUIChange>();
        CookUIScriptC = CookUIC.GetComponent<CookingUIChange>();

        transform.rotation = Quaternion.Euler(60.0f, 0.0f, 0.0f);
    }

    
    void Update()
    {
        
    }
    /// <summary>
    /// 上に表示するUIに対応する番号を取得
    /// </summary>
    /// <param name="FoodsNum">CookingUI内の配列の番号</param>
    public void SetUIA(int FoodsNum)
    {
        UINumA = FoodsNum;
        CookUIScriptA.SetCookingUI(UINumA);
    }
    /// <summary>
    /// 左下に表示するUIに対応する番号を取得
    /// </summary>
    /// <param name="FoodsNum">CookingUI内の配列の番号</param>
    public void SetUIB(int FoodsNum)
    {
        UINumB = FoodsNum;
        CookUIScriptB.SetCookingUI(UINumB);
    }
    /// <summary>
    /// 右下に表示するUIに対応する番号を取得
    /// </summary>
    /// <param name="FoodsNum">CookingUI内の配列の番号</param>
    public void SetUIC(int FoodsNum)
    {
        UINumC = FoodsNum;
        CookUIScriptC.SetCookingUI(UINumC);
    }
}
