using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// フライパンと鍋から現在入っているものを参照して各Canvasに表示するものを指示する
/// </summary>
public class CookingUI : MonoBehaviour
{
    /// <summary>
    /// オブジェクトからどれくらい離すか
    /// </summary>
    private Vector3 PositionShift=new Vector3(0.0f,2.0f,0.0f);
    private Vector3 LotationShiftLot = new Vector3(60.0f, 0.0f, 0.0f);



    /// <summary>
    /// UIの表示位置
    /// </summary>
    private Vector3 _FryingPanPositionA;
    private Vector3 _PotPositionA;
    private Vector3 _PotPositionB;
    private Vector3 _PotPositionC;
    private Vector3 _PotPositionD;

    /// <summary>
    /// CookingUIプレハブ
    /// </summary>
    public GameObject CookingUIPrefab;
    private GameObject _PotParentPrefabA;


    /// <summary>
    /// 各オブジェクト
    /// </summary>
    private GameObject _FryingPanObjectA;
    private GameObject _PotObjectA;

    /// <summary>
    /// 各スクリプト
    /// </summary>
    private FryingPan _FryingPanScriptA;          //フライパン
    private Pot _PotScriptA;                      //鍋
    private CookingUIPotParent _PotParentScriptA; //canvas

    /// <summary>
    /// 最初にUI配置する
    /// </summary>
    private bool StartUI=false;

    
    void Start()
    {
       // _FryingPanObjectA = GameObject.FindGameObjectWithTag("FP");
        //_FryingPanScriptA = _FryingPanObjectA.GetComponent<FryingPan>();
        _PotObjectA = GameObject.FindGameObjectWithTag("pot");
        _PotScriptA = _PotObjectA.GetComponent<Pot>();

        //FryingPanPosition= FryingPanScript

        //UI表示位置
        _PotPositionA = _PotScriptA.gameObject.transform.position;

        
    }

    void Update()
    {
        if (!StartUI)
        {
            _PotParentPrefabA = (GameObject)Instantiate(CookingUIPrefab, _PotPositionA + PositionShift, Quaternion.identity);
            _PotParentScriptA = _PotParentPrefabA.GetComponent<CookingUIPotParent>();
            StartUI = true;
        }
        else if(StartUI)
            {
            if (_PotScriptA.CurrentMode == Pot.Mode.Stay)
            {
                
                _PotParentScriptA.SetUIA(0);
                _PotParentScriptA.SetUIB(0);
                _PotParentScriptA.SetUIC(0);
                
            }
            else if (_PotScriptA.CurrentMode == Pot.Mode.Single)
            {
                if (_PotScriptA.PotArray[0].gameObject.tag == "egg")
                {
                    _PotParentScriptA.SetUIA(1);
                }
                else if (_PotScriptA.PotArray[0].gameObject.tag == "rice")
                {
                    _PotParentScriptA.SetUIA(2);
                }
                else if (_PotScriptA.PotArray[0].gameObject.tag == "tmt")
                {
                    _PotParentScriptA.SetUIA(3);
                }

            }
            else if (_PotScriptA.CurrentMode == Pot.Mode.Double)
            {
                if (_PotScriptA.PotArray[1].gameObject.tag == "egg")
                {
                    _PotParentScriptA.SetUIB(1);
                }
                else if (_PotScriptA.PotArray[1].gameObject.tag == "rice")
                {
                    _PotParentScriptA.SetUIB(2);
                }
                else if (_PotScriptA.PotArray[1].gameObject.tag == "tmt")
                {
                    _PotParentScriptA.SetUIB(3);
                }
            } else if (_PotScriptA.CurrentMode == Pot.Mode.Triple)
            {
                if (_PotScriptA.PotArray[2].gameObject.tag == "egg")
                {
                    _PotParentScriptA.SetUIC(1);
                }
                else if (_PotScriptA.PotArray[2].gameObject.tag == "rice")
                {
                    _PotParentScriptA.SetUIC(2);
                }
                else if (_PotScriptA.PotArray[2].gameObject.tag == "tmt")
                {
                    _PotParentScriptA.SetUIC(3);
                }
            }
        }
    }

    
    private void CookingUINone()
    {
        
        GameObject prefabA = (GameObject)Instantiate(CookingUIPrefab, _PotPositionA + PositionShift, transform.rotation * Quaternion.Euler(60.0f, 0.0f, 0.0f));
        


    }
    
}
