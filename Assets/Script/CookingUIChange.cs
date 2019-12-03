using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingUIChange : MonoBehaviour
{
    private Image _Image;
    public Sprite[] Sprite;

    //配列の番号
    private int UINum = 0;

    void Start()
    {
        _Image = GetComponent<Image>();
    }

    
    void Update()
    {
        _Image.sprite = Sprite[UINum];
    }

    /// <summary>
    /// 表示するUIに対応する番号を取得
    /// </summary>
    /// <param name="FoodsNum">CookingUI内の配列の番号</param>
    public void SetCookingUI(int FoodsNum)
    {
        UINum = FoodsNum;
    }
}
