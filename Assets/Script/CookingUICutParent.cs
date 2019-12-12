using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// まな板に入っているものを表示するcanvasに入れる
/// </summary>
public class CookingUICutParent : MonoBehaviour
{
    
    /// <summary>
    /// 子オブジェクト
    /// </summary>
    private GameObject CookUIA;
  


    /// <summary>
    /// 子オブジェクトスクリプト
    /// </summary>
    private CookingUIChange CookUIScriptA;
  
    private int UINumA = 0;
    
    [System.Obsolete]
    void Start()
    {

        CookUIA = transform.FindChild("CookingUIA").gameObject;
       
        CookUIScriptA = CookUIA.GetComponent<CookingUIChange>();
       

        transform.rotation = Quaternion.Euler(60.0f, 0.0f, 0.0f);
    }

    /// <summary>
    /// 表示するUIに対応する番号を取得
    /// </summary>
    /// <param name="FoodsNum">CookingUI内の配列の番号</param>
    public void SetUIA(int FoodsNum)
    {
        UINumA = FoodsNum;
        CookUIScriptA.SetCookingUI(UINumA);
    }
    

}
