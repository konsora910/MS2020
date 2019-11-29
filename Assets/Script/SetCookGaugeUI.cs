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
