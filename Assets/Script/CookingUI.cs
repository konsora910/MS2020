using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


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
    [SerializeField] private Vector3[] _FryingPanPosition;

    [SerializeField] private Vector3[] _PotPosition;
    


    /// <summary>
    /// セット用CookingUIプレハブ
    /// </summary>
    public GameObject FryingPanParentPrefab;
    public GameObject PotParentPrefab;

    //UIプレハブ管理
    [SerializeField] private GameObject[] _FryingPanPrefabArray;
    [SerializeField] private GameObject[] _PotPrefabArray;

    /// <summary>
    /// 各オブジェクト
    /// </summary>
    [SerializeField] private GameObject[] _FryingPanObject;
    [SerializeField] private GameObject[] _PotObject;

    /// <summary>
    /// 各スクリプト
    /// </summary>
    private FryingPan[] _FryingPanScript;          //フライパン
    private Pot[] _PotScript;                      //鍋
    private CookingUIPotParent[] _PotParentScript; //canvas
    private CookingUIFryPanParent[] _FryingPanParentScript; //canvas

    /// <summary>
    /// 最初にUI配置する
    /// </summary>
    [SerializeField] private bool StartUI=false;

    
    void Start()
    {
        //フライパンと鍋のタグ付いているもの取得
        _FryingPanObject = GameObject.FindGameObjectsWithTag("FP");
        _PotObject = GameObject.FindGameObjectsWithTag("pot");


        //配列サイズ変更
        Array.Resize(ref _FryingPanPosition, _FryingPanObject.Length );
        Array.Resize(ref _PotPosition, _PotObject.Length );
        Array.Resize(ref _FryingPanScript, _FryingPanObject.Length);
        Array.Resize(ref _PotScript, _PotObject.Length);
        Array.Resize(ref _FryingPanParentScript, _FryingPanObject.Length);
        Array.Resize(ref _PotParentScript, _FryingPanObject.Length);
        Array.Resize(ref _FryingPanPrefabArray, _FryingPanObject.Length);
        Array.Resize(ref _PotPrefabArray, _PotObject.Length);


        //スクリプト、位置取得
        for (int i = 0; i < _FryingPanObject.Length; i++)
        {
            _FryingPanScript[i] = _FryingPanObject[i].GetComponent<FryingPan>();
            _FryingPanPosition[i] = _FryingPanScript[i].gameObject.transform.position;
        }
        for (int i = 0; i < _PotObject.Length; i++)
        {
            _PotScript[i] = _PotObject[i].GetComponent<Pot>();
            _PotPosition[i] = _PotScript[i].gameObject.transform.position;
        }

    }

    void Update()
    {
        if (!StartUI)
        {
            //プレハブ生成,スクリプト取得
            for (int i=0; i< _FryingPanObject.Length; i++)
            {
                _FryingPanPrefabArray[i] = (GameObject)Instantiate(FryingPanParentPrefab, _FryingPanPosition[i] + PositionShift, Quaternion.identity);
                _FryingPanParentScript[i] = _FryingPanPrefabArray[i].GetComponent<CookingUIFryPanParent>();
            }
            for (int i = 0; i < _PotObject.Length; i++)
            {
                _PotPrefabArray[i] = (GameObject)Instantiate(PotParentPrefab, _PotPosition[i] + PositionShift, Quaternion.identity);
                _PotParentScript[i] = _PotPrefabArray[i].GetComponent<CookingUIPotParent>();
            }
            
                StartUI = true;
        }
        else if(StartUI)
            {
            for (int i = 0; i < _PotObject.Length; i++)
            {
                if (_PotScript[i].CurrentMode == Pot.Mode.Stay)
                {

                    _PotParentScript[i].SetUIA(0);
                    _PotParentScript[i].SetUIB(0);
                    _PotParentScript[i].SetUIC(0);

                }
                else if (_PotScript[i].CurrentMode == Pot.Mode.Single)
                {
                    if (_PotScript[i].PotArray[0].gameObject.tag == "egg")
                    {
                        _PotParentScript[i].SetUIA(1);
                    }
                    else if (_PotScript[i].PotArray[0].gameObject.tag == "rice")
                    {
                        _PotParentScript[i].SetUIA(2);
                    }
                    else if (_PotScript[i].PotArray[0].gameObject.tag == "tmt")
                    {
                        _PotParentScript[i].SetUIA(3);
                    }

                }
                else if (_PotScript[i].CurrentMode == Pot.Mode.Double)
                {
                    if (_PotScript[i].PotArray[1].gameObject.tag == "egg")
                    {
                        _PotParentScript[i].SetUIB(1);
                    }
                    else if (_PotScript[i].PotArray[1].gameObject.tag == "rice")
                    {
                        _PotParentScript[i].SetUIB(2);
                    }
                    else if (_PotScript[i].PotArray[1].gameObject.tag == "tmt")
                    {
                        _PotParentScript[i].SetUIB(3);
                    }
                }
                else if (_PotScript[i].CurrentMode == Pot.Mode.Triple)
                {
                    if (_PotScript[i].PotArray[2].gameObject.tag == "egg")
                    {
                        _PotParentScript[i].SetUIC(1);
                    }
                    else if (_PotScript[i].PotArray[2].gameObject.tag == "rice")
                    {
                        _PotParentScript[i].SetUIC(2);
                    }
                    else if (_PotScript[i].PotArray[2].gameObject.tag == "tmt")
                    {
                        _PotParentScript[i].SetUIC(3);
                    }
                }
            }
            //フライパン
            for (int i = 0; i < _FryingPanScript.Length; i++)
            {
                if (_FryingPanScript[i].InFood == 0)
                {
                    _FryingPanParentScript[i].SetUIA(0);
                    _FryingPanParentScript[i].SetUIB(0);
                    _FryingPanParentScript[i].SetUIB(0);
                }
                else if (_FryingPanScript[i].InFood == 1)
                {
                    if (_FryingPanScript[i].FPanArray[0].gameObject.tag == "egg")
                    {
                        _FryingPanParentScript[i].SetUIA(1);
                    }
                    else if (_FryingPanScript[i].FPanArray[0].gameObject.tag == "rice")
                    {
                        _FryingPanParentScript[i].SetUIA(2);
                    }
                    else if (_FryingPanScript[i].FPanArray[0].gameObject.tag == "tmt")
                    {
                        _FryingPanParentScript[i].SetUIA(3);
                    }
                }
                else if (_FryingPanScript[i].InFood == 2)
                {
                    if (_FryingPanScript[i].FPanArray[0].gameObject.tag == "egg")
                    {
                        _FryingPanParentScript[i].SetUIB(1);
                    }
                    else if (_FryingPanScript[i].FPanArray[0].gameObject.tag == "rice")
                    {
                        _FryingPanParentScript[i].SetUIB(2);
                    }
                    else if (_FryingPanScript[i].FPanArray[0].gameObject.tag == "tmt")
                    {
                        _FryingPanParentScript[i].SetUIB(3);
                    }
                }
            }

        }
        /*
        if(Input.GetKey(KeyCode.N))
        {
            CookingUIOff();
        }
        if (Input.GetKey(KeyCode.M))
        {
            CookingUIOn();
        }
        */
    }

    //UI非表示
    public void CookingUIOff()
    {

        for (int i = 0; i < _FryingPanObject.Length; i++)
        {
            _FryingPanPrefabArray[i].SetActive(false);
        }
        for (int i = 0; i < _PotObject.Length; i++)
        {
            _PotPrefabArray[i].SetActive(false);
        }
    }
    //表示
    public void CookingUIOn()
    {

        for (int i = 0; i < _FryingPanObject.Length; i++)
        {
            _FryingPanPrefabArray[i].SetActive(true);
        }
        for (int i = 0; i < _PotObject.Length; i++)
        {
            _PotPrefabArray[i].SetActive(true);
        }
    }


}
