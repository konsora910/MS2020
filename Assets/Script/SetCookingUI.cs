using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCookingUI : MonoBehaviour
{
    /// <summary>
    /// オブジェクトからどれくらい離すか
    /// </summary>
    public Vector3 PositionShift=new Vector3(0.0f,0.0f,0.0f);

    /// <summary>
    /// UIの表示位置
    /// </summary>
    private Vector3 FryingPanPosition;
    private Vector3 PotPosition;

    /// <summary>
    /// 食材UIプレハブ
    /// </summary>
    public GameObject TmtUI;
    public GameObject EggUI;
    public GameObject riceUI;

    /// <summary>
    /// 各オブジェクト
    /// </summary>
    private GameObject FryingPanObject;
    private GameObject PotObject;

    /// <summary>
    /// 各スクリプト
    /// </summary>
    private FryingPan FlyingPanScript;
    private Pot PotScript;




    void Start()
    {
        //FryingPanObject = GameObject.FindGameObjectWithTag("FryingPan");
        //FryingPanScript = FryingPanObject.GetComponent<FryingPan>();
        PotObject = GameObject.FindGameObjectWithTag("pot");
        PotScript = PotObject.GetComponent<Pot>();

        //FryingPanPosition= FryingPanScript

        //PotPosition = PotScript.gameObject.transform.position+PositionShift;
    }

    void Update()
    {
        if(PotScript.CurrentMode == Pot.Mode.Stay)
        {

        }
        else if(PotScript.CurrentMode==Pot.Mode.Single)
        {

        }
        else if(PotScript.CurrentMode == Pot.Mode.Double)
        {

        }else if(PotScript.CurrentMode == Pot.Mode.Triple)
        {

        }
    }

    /*
    public void SetGaugeUIFlyingPan()
    {
        GameObject prefab = (GameObject)Instantiate(CanvasGaugeFlyingPan, new Vector3(ConstGaugeUI.ConstUI.FLYINGPAN_POSITION[0], ConstGaugeUI.ConstUI.FLYINGPAN_POSITION[1], ConstGaugeUI.ConstUI.FLYINGPAN_POSITION[2]), Quaternion.identity);
        Destroy(prefab, ConstGaugeUI.ConstUI.FLYINGPAN_COOKING_TIME);
    }
    */
}
