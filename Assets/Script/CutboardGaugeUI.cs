using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CutboardGaugeUI : MonoBehaviour
{
    public Image UIobj;

    void Update()
    {
        UIobj.fillAmount += 1.0f / ConstGaugeUI.ConstUI.CUTTINGBOARD_COOKING_TIME * Time.deltaTime;
    }
}
