using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlyingPanCookGaigeUI : MonoBehaviour
{
    public Image UIobj;

    void Update()
    {
        UIobj.fillAmount += 1.0f / ConstGaugeUI.ConstUI.FLYINGPAN_COOKING_TIME * Time.deltaTime;
    }
}
