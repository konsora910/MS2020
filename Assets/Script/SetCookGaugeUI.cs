using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 調理時間を示すゲージを表示する
/// </summary>
public class SetCookGaugeUI : MonoBehaviour
{

    //GameObject canvas;

    /// <summary>
    /// ゲージUIのプレハブ (枠のみ)
    /// </summary>
    public GameObject GaugeUI01;

    /// <summary>
    /// ゲージUIのプレハブ (塗りつぶし)
    /// </summary>
    public GameObject GaugeUI02;

    /// <summary>
    /// フライパンの調理ゲージ調理ゲージのCanvasプレハブ
    /// </summary>
    public GameObject CanvasGaugeFlyingPan;

    /// <summary>
    /// 鍋調理ゲージのCanvasプレハブ
    /// </summary>
    public GameObject CanvasGaugePot;
    

    public GameObject Pot;
    public Pot PotScript;


    // Start is called before the first frame update
    void Start()
    {
        //canvas = GameObject.FindGameObjectWithTag("CanvasGaugeUI");
        Pot = GameObject.FindGameObjectWithTag("pot");
        PotScript = Pot.GetComponent<Pot>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.U))
        {
            //SetGaugeUI(new Vector3(100, 0, 0));
            //SetGaugeUIPot();
            SetGaugeUIFlyingPan();
            SetGaugeUIPot();
            
        }
        */
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
    public void SetGaugeUIFlyingPan()
    {
        GameObject prefab = (GameObject)Instantiate(CanvasGaugeFlyingPan, new Vector3(ConstGaugeUI.ConstUI.FLYINGPAN_POSITION[0], ConstGaugeUI.ConstUI.FLYINGPAN_POSITION[1], ConstGaugeUI.ConstUI.FLYINGPAN_POSITION[2]), Quaternion.identity);
        Destroy(prefab, ConstGaugeUI.ConstUI.FLYINGPAN_COOKING_TIME);
    }

    /// <summary>
    /// PotのUI表示
    /// </summary>
    /// <param name="position">表示場所</param>
    public void SetGaugeUIPot(Vector3 position)
    {
        GameObject prefab = (GameObject)Instantiate(CanvasGaugePot, position+new Vector3(ConstGaugeUI.ConstUI.POT_POSITION[0], ConstGaugeUI.ConstUI.POT_POSITION[1], ConstGaugeUI.ConstUI.POT_POSITION[2]), Quaternion.identity);
        Destroy(prefab, ConstGaugeUI.ConstUI.POT_COOKING_TIME);
    }

    

}
