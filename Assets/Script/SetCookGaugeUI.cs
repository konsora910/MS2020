using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 調理時間を示すゲージを表示する
/// </summary>
public class SetCookGaugeUI : MonoBehaviour
{


    /// <summary>
    /// フライパンの調理ゲージ調理ゲージのCanvasプレハブ
    /// </summary>
    public GameObject CanvasGaugeFlyingPan;
    

    /// <summary>
    /// 鍋調理ゲージのCanvasプレハブ
    /// </summary>
    public GameObject CanvasGaugePot;

    /// <summary>
    /// まな板調理ゲージのCanvasプレハブ
    /// </summary>
    public GameObject CanvasGaugeCut;

    public GameObject prehubFryinpan;
    public GameObject prehubPot;
    public GameObject prehubCut;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// UI表示
    /// </summary>
    /// <param name="position">表示場所</param>
    public void SetGaugeUI(Vector3 position)
    {
    
    }

    /// <summary>
    /// フライパンのゲージのUI表示
    /// </summary>
    public void SetGaugeUIFlyingPan(Vector3 position)
    {
        prehubFryinpan = (GameObject)Instantiate(CanvasGaugeFlyingPan, position + new Vector3(ConstGaugeUI.ConstUI.FLYINGPAN_POSITION[0], ConstGaugeUI.ConstUI.FLYINGPAN_POSITION[1], ConstGaugeUI.ConstUI.FLYINGPAN_POSITION[2]), Quaternion.identity);
        prehubFryinpan.transform.rotation = Quaternion.Euler(60.0f, 0.0f, 0.0f);
        Destroy(prehubFryinpan, ConstGaugeUI.ConstUI.FLYINGPAN_COOKING_TIME);
    }

    /// <summary>
    /// PotのUI表示
    /// </summary>
    /// <param name="position">表示場所</param>
    public void SetGaugeUIPot(Vector3 position)
    {
        prehubPot = (GameObject)Instantiate(CanvasGaugePot, position+new Vector3(ConstGaugeUI.ConstUI.POT_POSITION[0], ConstGaugeUI.ConstUI.POT_POSITION[1], ConstGaugeUI.ConstUI.POT_POSITION[2]), Quaternion.identity);
        prehubPot.transform.rotation = Quaternion.Euler(60.0f, 0.0f, 0.0f);
        Destroy(prehubPot, ConstGaugeUI.ConstUI.POT_COOKING_TIME);
    }

    /// <summary>
    /// まな板のUI表示
    /// </summary>
    /// <param name="position">表示場所</param>
    public void SetGaugeUICuttingboard(Vector3 position)
    {
        prehubCut = (GameObject)Instantiate(CanvasGaugeCut, position + new Vector3(ConstGaugeUI.ConstUI.CUTTINGBOARD_POSITION[0], ConstGaugeUI.ConstUI.CUTTINGBOARD_POSITION[1], ConstGaugeUI.ConstUI.CUTTINGBOARD_POSITION[2]), Quaternion.identity);
        prehubCut.transform.rotation = Quaternion.Euler(60.0f, 0.0f, 0.0f);
        Destroy(prehubCut, ConstGaugeUI.ConstUI.CUTTINGBOARD_COOKING_TIME);
    }

    public void deleteGaugeFryinpan()
    {
        Destroy(prehubFryinpan) ;
    }
    public void deleteGaugePot()
    {
        Destroy(prehubPot);
    }
    public void deleteGaugeCut()
    {
        Destroy(prehubCut);
    }

}
